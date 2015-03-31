using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Industry.Domain.Entities;
using Repository.Pattern.Ef6;

namespace Industry.Data.DataModel
{
    public partial class ERPContext : DataContext
    {
        public ERPContext() : base("Name=ERPContext")
        {
            Database.SetInitializer(new ERPModelInitializer());
        }

        //Сущности клиентского блока
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<ContactInfoType> ContactInfoTypes { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<User> Users { get; set; }

        //Сущности производства
        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<SerialCategory> SerialCategories { get; set; }
        public DbSet<SerialProduct> SerialProducts { get; set; }
        
        public DbSet<SerialBidDetail> SerialBidDetails { get; set; }
        public DbSet<SerialBid> SerialBids { get; set; }
        
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
