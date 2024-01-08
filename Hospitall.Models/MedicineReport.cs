using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Models
{
    public class MedicineReport
    {
        public int Id { get; set; } 
        public Supplier Supplier { get; set; }
        public Medicine Medicine { get; set; }
        public string Company {  get; set; }
        public int Quantity { get; set; }

        public DateTime ProductioinDate { get; set; }
        public DateTime ExpiredDate { get; set; }   
        public string Country {  get; set; }
        







    }
}
