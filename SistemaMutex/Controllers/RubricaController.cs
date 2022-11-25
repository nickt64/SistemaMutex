using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SistemaMutex.Controllers
{
    public class RubricaController : Controller
    {
        private IRubricaServices _rubricaServices;


        public RubricaController(IRubricaServices rubricaServices)
        {
            _rubricaServices = rubricaServices;
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
