using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using System.Security.Claims;

namespace Api.Helper {

        class JwtHelper {
            public static async Task<Applicant> GetLoginApplicant(ClaimsIdentity identity, ApiDbContext context)
            {
                // TODO (like to have) Link Applicant on register by Id
                var _email = identity.Claims.Where(c => c.Type == ClaimTypes.Email).Select(c => c.Value).SingleOrDefault();
                var applicant = await context.Applicants.FirstAsync(x => x.Email == _email);

                return applicant;
            }
        }

}