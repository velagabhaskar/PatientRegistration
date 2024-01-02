using AutoMapper;
using PatientInfo.API.DTO;

namespace PatientInfo.API.Helper
{
    public class ApplicationMapper:Profile
    {
        public ApplicationMapper()
        {
            CreateMap<PatientInfo.DAL.Models.Patient, DTOPatient>();
            CreateMap< DTOPatient, PatientInfo.DAL.Models.Patient>();
        }
    }
}
