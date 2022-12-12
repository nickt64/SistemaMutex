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

        public async Task<LibroDto> GetById(int libroId)
        {
            try
            {
                Libro libro = await _unitOfWork.LibroRepository.GetById(libroId);

                if (libroId != libro.Id)
                {
                    throw new Exception("el numero de cuit no puede ser modificado");
                }

                var libroDto = Mapper.LibroToLibroDto(libro);

                return libroDto;
            }
            catch
            {
                throw new NotImplementedException("no se encuentra entidad seleccionada");

            }

        }

        public async Task ActualizarLibro(LibroDto libroDto)
        {
            var libro = await _unitOfWork.LibroRepository.GetById(libroDto.Id);

            Mapper.LibroDtoToLibro(libroDto, libro);

            _unitOfWork.LibroRepository.Update(libro);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task BorrarLibro(int Id)
        {

            _unitOfWork.LibroRepository.Delete(
                                              await _unitOfWork.LibroRepository.GetById(Id) );

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
