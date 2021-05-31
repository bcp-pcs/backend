using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Applicant
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int Age {
            get { return Api.Helper.DateTimeHelper.GetAge(DateOfBirth); }
        }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
