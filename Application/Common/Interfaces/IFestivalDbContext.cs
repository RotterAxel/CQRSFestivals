using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IFestivalDbContext
    {
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        int SaveChanges();
    }
}