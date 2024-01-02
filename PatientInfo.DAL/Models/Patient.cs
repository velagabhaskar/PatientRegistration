using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfo.DAL.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set;}
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(50)]
        [Required]
        public string EmailId { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(50)]
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set;}
        public Boolean? IsDeleted { get; set; }
        [MaxLength(50)]
        public string? DeletedBy { get; set; }

    }
}
