using System.ComponentModel.DataAnnotations;

namespace InsurancePolicyManagement.API.DTOs
{
    public class PolicyDTO
    {
        [Required(ErrorMessage = "Policy Number is required.")]
        public string PolicyNumber { get; set; } = string.Empty;
        [Required(ErrorMessage = "Policy Holder Name is required.")]
        public string PolicyHolderName { get; set; } = string.Empty;
        [Required(ErrorMessage = "DateTime StartDate is required.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "DateTime EndDate is required.")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = " Premium is required.")]
        public decimal Premium { get; set; }
    }
}
