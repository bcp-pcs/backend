using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientServicesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ClientServicesController(ApiDbContext context)
        {
            _context = context;
        }

       [HttpGet("Profile/{id:long}")]
        public async Task<ActionResult<Applicant>> GetApplicant(long id)
        {
            var applicant = await _context.Applicants.FindAsync(id);

            if (applicant == null)
            {
                return NotFound();
            }

            return applicant;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Applicant>> PostApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetApplicant), new { id = applicant.Id }, applicant);
        }
    }
}
