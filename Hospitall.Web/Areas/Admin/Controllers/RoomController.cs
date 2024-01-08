using Hospitall.Models;
using Hospitall.Services;
using Hospitall.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospitall.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {



        private IRoomService _IRoom;

        public RoomController(IRoomService iRoom)
        {
            _IRoom = iRoom;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {


            return View(_IRoom.GetAll(pageNumber, pageSize));
        }


        //public ActionResult <IEnumerable<HospitalViewModel>> Index()
        //{
        //    return View(new List<HospitalViewModel>());
        //}

        [HttpGet]
        public IActionResult Edit(int Id)
        {

            var viewModel = _IRoom.GetRoomById(Id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {

            _IRoom.UpdateRoom(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            _IRoom.insertRoom(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            _IRoom.DeleteRoom(id);
            return RedirectToAction("Index");
        }

    }
}
