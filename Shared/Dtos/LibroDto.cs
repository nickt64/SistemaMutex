using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class LibroDto
    {
        public  int Id { get; set; }

        public string Name { get; set; }

        public string TipoLibro { get; set; }

        public string MedioAlmacenamiento { get; set; }

        public int NumTomo { get; set; }

        public int CantFojas { get; set; }

        public bool Autorizado { get; set; }

        public long EntidadId { get; set; }

        public Entidad Entidad { get; set; }

        public bool Eliminado { get; set; }

        
    }
}
