using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Industry.Domain;
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

        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<ActionType> ActionTypes { get; set; }
        public DbSet<LocaleString> LocaleStrings { get; set; }
        public DbSet<Culture> Cultures { get; set; }

        //Сущности клиентского блока
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CustomerPoint> CustomerPoints { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<ContactInfoType> ContactInfoTypes { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<ContractorType> ContractorTypes { get; set; }
        public DbSet<ContractorForm> ContractorForms { get; set; }
        public DbSet<Contact> Contacts { get; set; }
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

            //привязываем ActionLog к FK ActionLogGlobalId в EntityCatalog
            //modelBuilder.Entity<ActionLog>().HasRequired(p => p.ActionType).WithMany(b => b.ActionLogs).HasForeignKey(p => p.ActionTypeId);

            modelBuilder.Entity<Customer>().HasMany(a => a.CustomerTypes).WithMany(a => a.Customers).Map(configuration => configuration.ToTable("Customer_CustomerType"));
            modelBuilder.Entity<Contractor>().HasMany(a => a.CustomerTypes).WithMany(a => a.Contractors).Map(configuration => configuration.ToTable("Contractor_CustomerType"));
        }
    }
}
