using Data.Interfaces;
using Logic.Interfaces;
using Newtonsoft.Json;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class EntidadServices : IEntidadServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntidadServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task InsertEntidad(EntidadJSON nuevaEntidad, string repEntidad, bool decJurada)
        {
            var entidad = new Entidad();

            Mapper.NuevaEntidadDtoToEntidad(nuevaEntidad, repEntidad, decJurada, entidad);
            
            await _unitOfWork.EntidadRepository.Add(entidad);
            await _unitOfWork.SaveChangesAsync();

        }


        public async Task<EntidadJSON> BuscarEntidad(string cuit, int padron)
        {
            string Baseurl = "https://vpo3.inaes.gob.ar/Entidades/";

            string estado = "Vigente";

            string Padron = padron.ToString();

            string cadenaGetEntidad = "busquedaPorCooperativas" +
                    "?&Matricula=&Nombre=&Actividad=SELECCIONE+ACTIVIDAD&CodProv=-1&Partido_Depto=SELECCIONE+" +
                    $"PARTIDO%2FDEPTO&Localidad=SELECCIONE+LOCALIDAD&Tipo_Entidad=-1&Padron={padron}&Estados={estado}";

            List<EntidadJSON> entidadesInfo = new List<EntidadJSON>();

            var entidadInfo = new EntidadJSON();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync(cadenaGetEntidad);

                if (Res.IsSuccessStatusCode)
                {
                    var entidadResponse = Res.Content.ReadAsStringAsync().Result;
                    entidadesInfo = JsonConvert.DeserializeObject<List<EntidadJSON>>(entidadResponse);
                }




                entidadInfo = entidadesInfo.FirstOrDefault(x => x.CUIT == cuit);

                if (entidadInfo == null)
                {
                    //caso que no encuentre entidad coincidente (mensaje "no existe una entidad vigente con ese cuit")
                    throw new Exception("no se encuentra entidad vigente con ese cuit");
                }
            }
            return entidadInfo;
        }

        async Task<List<EntidadDto>> IEntidadServices.GetEntidades()
        {
            List<EntidadDto> listaEntidades = new List<EntidadDto>();

            List<Entidad> getAllEntidades = await _unitOfWork.EntidadRepository.GetAll();

            foreach (var entidad in getAllEntidades)
            {
                listaEntidades.Add(Mapper.EntidadToEntidadDto(entidad));

            }

            return listaEntidades;
        }


    }
}
