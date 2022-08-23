using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<RateOfInterest> RateOfInterests { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    }
}
