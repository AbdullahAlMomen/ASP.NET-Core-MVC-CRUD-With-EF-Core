using DotNetCore_MVC_CRUD_with_EFCore.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetCore_MVC_CRUD_with_EFCore.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public MVCDemoDbContext() { }

        public DbSet<Employee> Employees { get; set; }
    }
}
