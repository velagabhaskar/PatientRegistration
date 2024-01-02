using Microsoft.EntityFrameworkCore;
using PatientInfo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfo.DAL
{
    public class PatientDataContext:DbContext
    {
        public PatientDataContext(DbContextOptions<PatientDataContext> options) :
            base(options)
        { }
      public  DbSet<Patient> Patients { get; set; }
      public  DbSet<LogEntry> LogEntries { get; set; }
    }
}
