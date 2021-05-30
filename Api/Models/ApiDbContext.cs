using Microsoft.EntityFrameworkCore;

namespace Api.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }
    }
}
