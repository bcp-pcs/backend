using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Api.Helper;

namespace Api.Controllers
{
    [Route("api/Search")]
    [ApiController]
    public class SearchServicesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public SearchServicesController(ApiDbContext context)
        {
            _context = context;
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("Mortgages")]
        public async Task<IEnumerable<Mortgage>> SearchMortgages(
            [FromQuery] float proprtyPrice, [FromQuery] float deposit
            )
        {
            Applicant _loginUser = await JwtHelper.GetLoginApplicant(
                (ClaimsIdentity) HttpContext.User.Identity,
                 _context
                );

            return await FindMortgagesByLTV(_loginUser, proprtyPrice, deposit);
        }

        [HttpGet("MortgagesById")]
        public async Task<IEnumerable<Mortgage>> SearchMortgagesById(
            [FromQuery] long id,[FromQuery] float proprtyPrice, [FromQuery] float deposit
            )
        {
            Applicant _loginUser = await _context.Applicants.FindAsync(id);

            return await FindMortgagesByLTV(_loginUser, proprtyPrice, deposit);
        }

        private async Task<IEnumerable<Mortgage>> FindMortgagesByLTV(
            Applicant applicant, float proprtyPrice, [FromQuery] float deposit
            )
        {
             if (applicant.Age < 18) {
                return new List<Mortgage>();
            }

            float _LTV = (proprtyPrice - deposit) / proprtyPrice;
            Console.WriteLine($"proprtyPrice={proprtyPrice} deposit={deposit} LVR={_LTV}");

            var mortgage = await _context.Mortgages
                .Where(x => x.LTV >= _LTV)
                .ToListAsync();

            return mortgage;
        }
    }
}
