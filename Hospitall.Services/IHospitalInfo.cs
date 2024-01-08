using Hospitall.Models;
using Hospitall.Utitilities;
using Hospitall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Services
{
    public interface IHospitalInfo
    {
        PagedResult<HospitalViewModel> GetAll(int pageNumber,int pageSize);
        HospitalViewModel GetHospitalById(int id);  
        void UpdateHospital(HospitalViewModel hospital);
        void InsertHospital(HospitalViewModel hospital);
        void DeleteHospital(int id);
    }
}
