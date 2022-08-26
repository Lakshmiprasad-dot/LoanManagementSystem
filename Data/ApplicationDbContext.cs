using LoanManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<RateOfInterest> RateOfInterests { get; set; }
        public DbSet<LoanApplication> LoanApplication { get; set; }
        public DbSet<LoanManagementSystem.Models.LoanEligibility> LoanEligibility { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
       
        
       

    }
}
