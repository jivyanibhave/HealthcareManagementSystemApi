namespace HealthcareApi.Services.DTOs.Billing
{
    public class BillingResponseDto
    {
        public int BillId { get; set; }

        public int PatientId { get; set; }

        public int AppointmentId { get; set; }

        public decimal ConsultationFee { get; set; }

        public decimal MedicineFee { get; set; }

        public decimal LabFee { get; set; }

        public decimal Discount { get; set; }

        public decimal GST { get; set; }

        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;

    }
}
