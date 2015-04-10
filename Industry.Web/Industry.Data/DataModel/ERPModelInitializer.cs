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
            var log = new Collection<ActionLog>();

            #region Общие

            var admin = new User()
            {
                Email = "admin@ipositron.ru",
                GlobalId = Guid.NewGuid(),
                ObjectState = ObjectState.Added,
                //IsActive = true
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

            #endregion Общие

            #region Компании

            var customerType = new CustomerType() { Name = "Покупатель", ObjectState = ObjectState.Added };
            context.CustomerTypes.Add(new CustomerType() { Name = "Поставщик", ObjectState = ObjectState.Added });
            context.CustomerTypes.Add(new CustomerType() { Name = "Виртуальный", ObjectState = ObjectState.Added });
            
            var customer = new Customer()
            {
                Name = "Позитрон",
                Code = "001",
                Descr = "Основной покупатель",
                CustomerTypes = new Collection<CustomerType>() { customerType },
                ObjectState = ObjectState.Added,
                GlobalId = Guid.NewGuid()
            };
            context.Customers.Add(customer);

            context.SaveChanges();

            #endregion Компании

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
                    Name = "+7 (4012) 527 713",
                    ContactInfoType = phoneType,
                    Customer = customer,
                    Descr = "Основной телефон",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    Name = "236008, Российская Федерация, Калининградская обл, г Калининград, ул Верхнеозерная, д. 24",
                    ContactInfoType = addressType,
                    Customer = customer,
                    Descr = "Основной адрес",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    Name = "ds@ipositron.ru",
                    ContactInfoType = mailType,
                    Customer = customer,
                    Descr = "Основная почта",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    Name = "www.ipositron.ru",
                    ContactInfoType =siteType,
                    Customer = customer,
                    Descr = "Основной сайт",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
                new ContactInfo()
                {
                    Name = "+7 (921) 710 77 13 ",
                    ContactInfoType = phoneType,
                    Customer = customer,
                    Descr = "Мобильный телефон",
                    IsBasic = true,
                    IsActive = true, ObjectState = ObjectState.Added,
                    GlobalId = Guid.NewGuid()
                },
            };
            contactdata.ForEach(cd => context.ContactInfos.Add(cd));

            context.SaveChanges();
            #endregion

            #region Контрагенты

            var contractortype = new List<ContractorType>()
            {
                new ContractorType() {Name = "Юридическое лицо", IsActive = true, ObjectState = ObjectState.Added},
                new ContractorType() {Name = "Физическое лицо", IsActive = true, ObjectState = ObjectState.Added},
                new ContractorType() {Name = "ИП", IsActive = true, ObjectState = ObjectState.Added}
            };
            contractortype.ForEach(p => context.ContractorTypes.Add(p));
            context.SaveChanges();

            var contractorforms = new List<ContractorForm>()
            {
                new ContractorForm() { Name = "ООО", FullName = "Общество с ограниченной ответственностью", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added},
                new ContractorForm() { Name = "ИП", FullName = "Индивидуальный предприниматель", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added},
                new ContractorForm() { Name = "АО", FullName = "Акционерное общество", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added},
                new ContractorForm() { Name = "ЗАО", FullName = "Закрытое акционерное общество", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added },
                new ContractorForm() { Name = "МАОУ", FullName = "Муниципальное автономное общеобразовательное учреждение", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added  },
                new ContractorForm() { Name = "МАУК", FullName = "Муниципальное автономное учреждение культуры", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added },
                new ContractorForm() { Name = "НОУ", FullName = "Некоммерческое образовательное учреждение", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added },
                new ContractorForm() { Name = "ОАО", FullName = "Открытое акционерное общество", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added },
                new ContractorForm() { Name = "УП", FullName = "Унитарное предприятие", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added  },
                new ContractorForm() { Name = "УФК", FullName = "Учреждение Федерального казначейства", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added },
                new ContractorForm() { Name = "ФГУП", FullName = "Федеральное государственное унитарное предприятие", GlobalId = Guid.NewGuid(), IsActive = true, ObjectState = ObjectState.Added }
            };
            contractorforms.ForEach(p => context.ContractorForms.Add(p));
            context.SaveChanges();

            var contractor = new Contractor()
                {
                    Name = "Позитрон"
                    , Descr = "Работает без НДС"
                    , Code = "001"
                    , Customer = customer
                    , ContractorType = contractortype.First()
                    , ContractorForm = contractorforms.First()
                    , CustomerTypes = new Collection<CustomerType>() { customerType }
                    , RegistrationAddress = "236008, Российская Федерация, Калининградская обл, г Калининград, ул Верхнеозерная, д. 24"
                    , PostAddress = "236008, Российская Федерация, Калининградская обл, г Калининград, ул Верхнеозерная, д. 24"
                    , INN = "3901502273"
                    , KPP = "390601001"
                    , OGRN = "1123926045396"
                    , OKPO = "24399828"
                    , Phone = "+79217107713"
                    , Email = "ds@ipositron.ru"
                    , GlobalId = Guid.NewGuid()
                    , IsActive = true
                    , ObjectState = ObjectState.Added
                };
            context.Contractors.Add(contractor);

            #endregion Контрагенты

            #region Контакты

            var contact = new Contact()
                {
                    Name = "Соня",
                    LastName = "Демирчиян",
                    MiddleName = "Апресовна",
                    Customer = customer,
                    BirthDate = Convert.ToDateTime("2000-01-01 00:00:00"),
                    Position = "Офис-менеджер",
                    IsActive = true,
                    GlobalId = Guid.NewGuid(),
                    ObjectState = ObjectState.Added,
                    ContactInfos = new Collection<ContactInfo>() { new ContactInfo()
                    {
                        Name = "+7 (4012) 527 713",
                        ContactInfoType = phoneType,
                        IsActive = true,
                        ObjectState = ObjectState.Added,
                        GlobalId = Guid.NewGuid()
                    }}
                };
            context.Contacts.Add(contact);
            context.SaveChanges();

            #endregion Контакты

            #region Адреса

            var point = new CustomerPoint()
            {
                Name = "Центральный офис региона",
                Address = "236008, Российская Федерация, Калининградская обл, г Калининград, ул Верхнеозерная, д. 24",
                Phone = "+79217107713",
                Email = "ds@ipositron.ru",
                Descr = "Звонить с 09 до 18 по МСК",
                ObjectState = ObjectState.Added,
                GlobalId = Guid.NewGuid(),
                Customer = customer
            };
            context.CustomerPoints.Add(point);
            log.Add(ActionLog.SaveByIds(admin.Id, point.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", point.GetType()));

            #endregion Адреса

            //TODO Файлы (в отдельную базу и контекст)

            //TODO Банки, р/с

            #region Заявки

            var shopper = new Shopper()
            {
                Name = "Покупатель",
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
            context.SaveChanges();

            #endregion Заявки

            

            #region activelog

            log.Add(ActionLog.SaveByIds(admin.Id, admin.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", admin.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, admin.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", admin.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, shopper.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", shopper.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, category.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", category.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, product.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", product.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, bid.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", product.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, customer.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", customer.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, contractor.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", contractor.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, contact.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", contact.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, shopper.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", shopper.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, category.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", category.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, product.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", product.GetType()));
            log.Add(ActionLog.SaveByIds(admin.Id, bid.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", bid.GetType()));

            contactdata.ForEach(ci => log.Add(ActionLog.SaveByIds(admin.Id, ci.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", ci.GetType())));
            contractorforms.ForEach(cf => log.Add(ActionLog.SaveByIds(admin.Id, cf.GlobalId, (int)ActionTypeNames.Common.Added, "Добавлен автоматически", cf.GetType())));
            context.ActionLogs.AddRange(log);

            #endregion activelog

            context.SaveChanges();


        }
    }
}
