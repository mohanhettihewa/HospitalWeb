using Hospitall.Services;
using Hospitall.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospitall.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HospitalInfoController : Controller
    {

        private IHospitalInfo _hospitalInfo;

        public HospitalInfoController(IHospitalInfo hospitalInfo)
        {
            _hospitalInfo = hospitalInfo;
        }

     


        public IActionResult Index(int pageNumber=1, int pageSize=10) {
        
        
        return View(_hospitalInfo.GetAll(pageNumber,pageSize));
        }


        //public ActionResult <IEnumerable<HospitalViewModel>> Index()
        //{
        //    return View(new List<HospitalViewModel>());
        //}

        [HttpGet]
        public IActionResult Edit(int Id)
        {

            var viewModel=_hospitalInfo.GetHospitalById(Id);
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(HospitalViewModel vm)
        {

            _hospitalInfo.UpdateHospital(vm);   
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult Create() {
        
        return View();  
        }


        [HttpPost]
        public IActionResult Create(HospitalViewModel vm)
        {
            _hospitalInfo.InsertHospital(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {

            _hospitalInfo.DeleteHospital(id);
            return RedirectToAction("Index");
        }

    }
}
