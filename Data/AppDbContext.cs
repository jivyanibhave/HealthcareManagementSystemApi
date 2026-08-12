using HealthcareApi.Models;
using HealthcareAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Billing> Billings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Billing>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Billings)
                .HasForeignKey(b => b.PatientId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Billing>()
                .HasOne(b => b.Appointment)
                .WithMany(a => a.Billings)
                .HasForeignKey(b => b.AppointmentId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
