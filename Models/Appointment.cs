using System;
using System.Collections.Generic;
using System.Text;

namespace Tendo.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient{ get; set; }
        public Diagnosis PrimaryDiagnosis { get; set; }
    }
}
