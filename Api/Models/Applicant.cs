using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Applicant
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
    }
}
