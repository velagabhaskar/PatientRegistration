using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientInfo.API.DTO;
using PatientInfo.DAL;
using PatientInfo.DAL.Models;

namespace PatientInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMapper _mapper;
        IPatientRepository _PatientRepository { get; set; }
        public PatientsController(IPatientRepository patientRepository, IMapper mapper)
        {
            _PatientRepository = patientRepository;
            _mapper = mapper;

        }

        [HttpPost("AddPatient")]     
        public async Task<bool> AddPatinet(DTOPatient dTOPatient)
        {
           DAL.Models.Patient  patient = _mapper.Map < DAL.Models.Patient > (dTOPatient);

             return await     _PatientRepository.AddPatinet(patient);
          
        }

        [HttpPut("UpdatePatient")]        
        public async Task<bool> UpdatePatinet(DTOPatient dTOPatient)

        { 
         DAL.Models.Patient patient = _mapper.Map<DAL.Models.Patient>(dTOPatient);


            return await _PatientRepository.UpdatePatinet(patient);
        }
        [HttpDelete("DeletePatient/{patientID}")]
        public async Task<bool> DeletePatient(int patientID)
        {
            return await _PatientRepository.DeletePatient(patientID);
        }
        [HttpGet(Name ="GetPatientsList")]
        public async Task<IEnumerable<DTOPatient>> GetAllPatients()
        {

            IEnumerable<DAL.Models.Patient> patients= await _PatientRepository.GetAll();

          
            IEnumerable<DTOPatient>dtoPatients =_mapper.Map<IEnumerable<DTOPatient>>(patients);
            return dtoPatients;
        }
        [HttpGet("{patientId}")]
        public async Task<DTOPatient> Get(int patientId)
        {

            DAL.Models.Patient patient = await _PatientRepository.GetPatientbyID(patientId);
            DTOPatient dTOPatient = _mapper.Map<DTOPatient>(patient);

            return dTOPatient;
        }
    }
}
