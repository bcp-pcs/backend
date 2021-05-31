using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Api.Models
{
    public class ApiDbContext : IdentityDbContext
    {
        static bool _testDataInitialized = false;
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
            // TODO (like to have) Allow to enable/disable by configure
            this.CreateCaseStudyData();
        }

        private void CreateCaseStudyData() {
            if (_testDataInitialized)
                return;
            
            _testDataInitialized = true;
            Mortgages.Add(new Mortgage() {Lender = "Bank A", InterestRate = 0.02f, InterestRateType = "Variable", LTV = 0.6f });
            Mortgages.Add(new Mortgage() {Lender = "Bank B", InterestRate = 0.03f, InterestRateType = "Fixed", LTV = 0.6f });
            Mortgages.Add(new Mortgage() {Lender = "Bank C", InterestRate = 0.04f, InterestRateType = "Variable", LTV = 0.9f });
            this.SaveChangesAsync();
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }
    }
}
