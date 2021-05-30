using System;

namespace Api.Models
{
    public class Mortgage
    {
        public long Id { get; set; }
        public string Lender { get; set; }
        public float InterestRate { get; set; }
        public string InterestRateType { get; set; } 
        public float LVR { get; set; } // Loan to Value Ratio
    }
}
