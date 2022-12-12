using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaMutex.Controllers
{
    public class LibroController : Controller
    {
        private ILibroServices _libroservices;
        private IEntidadServices _entidadServices;

        public LibroController(ILibroServices libroServices, IEntidadServices entidadServices)
        {
            _libroservices = libroServices;
            _entidadServices = entidadServices;
        }



        public IActionResult Index()
        {

            return View();
        }


        [HttpGet("ListadoLibros/{id:long?}")]
        public async Task<IActionResult> ListadoLibros(long? id)
        {
            try
            {
                if (id == 0 || id == null)
                {
                    TempData["mensaje"] = "No ha seleccionado ninguna entidad";
                    return RedirectToAction("entidades", "entidad");
                }
                List<LibroDto> libroDtoList = await _libroservices.ObtenerLibros((long)id);

                CreacionLibroVM viewModel = new CreacionLibroVM()
                {
                    listaLibros = libroDtoList,
                    EntidadId = (long)id,

                };

                return View(viewModel);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Entidades", "Entidad");
            }
        }

        [HttpGet]
        public IActionResult CrearLibro(long id)
        {
            ViewBag.nuevoLibroDto = id;


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearLibro(NuevoLibroDto nuevoLibroDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View();
                }
                await _libroservices.AgregarLibro(nuevoLibroDto);

                //long? id = nuevoLibroDto.EntidadId;
                string idStr = ((long?)nuevoLibroDto.EntidadId).ToString();

                TempData["mensaje"] = "el libro se ha cargado con exito";
                return Redirect("/listadoLibros/" + idStr);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message + e.Source;
                return RedirectToAction("ListadoLibros");
            }
        }


        [HttpGet]
        public async Task<IActionResult> UpdateLibro(int? id)
        {
            try
            {
                if (id == 0 || id == null)
                {
                    TempData["mensaje"] = "Identificador incorrecto o nulo";
                    return RedirectToAction("Entidades");
                }

                LibroDto libroDto = await _libroservices.GetById((int)id);

                return View(libroDto);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Entidades");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateLibro(LibroDto libroDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    //retornar misma vista con validaciones 
                    //agregar validaciones 
                    return View();
                }
                await _libroservices.ActualizarLibro(libroDto);

                string idStr = (libroDto.EntidadId).ToString();

                return Redirect("/ListadoLibros/" + idStr);

            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
            }

            return RedirectToAction("Index");
        }


        //metodo borrar libro
        [HttpGet]
        public async Task<IActionResult> DeleteLibro(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {

                }
                var libroBorrar = await _libroservices.GetById((int)id);

                return View(libroBorrar);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var libroBorrar = await _libroservices.GetById(id);

                string idStr = (libroBorrar.EntidadId).ToString();

                await _libroservices.BorrarLibro(id);

                

                return Redirect("/ListadoLibros/" + idStr);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
