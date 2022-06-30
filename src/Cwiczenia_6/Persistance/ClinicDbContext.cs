using Cwiczenia_6.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia_6.Persistance
{
    public class ClinicDbContext : DbContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasKey(x => x.IdDoctor);
            modelBuilder.Entity<Medicament>().HasKey(x => x.IdMedicament);
            modelBuilder.Entity<Patient>().HasKey(x => x.IdPatient);
            modelBuilder.Entity<Prescription>().HasKey(x => x.IdPrescription);
            modelBuilder.Entity<PrescriptionMedicament>().HasKey(x => x.Id);
            

            modelBuilder.Entity<Medicament>()
                .HasMany(p => p.Prescription_Medicaments)
                .WithOne(p => p.Medicament)
                .HasForeignKey(p => p.IdMedicament);

            modelBuilder.Entity<Doctor>()
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.IdDoctor);

            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.PrescriptionMedicaments)
                .WithOne(p => p.Prescription)
                .HasForeignKey(p => p.IdPrescription);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.IdPatient);

            modelBuilder.Seed();
        }
    }
}
