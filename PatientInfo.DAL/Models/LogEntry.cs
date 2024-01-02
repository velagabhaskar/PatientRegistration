﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfo.DAL.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
