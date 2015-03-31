using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industry.Domain.Entities;
using Industry.Data.DataModel;
using Repository.Pattern.Infrastructure;

namespace Industry.Data.DataModel
{
    public class ERPModelInitializer : CreateDatabaseIfNotExists<ERPContext>
    {
        protected override void Seed(ERPContext context)
        {
            var shopper = new Shopper()
            {
                ShopperName = "Покупатель",
                Address = "Калининград",
                IsActive = true,
                CreatedId = 1,
                CreatedDate = DateTime.Now,
                ObjectState = ObjectState.Added
            };
            context.Shoppers.Add(shopper);

            var category = new SerialCategory()
            {
                CategoryName = "Спорт",
                IsActive = true,
                CreatedId = 1,
                CreatedDate = DateTime.Now,
                ObjectState = ObjectState.Added
            };

            var product = new SerialProduct()
            {
                ObjectState = ObjectState.Added,
                ProductName = "Беговая дорожка",
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedId = 1,
                Category = category
            };

            context.SerialBids.Add(entity: new SerialBid()
            {
                ObjectState = ObjectState.Added,
                Shopper = shopper,
                BidDate = DateTime.Now,
                IsActive = true,
                CreatedId = 1,
                CreatedDate = DateTime.Now,
                BidDetails = new Collection<SerialBidDetail>(new SerialBidDetail[]
                {
                    new SerialBidDetail()
                    {
                        ObjectState = ObjectState.Added,
                        Product = product,
                    } 
                })
            });

            var customerType = new CustomerType()
            {
                CustomerTypeName = "Покупатель",
                IsActive = true,
                ObjectState = ObjectState.Added
            };

            var customer = new Customer()
            {
                CustomerName = "Позитрон",
                CustomerCode = "001",
                CustomerDescr = "Основной покупатель",
                //ManagerUserId = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedId = 1,
                CustomerType = customerType,
                ObjectState = ObjectState.Added
            };
            context.Customers.Add(customer);

            #region Контактные Данные

            ContactInfoType phoneType = new ContactInfoType() { ContactInfoTypeName = "Телефон", IsActive = true, ObjectState = ObjectState.Added };
            ContactInfoType addressType = new ContactInfoType() { ContactInfoTypeName = "Адрес", IsActive = true, ObjectState = ObjectState.Added };
            ContactInfoType mailType = new ContactInfoType() { ContactInfoTypeName = "E-mail", IsActive = true, ObjectState = ObjectState.Added };
            ContactInfoType siteType = new ContactInfoType() { ContactInfoTypeName = "Сайт", IsActive = true, ObjectState = ObjectState.Added };

            var contactdatatype = new List<ContactInfoType>
            {
                phoneType,
                addressType,
                mailType,
                siteType
            };
            contactdatatype.ForEach(cdt => context.ContactInfoTypes.Add(cdt));

            var contactdata = new List<ContactInfo>()
            {
                new ContactInfo()
                {
                    ContactInfoName = "+7 (4012) 527 713",
                    ContactInfoType = phoneType,
                    Customer = customer,
                    ContactInfoDescr = "Основной телефон",
                    IsBasic = true,
                    CreatedDate = DateTime.Now,
                    CreatedId = 1,
                    IsActive = true, ObjectState = ObjectState.Added
                },
                new ContactInfo()
                {
                    ContactInfoName = "236008, Российская Федерация, Калининградская обл, г Калининград, ул Верхнеозерная, д. 24",
                    ContactInfoType = addressType,
                    Customer = customer,
                    ContactInfoDescr = "Основной адрес",
                    IsBasic = true,
                    CreatedDate = DateTime.Now,
                    CreatedId = 1,
                    IsActive = true, ObjectState = ObjectState.Added
                },
                new ContactInfo()
                {
                    ContactInfoName = "ds@ipositron.ru",
                    ContactInfoType = mailType,
                    Customer = customer,
                    ContactInfoDescr = "Основная почта",
                    IsBasic = true,
                    CreatedDate = DateTime.Now,
                    CreatedId = 1,
                    IsActive = true, ObjectState = ObjectState.Added
                },
                new ContactInfo()
                {
                    ContactInfoName = "www.ipositron.ru",
                    ContactInfoType =siteType,
                    Customer = customer,
                    ContactInfoDescr = "Основной сайт",
                    IsBasic = true,
                    CreatedDate = DateTime.Now,
                    CreatedId = 1,
                    IsActive = true, ObjectState = ObjectState.Added
                },
                new ContactInfo()
                {
                    ContactInfoName = "+7 (921) 710 77 13 ",
                    ContactInfoType = phoneType,
                    Customer = customer,
                    ContactInfoDescr = "Мобильный телефон",
                    IsBasic = true,
                    CreatedDate = DateTime.Now,
                    CreatedId = 1,
                    IsActive = true, ObjectState = ObjectState.Added
                },
            };
            contactdata.ForEach(cd => context.ContactInfos.Add(cd));
            #endregion

            context.CustomerTypes.Add(new CustomerType() { CustomerTypeName = "Поставщик", IsActive = true, ObjectState = ObjectState.Added });
            context.CustomerTypes.Add(new CustomerType() { CustomerTypeName = "Виртуальный", IsActive = true, ObjectState = ObjectState.Added });

            context.SaveChanges();


        }
    }
}
