using Cwiczenia_6.DAL;
using Cwiczenia_6.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia_6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicServices _clinicServices;

        public ClinicController(IClinicServices clinicServices)
        {
            _clinicServices = clinicServices;
        }   
        
        [HttpGet]
        public IEnumerable<DoctorDto> GetDoctors()
        {
            return _clinicServices.GetDoctors();
        }

        [HttpPost]
        public IActionResult AddDoctor([FromBody] DoctorDto dto)
        {
            if (_clinicServices.DoctorExists(dto.IdDoctor))
            {
                throw new ArgumentException("Doctor already exists");
            }
            
            _clinicServices.AddDoctor(dto);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateDoctor([FromBody] DoctorDto dto)
        {
            if (!_clinicServices.DoctorExists(dto.IdDoctor))
            {
                throw new ArgumentException("Doctor not exists");
            }

            _clinicServices.UpdateDoctor(dto);

            return Ok();
        }

        [HttpDelete]
        [Route("{idDoctor}")]
        public IActionResult DeleteDoctor(int idDoctor)
        {
            if (!_clinicServices.DoctorExists(idDoctor))
            {
                throw new ArgumentException("Doctor not exists");
            }

            _clinicServices.DeleteDoctor(idDoctor);
            return Ok();
        }

        [HttpGet]
        [Route("prescription/{idPrescription}")]
        public IActionResult GetPrescriptionDetails(int idPrescription)
        {
            if (!_clinicServices.PrescriptionExists(idPrescription))
            {
                throw new ArgumentException("Prescriptoin not exists");
            }

            return Ok(_clinicServices.GetPrescription(idPrescription));
        }
    }
}