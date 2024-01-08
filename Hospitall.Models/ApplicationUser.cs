using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospitall.Models
{
    public  class ApplicationUser: IdentityUser 
    {
        public string Name { get; set; }    

        public Gender Gender { get; set; }  
        public string Nationality { get; set; }
        public string Adddress { get; set; }
        public DateTime DOB { get; set; }
        public string Specialist { get; set; }
        public Department Department { get; set; }
        [NotMapped]
        public ICollection<Appointment> Apppintments { get; set; }
        [NotMapped]
        public ICollection<Payroll> Payrolls { get; set; }
    }
}

namespace Hospitall.Models
{
    public enum Gender
    {
        Female,Male,Other
    }
}