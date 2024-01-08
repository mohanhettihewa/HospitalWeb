using Hospitall.Models;
using Hospitall.Repositories.Implementation;
using Hospitall.Utitilities;
using Hospitall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Services
{
    public class HospitalInfoService : IHospitalInfo
    {
        private IUnitOfWork _unitOfWork;

        public HospitalInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteHospital(int id)
        {
            var model=_unitOfWork.GenericRepository<Hospital>().GetBYId(id);
            _unitOfWork.GenericRepository<Hospital>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<HospitalViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm=new HospitalViewModel();

            int totalCount;
            List<HospitalViewModel> vmlist = new List<HospitalViewModel>();

            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modellist = _unitOfWork.GenericRepository<Hospital>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Hospital>().GetAll().ToList().Count;

                vmlist = ConvertToViewModelList(modellist);

            }
            catch (Exception) {

                throw;
            
            }
            var result = new PagedResult<HospitalViewModel>
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageSize = pageSize ,
                PageNumber=pageNumber

            };
            return result;  

            
        }

        public HospitalViewModel GetHospitalById(int id)
        {
            var model = _unitOfWork.GenericRepository<Hospital>().GetBYId(id);
            var vm=new HospitalViewModel(model);
            return vm;
        }

        public void InsertHospital(HospitalViewModel hospital)
        {
            var model=new HospitalViewModel().ConvertViewModel(hospital);
            _unitOfWork.GenericRepository<Hospital>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateHospital(HospitalViewModel hospital)
        {
            var model = new HospitalViewModel().ConvertViewModel(hospital);
           var modelbyid= _unitOfWork.GenericRepository<Hospital>().GetBYId(model.Id);
            modelbyid.Name = hospital.Name;
            modelbyid.City = hospital.City;
            modelbyid.PinCode = hospital.PinCode;
            modelbyid.Country = hospital.Country;
            _unitOfWork.GenericRepository<Hospital>().Update(modelbyid);
            _unitOfWork.Save();

        }

        private List<HospitalViewModel> ConvertToViewModelList(List<Hospital> modellist )
        {
            return modellist.Select(x => new HospitalViewModel(x)).ToList();
        }
    }
}
