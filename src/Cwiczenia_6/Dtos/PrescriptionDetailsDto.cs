namespace Cwiczenia_6.Dtos
{
    public class PrescriptionDetailsDto
    {
        public int IdDoctor { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public string DoctorEmail { get; set; }
        public int IdPatient { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthdate { get; set; }

        public ICollection<PrescriptionMedicamentDetailsDto> PrescriptionMedicamentDetails { get; set; }
    }
}
