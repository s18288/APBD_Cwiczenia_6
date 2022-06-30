using Cwiczenia_6.Dtos;

namespace Cwiczenia_6.DAL
{
    public interface IClinicServices
    {
        bool DoctorExists(int idDoctor);
        void AddDoctor(DoctorDto dto);
        void UpdateDoctor(DoctorDto dto);
        void DeleteDoctor(int idDoctor);
        IEnumerable<DoctorDto> GetDoctors();
        bool PrescriptionExists(int idPrescription);
        PrescriptionDetailsDto GetPrescription(int idPrescription);
    }
}
