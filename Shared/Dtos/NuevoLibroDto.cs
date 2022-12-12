using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class NuevoLibroDto
    {     
        [Required, StringLength(70)][Display(Name ="Nombre")]
        public string Name { get; set; }

        [Required, StringLength(20)][Display(Name ="Tipo de Libro")]
        public string TipoLibro { get; set; }

        [Required, StringLength(20)][Display(Name ="Medio de Almacenamiento")]
        public string MedioAlmacenamiento { get; set; }

        [Required][Display(Name ="Nro de Tomo")]
        public int NumTomo { get; set; }

        [Required][Display(Name ="Cantidad de Fojas")]
        public int CantFojas { get; set; }

        public List<Rubrica> Rubricas { get; set; }

        [Required]
        public bool Autorizado { get; set; }
        
        [Required]
        public long EntidadId { get; set; }

        public Entidad Entidad { get; set; }
    }
}
