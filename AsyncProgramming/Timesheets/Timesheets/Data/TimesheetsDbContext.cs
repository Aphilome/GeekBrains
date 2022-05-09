using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Entities;

namespace Timesheets.Data
{
    public class TimesheetsDbContext : DbContext
    {
        public TimesheetsDbContext(DbContextOptions<TimesheetsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<JobTask> JobTasks { get; set; }
    }
}
