using Hospitall.Utitilities;
using Hospitall.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitall.Services
{
    public interface IRoomService
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber,int pageSize); 
        RoomViewModel GetRoomById (int RoomId);

        void UpdateRoom(RoomViewModel room);    
        void DeleteRoom(int RoomId);

        void insertRoom(RoomViewModel room);
    }
}
