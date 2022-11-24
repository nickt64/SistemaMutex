using Logic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
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

                //List<EntidadDto> listaEntidades = await _entidadServices.GetEntidades();


                return View();
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
                var entidadInfo = await _entidadServices.BuscarEntidad(entidadIndexVMs.cuit, entidadIndexVMs.padron);

                var entidadInsercionVM = new EntidadInsercionVM(entidadInfo, entidadIndexVMs.decJurada, entidadIndexVMs.repEntidad);



                return View(entidadInsercionVM);
            }catch (Exception e)
            {
               return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(EntidadInsercionVM entidadInsercionVM)
        {
            try
            {
                await _entidadServices.InsertEntidad(entidadInsercionVM.EntidadJson, entidadInsercionVM.RepresentanteEntidad, entidadInsercionVM.DecJurada);
               
                
                return View("index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
            
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

                List<EntidadJSON> entidadJson = new List<EntidadJSON>();
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
