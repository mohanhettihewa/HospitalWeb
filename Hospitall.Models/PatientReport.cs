﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Models
{
    public class PatientReport
    {
        public int Id { get; set; } 
        public string Diagnose { get; set; }
       
   
        public ApplicationUser Doctor { get; set; }
      
        public ApplicationUser Patient { get; set; }
        
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; } 
    }
}
