using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaMutex.Controllers
{
    public class LibroController : Controller
    {
        private ILibroServices _libroservices;

        public LibroController(ILibroServices libroServices)
        {
            _libroservices = libroServices;
        }
       


        public  IActionResult Index()
        {

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ListadoLibros(long id)
        {
            try
            {
                List<LibroDto> libroDtoList = await _libroservices.ObtenerLibros(id);



                return View(libroDtoList);
            }
            catch(Exception e)
            {
                return RedirectToAction("Entidades", "Entidad");
            }
        }

        [HttpGet]
        public IActionResult CrearLibro(NuevoLibroDto nuevoLibro)
        {

            return View();
        }

        /*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearLibro()
        {


            RedirectToAction("ListadoLibros");
        }
        */
    }
}
