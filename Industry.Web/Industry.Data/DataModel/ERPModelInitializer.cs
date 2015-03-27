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
                Name = "Покупатель",
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
                Name = "Заказчик",
                ObjectState = ObjectState.Added
            };

            context.Customers.Add(new Customer()
            {
                Name = "Позитрон",
                IsActive = true,
                CreatedDate = DateTime.Now,
                CreatedId = 1,
                CustomerType = customerType,
                ObjectState = ObjectState.Added
            });
            context.SaveChanges();


        }
    }
}
