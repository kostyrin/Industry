using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Industry.Common.Enums;
using Industry.Data.Repositories;
using Industry.Domain.Entities;
using Industry.Data.DataModel;
using Repository.Pattern.Infrastructure;

namespace Industry.Data.DataModel
{
    public class ERPModelInitializer : CreateDatabaseIfNotExists<ERPContext>
    {
        protected override void Seed(ERPContext context)
        {
            var admin = new User()
            {
                Email = "admin@ipositron.ru",
                GlobalId = Guid.NewGuid(),
                ObjectState = ObjectState.Added,
                IsActive = true
            };

            context.Users.Add(admin);

            var cultureEn = new Culture() {Name = "English", Code = "en-GB", ObjectState = ObjectState.Added };
            var cultureRu = new Culture() { Name = "Russian", Code = "ru-RU", ObjectState = ObjectState.Added };
            context.Cultures.Add(cultureEn);
            context.Cultures.Add(cultureRu);

            context.SaveChanges();

            var locals = new Collection<LocaleString>()
            {
                new LocaleString() { Name = "Common.Added", Culture = cultureEn, Value = "Added", ObjectState = ObjectState.Added },
                new LocaleString() { Name = "Common.Added", Culture = cultureRu, Value = "Добавлен", ObjectState = ObjectState.Added },
                new LocaleString() { Name = "Common.Modified", Culture = cultureEn, Value = "Modified", ObjectState = ObjectState.Added },
                new LocaleString() { Name = "Common.Modified", Culture = cultureRu, Value = "Изменён", ObjectState = ObjectState.Added },
                new LocaleString() { Name = "Common.Deleted", Culture = cultureEn, Value = "Deleted", ObjectState = ObjectState.Added },
                new LocaleString() { Name = "Common.Deleted", Culture = cultureRu, Value = "Удалён", ObjectState = ObjectState.Added },
            };
            context.LocaleStrings.AddRange(locals);

            var actionTypeAdd = new ActionType() { Name = "Common.Added", ObjectState = ObjectState.Added };
            context.ActionTypes.Add(actionTypeAdd);

            var actions = new Collection<ActionType>()
            {
                new ActionType() { Name = "Common.Modified", ObjectState = ObjectState.Added },
                new ActionType() { Name = "Common.Deleted", ObjectState = ObjectState.Added },
            };
            context.ActionTypes.AddRange(actions);

            context.SaveChanges();

            var shopper = new Shopper()
            {
                ShopperName = "Покупатель",
                Address = "Калининград",
                IsActive = true,
                ObjectState = ObjectState.Added,
                GlobalId = Guid.NewGuid()
            };
            context.Shoppers.Add(shopper);

            var category = new SerialCategory()
            {
                CategoryName = "Спорт",
                IsActive = true,
                ObjectState = ObjectState.Added,
                GlobalId = Guid.NewGuid()
            };

            var product = new SerialProduct()
            {
                ObjectState = ObjectState.Added,
                ProductName = "Беговая дорожка",
                IsActive = true,
                Category = category,
                GlobalId = Guid.NewGuid()
            };

            var bid = new SerialBid()
            {
                ObjectState = ObjectState.Added,
                GlobalId = Guid.NewGuid(),
                Shopper = shopper,
                BidDate = DateTime.Now,
                IsActive = true,
                BidDetails = new Collection<SerialBidDetail>(new SerialBidDetail[]
                {
                    new SerialBidDetail()
                    {
                        ObjectState = ObjectState.Added,
                        Product = product,
                    }
                })
            };
            context.SerialBids.Add(bid);

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
                IsActive = true,
                CustomerType = customerType,
                ObjectState = ObjectState.Added,
                GlobalId = Guid.NewGuid()
            };
            context.Customers.Add(customer);

            context.SaveChanges();

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
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    ContactInfoName = "236008, Российская Федерация, Калининградская обл, г Калининград, ул Верхнеозерная, д. 24",
                    ContactInfoType = addressType,
                    Customer = customer,
                    ContactInfoDescr = "Основной адрес",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    ContactInfoName = "ds@ipositron.ru",
                    ContactInfoType = mailType,
                    Customer = customer,
                    ContactInfoDescr = "Основная почта",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    ContactInfoName = "www.ipositron.ru",
                    ContactInfoType =siteType,
                    Customer = customer,
                    ContactInfoDescr = "Основной сайт",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    ContactInfoName = "+7 (921) 710 77 13 ",
                    ContactInfoType = phoneType,
                    Customer = customer,
                    ContactInfoDescr = "Мобильный телефон",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
            };
            contactdata.ForEach(cd => context.ContactInfos.Add(cd));

            context.SaveChanges();
            #endregion

            context.CustomerTypes.Add(new CustomerType() { CustomerTypeName = "Поставщик", IsActive = true, ObjectState = ObjectState.Added });
            context.CustomerTypes.Add(new CustomerType() { CustomerTypeName = "Виртуальный", IsActive = true, ObjectState = ObjectState.Added });

            #region activelog

            //var action1 = new ActionLog()
            //{
            //    User = admin,
            //    EntityGlobalId = shopper.GlobalId,
            //    ActionType = actionTypeAddRu,
            //    Date = DateTime.Now,
            //    Comment = "Добавлен автоматически",
            //    Mnemocode = shopper.GetType().Name,
            //    ObjectState = ObjectState.Added
            //};
            //context.ActionLogs.Add(action1);

            var log = new Collection<ActionLog>()
            {
                new ActionLog().SaveByIds(admin.Id, admin.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", admin.GetType()),
                new ActionLog().SaveByIds(admin.Id, shopper.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", shopper.GetType()),
                new ActionLog().SaveByIds(admin.Id, category.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", category.GetType()),
                new ActionLog().SaveByIds(admin.Id, product.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", product.GetType()),
                new ActionLog().SaveByIds(admin.Id, bid.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", product.GetType()),
                new ActionLog().SaveByIds(admin.Id, customer.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", customer.GetType()),
            };
            contactdata.ForEach(ci => log.Add(new ActionLog().SaveByIds(admin.Id, ci.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", ci.GetType())));
            context.ActionLogs.AddRange(log);

            #endregion activelog

            context.SaveChanges();


        }
    }
}
