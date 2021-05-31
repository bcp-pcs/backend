using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Mortgage
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public string Lender { get; set; }

        public float InterestRate { get; set; }

        [MaxLength(30)]
        public string InterestRateType { get; set; }
        
        public float LVR { get; set; } // Loan to Value Ratio
    }
}
