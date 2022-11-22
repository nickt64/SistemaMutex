using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SistemaMutex.Controllers
{
    //mutual / cooperativa
    public class EntidadController : Controller
    {
        private IEntidadServices _entidadServices;

        public EntidadController(IEntidadServices entidadServices)
        {
            _entidadServices = entidadServices;
        }

        public IActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("index");
            }

        }
    }
}
