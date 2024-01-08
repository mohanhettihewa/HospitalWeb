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
    public class RoomService : IRoomService
    {

        private IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void DeleteRoom(int RoomId)
        {
            var model=_unitOfWork.GenericRepository<Room>().GetBYId(RoomId);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();
        }

        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm= new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmlist = new List<RoomViewModel>();
            try
            {

                int ExcludeRecords = (pageSize * pageNumber) - pageSize;

                var modelList = _unitOfWork.GenericRepository<Room>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;
                vmlist = ConvertModelToViewModelList(modelList);

            }
            catch(Exception) 
            {
                throw;

            }

            var result = new PagedResult<RoomViewModel>
            {
                Data = vmlist,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize



            };
            return result;
        }

        private List<RoomViewModel> ConvertModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModel(x)).ToList();
        }

        public RoomViewModel GetRoomById(int RoomId)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetBYId(RoomId);
            var vm=new RoomViewModel(model);
            return vm;
        }

        public void insertRoom(RoomViewModel Room)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetBYId(Room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = new RoomViewModel().ConverViewModel(room);
            var ModelById=_unitOfWork.GenericRepository<Room>().GetBYId(model.Id);
            ModelById.Type = room.Type;
            ModelById.RoomNumber = room.RoomNumber;
            ModelById.Status = room.Status;
            ModelById.HospitalId = room.HospitalInfoId;
            _unitOfWork.GenericRepository<Room>().Update(ModelById);
            _unitOfWork.Save();
        }
    }
}
