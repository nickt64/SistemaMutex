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
        Task AgregarLibro(NuevoLibroDto nuevoLibro);

        public Task<List<LibroDto>> ObtenerLibros(long id);

    }
}
