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
    public class EntidadServices: IEntidadServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntidadServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertEntidad(NuevaEntidadDto nuevaEntidad)
        {
            var entidad = new Entidad();

            Mapper.NuevaEntidadDtoToEntidad(entidad, nuevaEntidad);

            await _unitOfWork.EntidadRepository.Add(entidad);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<NuevaEntidadDto>> BuscarEntidad(string cuit, int padron)
        {
            string Baseurl = "https://vpo3.inaes.gob.ar/Entidades/";
            
            string estado = "Vigente";

            string Padron = padron.ToString();

            string cadenaGetEntidad = "busquedaPorCooperativas" +
                    "?&Matricula=&Nombre=&Actividad=SELECCIONE+ACTIVIDAD&CodProv=-1&Partido_Depto=SELECCIONE+" +
                    $"PARTIDO%2FDEPTO&Localidad=SELECCIONE+LOCALIDAD&Tipo_Entidad=-1&Padron={padron}&Estados={estado}";

            List<NuevaEntidadDto> entidadInfo = new List<NuevaEntidadDto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync(cadenaGetEntidad);

                if (Res.IsSuccessStatusCode)
                {
                    var entidadResponse = Res.Content.ReadAsStringAsync().Result;
                    entidadInfo = JsonConvert.DeserializeObject<List<NuevaEntidadDto>>(entidadResponse);
                }
                entidadInfo =  entidadInfo.FindAll(x => x.CUIT == cuit);

                if (entidadInfo.Count() < 1)
                {
                    //caso que no encuentre entidad coincidente (mensaje "no existe una entidad vigente con ese cuit")
                    throw new Exception("no se encuentra entidad vigente con ese cuit");
                }
            }
            return entidadInfo;
        }
    }
}
