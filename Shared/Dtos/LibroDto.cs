using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class LibroDto
    {
        public  int Id { get; set; }

        [Display (Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Tipo de Libro")]
        public string TipoLibro { get; set; }

        [Display(Name = "Medio de Almacenamiento")]
        public string MedioAlmacenamiento { get; set; }

        [Display(Name = "Nro de Tomo")]
        public int NumTomo { get; set; }

        [Display(Name = "Cant. de Fojas")]
        public int CantFojas { get; set; }

        public bool Autorizado { get; set; }

        public long EntidadId { get; set; }

        public Entidad Entidad { get; set; }

        public string EntidadNombre { get; set; }

        public bool Eliminado { get; set; }

        
    }
}
