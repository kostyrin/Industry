'use strict';

industryApp.factory('customerModel', function () {
    return kendo.data.Model.define({
        id: "CustomerID",
        fields: {
            CustomerID: { type: "string", editable: false, nullable: false },
            CustomerName: { title: "Company", type: "string" }
        }
    });
});