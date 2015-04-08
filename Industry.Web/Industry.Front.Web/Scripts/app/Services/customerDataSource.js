'use strict';

industryApp.factory('customerDataSource',
    function (customerModel) {
        var crudServiceBaseUrl = "/api/Customer";

        return new kendo.data.DataSource({
            type: "api",
            transport: {
                read: {
                    async: false,
                    url: crudServiceBaseUrl,
                    dataType: "json"
                },
                update: {
                    url: function (data) {
                        return crudServiceBaseUrl + "(" + data.CustomerID + ")";
                    },
                    type: "put",
                    dataType: "json"
                },
                destroy: {
                    url: function (data) {
                        return crudServiceBaseUrl + "(" + data.CustomerID + ")";
                    },
                    dataType: "json"
                }
            },
            batch: false,
            serverPaging: true,
            serverSorting: true,
            serverFiltering: true,
            pageSize: 10,
            schema: {
                data: function (data) { return data.value; },
                total: function (data) { return data["api.count"]; },
                model: customerModel
            },
            error: function (e) {
                alert(e.xhr.responseText);
            }
        });
    });