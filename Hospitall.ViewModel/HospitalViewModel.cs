using Hospitall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.ViewModels
{
    public class HospitalViewModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }


        public HospitalViewModel()
        {
                
        }
        public HospitalViewModel(Hospital model)
        {
                Id=model.Id;
              Name=model.Name;
            Type=model.Type;
            City=model.City;
            Country=model.Country;
            PinCode=model.PinCode;

        }
        public Hospital ConvertViewModel(HospitalViewModel model)
        {

            return new Hospital{ 
            Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                    
                Country = model.Country,
                PinCode = model.PinCode
                    
                };
            
        }

    }
}
