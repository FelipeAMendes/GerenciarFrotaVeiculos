using ManageFleet.Application.Interfaces;
using ManageFleet.Application.ViewModels;
using ManageFleet.Infra.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace ManageFleet.Web.Controllers
{
    public class VehiclesController : BaseController
    {
        private readonly IVehicleAppService _vehicleAppService;
        private readonly IVehicleTypeAppService _vehicleTypeAppService;

        public VehiclesController(IVehicleAppService vehicleAppService, IVehicleTypeAppService vehicleTypeAppService)
        {
            _vehicleAppService = vehicleAppService;
            _vehicleTypeAppService = vehicleTypeAppService;
        }
        
        public IActionResult Index()
        {
            //throw new System.Exception("Ocorreu um erro!!!");//Teste
            var list = _vehicleAppService.GetAll();
            return View(list);
        }
        
        public IActionResult Details(int? id)
        {
            if (id.IsNull())
                return HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vehicleViewModel = _vehicleAppService.GetById(id.Value);

            if (vehicleViewModel.IsNull())
                return NotFound();

            return View(vehicleViewModel);
        }

        public IActionResult DetailsByChassi(string chassi)
        {
            if (chassi.IsNullOrEmpty())
                return View();

            var vehicleViewModel = _vehicleAppService.GetByChassi(chassi);

            if (vehicleViewModel.IsNull())
                return View(new VehicleListViewModel { });

            return View(vehicleViewModel);
        }

        public IActionResult Create()
        {
            AddVehicleTypesViewBag();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(VehicleViewModel vehicleViewModel)
        {
            AddVehicleTypesViewBag();
            if (!ModelState.IsValid)
                return View(vehicleViewModel);

            var vehicleViewModelResult = _vehicleAppService.Insert(vehicleViewModel);

            if (!vehicleViewModelResult.ValidationResult.IsValid)
            {
                AddTempData("Message", vehicleViewModelResult.ValidationResult.Message);
                return View(vehicleViewModel);
            }

            if (!vehicleViewModelResult.ValidationResult.Message.IsNullOrEmpty())
                AddTempData("Message", vehicleViewModelResult.ValidationResult.Message);

            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int? id)
        {
            if (id.IsNull())
                return HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vehicleViewModel = _vehicleAppService.GetByIdRegister(id.Value);

            if (vehicleViewModel.IsNull())
                return NotFound();

            AddVehicleTypesViewBag();
            return View(vehicleViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VehicleViewModel vehicleViewModel)
        {
            AddVehicleTypesViewBag();
            if (!ModelState.IsValid)
                return View(vehicleViewModel);

            var vehicleViewModelResult = _vehicleAppService.Update(vehicleViewModel);

            if (!vehicleViewModelResult.ValidationResult.IsValid)
            {
                AddTempData("Message", vehicleViewModelResult.ValidationResult.Message);
                return View(vehicleViewModel);
            }

            if (!vehicleViewModelResult.ValidationResult.Message.IsNullOrEmpty())
                AddTempData("Message", vehicleViewModelResult.ValidationResult.Message);

            return RedirectToAction("Index");
        }
        
        public IActionResult Delete(int? id)
        {
            if (id.IsNull())
                return HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var vehicle = _vehicleAppService.GetById(id.Value);

            if (vehicle.IsNull())
                return NotFound();

            return View(vehicle);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicleViewModel = _vehicleAppService.Remove(id);

            if (!vehicleViewModel.ValidationResult.Message.IsNullOrEmpty())
                AddTempData("Message", vehicleViewModel.ValidationResult.Message);

            return RedirectToAction("Index");
        }

        private void AddVehicleTypesViewBag()
        {
            ViewBag.VehicleTypes = _vehicleTypeAppService.GetAll();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _vehicleAppService.Dispose();
                _vehicleTypeAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
