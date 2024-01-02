using PatientInfo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfo.DAL
{
    public interface IPatientRepository
    {
        Task<bool> AddPatinet(Patient patient);
        Task<bool> UpdatePatinet(Patient patient);
        Task <List<Patient>> GetAll();
        Task<Patient> GetPatientbyID(int patientId);
        Task<bool> DeletePatient(int patientId);
     
    }
}
