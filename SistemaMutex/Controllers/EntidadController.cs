using Logic.Interfaces;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                return RedirectToAction("Index");
            }
        }


        [HttpGet]//listado de entidades cargadas
        public async Task<IActionResult> Entidades(string? valor)
        {
            try
            
            {

                List<EntidadDto> listaEntidades = await _entidadServices.GetEntidades();


                if (!string.IsNullOrEmpty(valor))
                {
                    listaEntidades = listaEntidades.FindAll(x => x.CUIT.Contains(valor));

                }

                return View(listaEntidades);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> CreateEntidad(EntidadIndexVM entidadIndexVMs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["mensaje"] = "Datos de carga incompletos";
                    return View("Entidades");
                }
                var entidadInfo = await _entidadServices.BuscarEntidad(entidadIndexVMs.cuit, entidadIndexVMs.padron);

                var entidadInsercionVM = new EntidadInsercionVM(entidadInfo, entidadIndexVMs.decJurada, entidadIndexVMs.repEntidad);

                return View(entidadInsercionVM);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EntidadInsercionVM entidadInsercionVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("datos invalidos");
                }

                await _entidadServices.InsertEntidad(entidadInsercionVM.EntidadJson, entidadInsercionVM.RepresentanteEntidad, entidadInsercionVM.DecJurada);

                TempData["mensaje"] = "entidad cargada con exito";
                return View("Entidades");
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public async Task<IActionResult> UpdateEntidad(long? id)
        {
            try
            {
                if (id == null)
                {
                    TempData["mensaje"] = "Identificador incorrecto o nulo";
                    return RedirectToAction("Entidades");
                }
                long Id = (long)id;

                EntidadDto entidadDto = await _entidadServices.GetById(Id);



                return View(entidadDto);
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Entidades");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEntidad(EntidadDto entidadDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _entidadServices.ActualizarEntidad(entidadDto);
                    return RedirectToAction("Entidades");
                }

                TempData["mensaje"] = "Identificador incorrecto o nulo";
                return View();



            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("entidades");
            }
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUsuario(long id)
        {
            try
            {
                await _entidadServices.EliminarEntidad(id);
                TempData["mensaje"] = "usuario eliminado correctamente";
            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
            }

            return RedirectToAction("Index");
        }
















        [HttpGet]
        public async Task<IActionResult> AddEntidad(EntidadIndexVM viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception("error carga de datos");

                }
                if (!viewModel.decJurada)
                {
                    throw new Exception("acepte declaracion jurada");
                }



                var entidadSearch = await _entidadServices.BuscarEntidad(viewModel.cuit, viewModel.padron);

                var nuevaEntidad = entidadSearch;

                List<EntidadJsonDto> entidadJson = new List<EntidadJsonDto>();
                entidadJson.Add(nuevaEntidad);
                ViewBag.EntidadBuscada = entidadJson;
                ViewBag.repEntidad = viewModel.repEntidad;
                ViewBag.decJurada = viewModel.decJurada ? "SI." : "NO";




                // await _entidadServices.InsertEntidad(nuevaEntidad, RepEntidad, DecJurada);




                return View();

            }
            catch (Exception e)
            {
                TempData["mensaje"] = e.Message;
                return RedirectToAction("Index");
            }
        }

        //public   IActionResult Create()
        //{

        //  //  await _entidadServices.InsertEntidad(nuevaEntidad, RepEntidad, DecJurada);

        //    return View("Index");
        //}

    }
}
