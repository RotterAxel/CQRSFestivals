using System.IO;
using System.Reflection;
using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public class FestivalsDbContext : DbContext, IFestivalDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public FestivalsDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService,
            IDateTime dateTime) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public FestivalsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        //TODO: Test if non-matching RowVersions will throw DbException
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.Created = _dateTime.UtcNow;
                        entry.Entity.RowVersion = _dateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        entry.Entity.RowVersion = _dateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
    }
    
    public class FestivalsDbContextDesignFactory : IDesignTimeDbContextFactory<FestivalsDbContext>
    {
        public FestivalsDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WebUI"))
                .AddJsonFile("appsettings.json")
                .Build();
            
            var connectionString = config.GetConnectionString("InsuranceConnection");
            
            var optionsBuilder = new DbContextOptionsBuilder<FestivalsDbContext>()
                .UseMySql(connectionString);
    
            return new FestivalsDbContext(optionsBuilder.Options);
        }
    }
}