using System.ComponentModel.DataAnnotations;
using Api.Models;

namespace Api.Models.DTOs.Requests
{
    public class UserRegistrationDto : Applicant
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}