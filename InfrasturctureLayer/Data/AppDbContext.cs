using Microsoft.EntityFrameworkCore;
using DomainLayer.Entities;
namespace InfrasturctureLayer.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions <AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
