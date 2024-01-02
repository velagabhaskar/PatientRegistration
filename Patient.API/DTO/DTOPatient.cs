using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace PatientInfo.API.DTO
{
    public class DTOPatient
    { 
        public int PatientID { get; set; } 
        public string FirstName { get; set; }     

        public string LastName { get; set; }     

        public string EmailId { get; set; }
        public DateTime DateofBirth { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Boolean? IsDeleted { get; set; }
        public string? DeletedBy { get; set; }
        public DTOPatient()
        {
          
          
        }
    }
    
}
