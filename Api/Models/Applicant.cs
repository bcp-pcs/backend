using System;

namespace Api.Models
{
    public class Applicant
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Email { get; set; }
    }
}
