using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class CreacionLibroVM
    {
        public List<LibroDto> listaLibros { get; set; }

        public long EntidadId { get; set; }
    }
}
