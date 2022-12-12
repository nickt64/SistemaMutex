using Shared.Dtos;
using Shared.Models;
using Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    //mapeos
    public class Mapper
    {
        public static void NuevaEntidadDtoToEntidad(EntidadJsonDto nuevaEntidad, string repEntidad, bool decJurada, Entidad entidad)
        {
            entidad.Id = long.Parse(nuevaEntidad.CUIT);
            entidad.Matricula = nuevaEntidad.Matricula;
            entidad.Nombre = nuevaEntidad.Nombre;
            entidad.Provincia = nuevaEntidad.Provincia;
            entidad.Direccion = nuevaEntidad.Direccion;
            entidad.Localidad = nuevaEntidad.Localidad;
            entidad.Partido_Depto = nuevaEntidad.Partido_Depto;
            entidad.Codigo_Postal = nuevaEntidad.Codigo_Postal;
            entidad.EMail = nuevaEntidad.EMail;
            entidad.Telefono = nuevaEntidad.Telefono;
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

            entidadDto.Id = entidad.Id;
            entidadDto.CUIT = entidad.CUIT;
            entidadDto.Matricula = entidad.Matricula;
            entidadDto.DecJurada = entidad.DecJurada;
            entidadDto.Nombre = entidad.Nombre;
            entidadDto.Provincia = entidad.Provincia;
            entidadDto.Direccion = entidad.Direccion;
            entidadDto.Localidad = entidad.Localidad;
            entidadDto.Partido_Depto = entidad.Partido_Depto;
            entidadDto.RepEntidad = entidad.RepEntidad;
            entidadDto.Codigo_Postal = entidad.Codigo_Postal;
            entidadDto.EMail = entidad.EMail;
            entidadDto.Telefono = entidad.Telefono;
            entidadDto.Tipo_Entidad = entidad.Tipo_Entidad;
            entidadDto.Fecha_Inscripcion = entidad.Fecha_Inscripcion;
            entidadDto.Actividad = entidad.Actividad;
            entidadDto.Estado = entidad.Estado;

            return entidadDto;
        }

        public static EntidadJsonDto EntidadToEntidadJSON(EntidadDto entidad)
        {
            EntidadJsonDto entidadJSON = new EntidadJsonDto();

            entidadJSON.Matricula = entidad.Matricula;
            entidadJSON.Nombre = entidad.Nombre;
            entidadJSON.Provincia = entidad.Provincia;
            entidadJSON.Direccion = entidad.Direccion;
            entidadJSON.Localidad = entidad.Localidad;
            entidadJSON.Partido_Depto = entidad.Partido_Depto;
            entidadJSON.Codigo_Postal = entidad.Codigo_Postal;
            entidadJSON.EMail = entidad.EMail;
            entidadJSON.Telefono = entidad.Telefono;
            entidadJSON.CUIT = entidad.CUIT;
            entidadJSON.Tipo_Entidad = entidad.Tipo_Entidad;
            entidadJSON.Fecha_Inscripcion = entidad.Fecha_Inscripcion;
            entidadJSON.Actividad = entidad.Actividad;
            entidadJSON.Estado = entidad.Estado;

            return entidadJSON;
        }

        public static EntidadEdicionVM EntidadDtoToEntidadEdicionVM(EntidadDto entidadDto)
        {
            EntidadEdicionVM entidadEdicionVM = new EntidadEdicionVM();
            entidadEdicionVM.Id = entidadDto.Id;
            entidadEdicionVM.RepresentanteEntidad = entidadDto.RepEntidad;
            entidadEdicionVM.DecJurada = entidadDto.DecJurada;
            entidadEdicionVM.EntidadJson = EntidadToEntidadJSON(entidadDto);

            return entidadEdicionVM;
        }

        public static void EntidadDtoDtoToEntidad(EntidadDto entidadDto, Entidad entidad)
        {
            entidad.Id = entidadDto.Id;
            entidad.CUIT = entidadDto.CUIT;
            entidad.Matricula = entidadDto.Matricula;
            entidad.DecJurada = entidadDto.DecJurada;
            entidad.Nombre = entidadDto.Nombre;
            entidad.Provincia = entidadDto.Provincia;
            entidad.Direccion = entidadDto.Direccion;
            entidad.Localidad = entidadDto.Localidad;
            entidad.Partido_Depto = entidadDto.Partido_Depto;
            entidad.RepEntidad = entidadDto.RepEntidad;
            entidad.Codigo_Postal = entidadDto.Codigo_Postal;
            entidad.EMail = entidadDto.EMail;
            entidad.Telefono = entidadDto.Telefono;
            entidad.Tipo_Entidad = entidadDto.Tipo_Entidad;
            entidad.Fecha_Inscripcion = entidadDto.Fecha_Inscripcion;
            entidad.Actividad = entidadDto.Actividad;
            entidad.Estado = entidadDto.Estado;
        }

        public static void NuevoLibroDtoToLibro(NuevoLibroDto nuevolibro, Libro libro)
        {
            libro.Name = nuevolibro.Name;
            libro.TipoLibro = nuevolibro.TipoLibro;
            libro.MedioAlmacenamiento = nuevolibro.MedioAlmacenamiento;
            libro.NumTomo = nuevolibro.NumTomo;
            libro.CantFojas = nuevolibro.CantFojas;
            libro.Autorizado = nuevolibro.Autorizado;
            libro.EntidadId = nuevolibro.EntidadId;
           // libro.Entidad = nuevolibro.Entidad;
           // libro.Rubricas = nuevolibro.Rubricas;

        }

        public static LibroDto LibroToLibroDto(Libro libro)
        {
            LibroDto libroDto = new LibroDto();

            libroDto.Id = libro.Id;
            libroDto.Name = libro.Name;
            libroDto.TipoLibro = libro.TipoLibro;
            libroDto.MedioAlmacenamiento = libro.MedioAlmacenamiento;
            libroDto.NumTomo = libro.NumTomo;
            libroDto.CantFojas = libro.CantFojas;
            libroDto.Autorizado = libro.Autorizado;
            libroDto.Entidad = libro.Entidad;
            libroDto.EntidadId = libro.EntidadId;
           // libro.Entidad.Nombre = libroDto.Entidad.Nombre;

            return libroDto;
        }

        public static void LibroDtoToLibro(LibroDto libroDto, Libro libro)
        {

            libro.Id = libroDto.Id;
            libro.Name = libroDto.Name;
            libro.TipoLibro = libroDto.TipoLibro;
            libro.MedioAlmacenamiento = libroDto.MedioAlmacenamiento;
            libro.NumTomo = libroDto.NumTomo;
            libro.CantFojas = libroDto.CantFojas;
            libro.Autorizado = libroDto.Autorizado;
            libro.EntidadId = libroDto.EntidadId;
            libro.Eliminado = libroDto.Eliminado;

        }


    }
}
