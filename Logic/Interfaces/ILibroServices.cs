using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface ILibroServices
    {
        Task AgregarLibro(NuevoLibroDto nuevoLibroDto);

        public Task<List<LibroDto>> ObtenerLibros(long id);

        public Task<LibroDto> GetById(int libroId);

        public Task ActualizarLibro(LibroDto libroDto);

        public Task BorrarLibro(int Id);



    }
}
