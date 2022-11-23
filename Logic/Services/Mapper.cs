using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class Mapper
    {//mapeo  de 
        public static void NuevaEntidadDtoToEntidad(EntidadJSON nuevaEntidad, string repEntidad, bool decJurada, Entidad entidad)
        {
            entidad.Id = long.Parse(nuevaEntidad.CUIT); 
            entidad.Matricula = nuevaEntidad.Matricula;
            entidad.Nombre = nuevaEntidad.Nombre;
            entidad.Provincia = nuevaEntidad.Provincia;
            entidad.Direccion = nuevaEntidad.Direccion;
            entidad.Localidad = nuevaEntidad.Localidad;
            entidad.Partido_depto = nuevaEntidad.Partido_Depto;
            
            entidad.codigo_postal = nuevaEntidad.Codigo_Postal;
            entidad.Email = nuevaEntidad.EMail;
            entidad.telefono = nuevaEntidad.Telefono;
            entidad.CUIT = nuevaEntidad.CUIT;
            entidad.Tipo_Entidad = nuevaEntidad.Tipo_Entidad;
            entidad.Fecha_Inscripcion = nuevaEntidad.Fecha_Inscripcion;
            entidad.Actividad = nuevaEntidad.Actividad;
            entidad.Estado = nuevaEntidad.Estado;

            entidad.DecJurada = decJurada;
            entidad.RepEntidad = repEntidad;



        }

        public static EntidadDto EntidadToEntidadDto(Entidad entidad)
        {
            EntidadDto entidadDto = new EntidadDto();

            entidadDto.CUIT = entidad.CUIT;
            entidadDto.Matricula = entidad.Matricula;
            entidadDto.Nombre = entidad.Nombre;
            entidadDto.RepEntidad = entidad.RepEntidad;
            entidadDto.Email = entidad.Email;
            entidadDto.telefono = entidad.telefono;

            return entidadDto;
        }
    }
}
