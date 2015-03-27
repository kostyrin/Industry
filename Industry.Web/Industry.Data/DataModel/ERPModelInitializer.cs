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
                Name = "Позитрон",
                Address = "Верхнеозерная 24",
                IsActive = true,
                ObjectState = ObjectState.Added
            };
            context.Shoppers.Add(shopper);

            var product = new SerialProduct()
            {
                ObjectState = ObjectState.Added,
                ProductName = "Беговая дорожка"
            };

            context.SerialBids.Add(entity: new SerialBid()
            {
                ObjectState = ObjectState.Added,
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
            });

            context.SaveChanges();


        }
    }
}
