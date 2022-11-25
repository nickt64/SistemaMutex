using Data.Interfaces;
using Logic.Interfaces;
using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class LibroServices : ILibroServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public LibroServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AgregarLibro(NuevoLibroDto nuevoLibro)
        {

            var libro = new Libro();

            Mapper.NuevoLibroDtoToLibro(nuevoLibro, libro);

            await _unitOfWork.LibroRepository.Add(libro);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<LibroDto>> ObtenerLibros(long id)
        {
            var listaLibros = await _unitOfWork.LibroRepository.GetAllForEntidad(id);
                
            var librosDto = new List<LibroDto>();

            foreach (var libro in listaLibros)
            {

                librosDto.Add(Mapper.LibroToLibroDto(libro));
            }

            return librosDto;
        }

    }
}
