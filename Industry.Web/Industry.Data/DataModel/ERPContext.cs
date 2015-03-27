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

        public DbSet<SerialCategory> SerialCategories { get; set; }
        public DbSet<Shopper> Shoppers { get; set; }
        public DbSet<SerialBidDetail> SerialBidDetails { get; set; }
        public DbSet<SerialBid> SerialBids { get; set; }
        public DbSet<SerialProduct> SerialProducts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
