using System.ComponentModel.DataAnnotations;

namespace HealthcareApi.Services.DTOs.Billing
{
    public class CreateBillingDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [Required]
        public decimal ConsultationFee { get; set; }

        [Required]
        public decimal MedicineFee { get; set; }

        [Required]
        public decimal LabFee { get; set; }

        public decimal Discount { get; set; }

        public decimal GST { get; set; }

        //public decimal TotalAmount { get; set; }

        public string PaymentStatus { get; set; } = "Pending";
    }
}


