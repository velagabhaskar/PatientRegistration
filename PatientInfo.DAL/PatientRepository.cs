using PatientInfo.DAL.Models;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
namespace PatientInfo.DAL
{
    public class PatientRepository :IPatientRepository
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientRepository(IRepository<Patient> patientRepository) 
        {
            _patientRepository= patientRepository;
        }

        public async Task<bool> AddPatinet(Patient patient)
        {
            var patientslist = await _patientRepository.Find(p => p.FirstName == patient.FirstName && p.LastName == patient.LastName && p.DateofBirth == patient.DateofBirth && p.EmailId == patient.EmailId);

            if (patientslist.ToList().Count>0)
                return false;
      

            else
                return await _patientRepository.Add(patient);

        }

        public async Task<bool> DeletePatient(int patientId)
        {
            Patient patient = await  _patientRepository.GetbyId(patientId);
            if (patient!=null)
            {
                patient.IsDeleted = true;
            }
            return await _patientRepository.Delete(patient);
        }

       

        public async Task<List<Patient>> GetAll()
        {

            List<Patient>? patients =  _patientRepository.GetAll().Result?.Where(result=> result.IsDeleted==null||result.IsDeleted==false)?.ToList();
          return    patients ;
        }

        public Task<bool> UpdatePatinet(Patient patient)
        {
            return _patientRepository.Update(patient);

        }
        public Task<Patient>GetPatientbyID(int patientId)
        {
            return _patientRepository.GetbyId(patientId);
        }

       
    }
}
