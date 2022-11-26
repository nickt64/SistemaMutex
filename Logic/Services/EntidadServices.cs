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


        
        public async Task InsertEntidad(EntidadJsonDto entidadJsonDto, string repEntidad, bool decJurada)
        {
            var entidad = new Entidad();

            Mapper.NuevaEntidadDtoToEntidad(entidadJsonDto, repEntidad, decJurada, entidad);

            await _unitOfWork.EntidadRepository.Add(entidad);

            await _unitOfWork.SaveChangesAsync();

        }


        public async Task<EntidadJsonDto> BuscarEntidad(string cuit, int padron)
        {
            string Baseurl = "https://vpo3.inaes.gob.ar/Entidades/";

            string estado = "Vigente";

            string Padron = padron.ToString();

            string cadenaGetEntidad = "busquedaPorCooperativas" +
                    "?&Matricula=&Nombre=&Actividad=SELECCIONE+ACTIVIDAD&CodProv=-1&Partido_Depto=SELECCIONE+" +
                    $"PARTIDO%2FDEPTO&Localidad=SELECCIONE+LOCALIDAD&Tipo_Entidad=-1&Padron={padron}&Estados={estado}";

            List<EntidadJsonDto> entidadesInfo = new List<EntidadJsonDto>();

            var entidadInfo = new EntidadJsonDto();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync(cadenaGetEntidad);

                if (Res.IsSuccessStatusCode)
                {
                    var entidadResponse = Res.Content.ReadAsStringAsync().Result;
                    entidadesInfo = JsonConvert.DeserializeObject<List<EntidadJsonDto>>(entidadResponse);
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

        public async Task<List<EntidadDto>> GetEntidades()
        {
            List<EntidadDto> listaEntidades = new List<EntidadDto>();

            List<Entidad> getAllEntidades = await _unitOfWork.EntidadRepository.ObtenerPorEstado(false);

            foreach (var entidad in getAllEntidades)
            {
                listaEntidades.Add(Mapper.EntidadToEntidadDto(entidad));

            }

            return listaEntidades;
        }

        public async Task<EntidadDto> GetById(long entidadId)
        {
            try
            {
                Entidad entidad = await _unitOfWork.EntidadRepository.GetById(entidadId);

                
                var entidadDto = Mapper.EntidadToEntidadDto(entidad); 

                return entidadDto;
            }
            catch
            {
                throw new NotImplementedException("no se encuentra entidad seleccionada");

            }

        }


        public async Task ActualizarEntidad(EntidadDto entidadDto)
        {
            var entidad = await _unitOfWork.EntidadRepository.GetById(entidadDto.Id);

            if (entidad == null)
            {
                throw new Exception("Usuario no existe con el ID: " + entidad.Id);
            }

            Mapper.EntidadDtoDtoToEntidad(entidadDto, entidad);

            _unitOfWork.EntidadRepository.Update(entidad);
            await _unitOfWork.SaveChangesAsync();

        }
        
        public async Task EliminarEntidad(long id)
        {
            var entidad = await _unitOfWork.EntidadRepository.GetById(id);

            if (entidad == null || entidad.Eliminado == true)
            {
                throw new Exception("Entidad dada de baja con el CUIT: " + id);
            }

            _unitOfWork.EntidadRepository.Delete(entidad);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
