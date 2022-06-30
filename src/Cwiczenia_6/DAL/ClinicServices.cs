using Cwiczenia_6.Dtos;
using Cwiczenia_6.Entities;
using Cwiczenia_6.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenia_6.DAL
{
    public class ClinicServices : IClinicServices
    {
        private readonly ClinicDbContext _context;

        public ClinicServices(ClinicDbContext context)
        {
            _context = context;
        }

        public void AddDoctor(DoctorDto dto)
        {
            var doctor = new Doctor
            {
                LastName = dto.LastName,
                FirstName = dto.FirstName,
                Email = dto.Email,
                IdDoctor = dto.IdDoctor
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(int idDoctor)
        {
            var doctor = _context.Doctors.First(x => x.IdDoctor == idDoctor);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public bool DoctorExists(int idDoctor)
        {
            return _context.Doctors.Any(x => x.IdDoctor == idDoctor);
        }

        public IEnumerable<DoctorDto> GetDoctors()
        {
            return _context.Doctors.Select(x => new DoctorDto
            {
                IdDoctor = x.IdDoctor,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            });
        }

        public PrescriptionDetailsDto GetPrescription(int idPrescription)
        {
            var prescription = _context.Prescriptions
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .Include(x => x.PrescriptionMedicaments)
                .FirstOrDefault(x => x.IdPrescription == idPrescription);

            var presMed = _context.PrescriptionMedicaments
                .Include(x => x.Medicament)
                .ToList()
                .Where(x => prescription.PrescriptionMedicaments.Any(pm => pm.Id == x.Id))
                .ToList();

            var dto = new PrescriptionDetailsDto
            {
                DoctorEmail = prescription.Doctor.Email,
                DoctorFirstName = prescription.Doctor.FirstName,
                DoctorLastName = prescription.Doctor.LastName,  
                IdDoctor = prescription.IdDoctor,
                IdPatient = prescription.IdPatient,
                PatientBirthdate = prescription.Patient.Birthdate,
                PatientFirstName = prescription.Patient.FirstName,
                PatientLastName = prescription.Patient.LastName,
                PrescriptionMedicamentDetails = presMed.Select(x => new PrescriptionMedicamentDetailsDto
                {
                    Description = x.Medicament.Description,
                    IdMedicament = x.IdMedicament,
                    IdPrescriptionMedicament = x.Id,
                    Name = x.Medicament.Name,
                    Type = x.Medicament.Type,
                }).ToList(),
            };

            return dto;
        }

        public bool PrescriptionExists(int idPrescription)
        {
            return _context.Prescriptions.Any(x => x.IdPrescription == idPrescription);
        }

        public void UpdateDoctor(DoctorDto dto)
        {
            var doctor = _context.Doctors.First(x => x.IdDoctor == dto.IdDoctor);
            
            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;
            doctor.Email = dto.Email;

            _context.SaveChanges();
        }
    }
}
