
using Data.DataSeeder;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DatabaseContext : Microsoft.EntityFrameworkCore.DbContext //, IDatabaseContext
    {

        #region Solution (1)
        //public DatabaseContext() : base()
        //{
        //}

        //protected override void OnConfiguring
        //    (Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    if (optionsBuilder.IsConfigured == false)
        //    {
        //        // using Microsoft.EntityFrameworkCore;
        //        optionsBuilder
        //            .UseSqlServer(connectionString: "Password=Baran972;Persist Security Info=True;User ID=SA;Initial Catalog=Moris;Data Source=.");
        //    }
        //}
        #endregion /Solution (1)

        #region Solution (2)
        //public DatabaseContext(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options)
        //{
        //    Database.EnsureCreated();
        //}
        #endregion /Solution (2)

        #region Solution (3)
        /// <summary>
        /// Using Migrations!
        /// </summary>
        public DatabaseContext(Microsoft.EntityFrameworkCore.DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
        #endregion /Solution (3)

        // **********
        //public DatabaseContext() : base()
        //{ }
        // **********


        #region Public
        //public Microsoft.EntityFrameworkCore.DbSet<Models.Culture> Cultures { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.Country> Countries { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.State> States { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.City> Cities { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.Address> Addresses { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.PhoneNumberType> PhoneNumberTypes { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.PhoneNumber> PhoneNumbers { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.SoilTexture> SoilTextures { get; set; }
        //public Microsoft.EntityFrameworkCore.DbSet<Models.Ownership> Ownerships { get; set; }
        #endregion

        #region Authentication
        public Microsoft.EntityFrameworkCore.DbSet<Models.User> Users { get; set; }
        #endregion

        #region Company
        public Microsoft.EntityFrameworkCore.DbSet<Models.Company> Companies { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.CompanyType> CompanyTypes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.CompanyCategory> CompanyCategories { get; set; }
        #endregion

        #region Product
        public Microsoft.EntityFrameworkCore.DbSet<Models.PrincipalBusiness> PrincipalBusinesses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.Business> Businesses { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.BusinessType> BusinessTypes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.Activity> Activities { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.ActivityIndicator> ActivityIndicators { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.ProductType> ProductTypes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.Product> Products { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.ProductIndicator> ProductIndicators { get; set; }

        #endregion

        #region General
        public Microsoft.EntityFrameworkCore.DbSet<Models.Metric> Metrics { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.Year> Years { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.ChatMessage> chatMessages { get; set; }

        #endregion

        #region Basic Information
        //public Microsoft.EntityFrameworkCore.DbSet<Models.BasicInfo.Field> Fields { get; set; }
        #endregion

        #region Schedules

        public Microsoft.EntityFrameworkCore.DbSet<Models.Plan> Plans { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.ActivityPlan> ActivityPlans { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Models.ProductActivityPlan> productActivityPlans { get; set; }
        #endregion

        protected override void OnModelCreating
            (Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FluentConfigs.UserConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.General.ChatMessageConfig());

            modelBuilder.ApplyConfiguration(new FluentConfigs.Schedules.PlanConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.Schedules.ActivityPlanConfig());  
            modelBuilder.ApplyConfiguration(new FluentConfigs.Schedules.ProductActivityPlanConfig());          

            //modelBuilder.ApplyConfiguration(new FluentConfigs.CultureConfig());
            //modelBuilder.ApplyConfiguration(new FluentConfigs.CountryConfig());
            //modelBuilder.ApplyConfiguration(new FluentConfigs.StateConfig());
            //modelBuilder.ApplyConfiguration(new FluentConfigs.CityConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.CompanyConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.CompanyCategoryConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.CompanyTypeConfig());
            //modelBuilder.ApplyConfiguration(new FluentConfigs.PhoneNumberTypeConfig());

            //modelBuilder.ApplyConfiguration(new FluentConfigs.Public.SoileTextureConfig());
            //modelBuilder.ApplyConfiguration(new FluentConfigs.Public.OwnershipConfig());
            //modelBuilder.ApplyConfiguration(new FluentConfigs.BasicInfo.FieldConfig());

            modelBuilder.ApplyConfiguration(new FluentConfigs.Products.PrincipalBusinessConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.Products.BusinessConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.Products.ActivityConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.Products.ActivityIndicatorConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.Products.ProductConfig());
            modelBuilder.ApplyConfiguration(new FluentConfigs.Products.ProductTypeConfig());            
            modelBuilder.ApplyConfiguration(new FluentConfigs.Products.ProductIndicatorConfig());
          

            //modelBuilder.PublicSeed();
            //modelBuilder.CompanySeed();
            //modelBuilder.EmployeesSeed();


           


        }
        //==================================888888888888888888888888888888888888888888888========================================
        //public IQueryable<Models.Employee> AllReports(int id) =>
        //       Employees.FromSqlRaw("Exec dbo.AllReports {0}", id);

    }
}
