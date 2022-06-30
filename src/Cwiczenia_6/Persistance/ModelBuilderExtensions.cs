using Cwiczenia_6.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia_6.Persistance
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var doctor1 = new Doctor { IdDoctor = 1, Email = "1@doctor.pl", FirstName = "Andrzej", LastName = "Kowalski" };
            var doctor2 = new Doctor { IdDoctor = 2, Email = "2@doctor.pl", FirstName = "Marek", LastName = "Nowak" };

            modelBuilder.Entity<Doctor>()
                .HasData(
                doctor1,
                doctor2
                );

            var medicament1 = new Medicament { IdMedicament = 1, Description = "Ból głowy", Name = "Polopirina", Type = "Tabletka" };
            var medicament2 = new Medicament { IdMedicament = 2, Description = "Gorączka", Name = "Apap", Type = "Tabletka" };

            modelBuilder.Entity<Medicament>()
                .HasData(
               medicament1,
               medicament2
                );

            var patient1 = new Patient { IdPatient = 1, Birthdate = new DateTime(1998, 6, 29), FirstName = "Krzysztof", LastName = "Dobrzyński" };
            var patient2 = new Patient { IdPatient = 2, Birthdate = new DateTime(1994, 9, 23), FirstName = "Anna", LastName = "Wojczak" };

            modelBuilder.Entity<Patient>()
                .HasData(
                patient1,
                patient2                     
                );

            var prescription1 = new Prescription { IdPrescription = 1, Date = new DateTime(2022, 8, 27), IdDoctor = doctor1.IdDoctor, DueDate = new DateTime(2022, 9, 27), IdPatient = patient1.IdPatient };
            var prescription2 = new Prescription { IdPrescription = 2, Date = new DateTime(2022, 9, 23), IdDoctor = doctor2.IdDoctor, DueDate = new DateTime(2022, 10, 23), IdPatient = patient2.IdPatient };
            modelBuilder.Entity<Prescription>()
                .HasData(
                prescription1,
                prescription2
                );

            modelBuilder.Entity<PrescriptionMedicament>()
                .HasData(
                new PrescriptionMedicament { Id = 1, Details = "1", Dose = 1, IdMedicament = medicament1.IdMedicament, IdPrescription = prescription1.IdPrescription },
                new PrescriptionMedicament { Id = 2, Details = "2", Dose = 2, IdMedicament = medicament2.IdMedicament, IdPrescription = prescription2.IdPrescription }
                );
        }
    }
}
