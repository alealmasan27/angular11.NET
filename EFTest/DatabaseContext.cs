using EFTest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace EFTest
{
    public class DatabaseContext: DbContext
    {
        public IConfiguration Configuration { get; }

        public DatabaseContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DatabaseContext()
        {

        }
        
        public DbSet<Shareholder> Shareholders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShareholderToCompany> ShareholdersToCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShareholderToCompany>()
                .HasKey(c => new { c.CompanyId, c.ShareholderId });
        }
    }
}
