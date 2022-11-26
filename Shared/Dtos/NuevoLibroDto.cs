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
        [Required, StringLength(70)]
        public string Name { get; set; }

        [Required, StringLength(20)]
        public string TipoLibro { get; set; }

        [Required, StringLength(20)]
        public string MedioAlmacenamiento { get; set; }

        [Required]
        public int NumTomo { get; set; }

        [Required]
        public int CantFojas { get; set; }

        public List<Rubrica> Rubricas { get; set; }


        [Required]
        public bool Autorizado { get; set; }
        
        [Required]
        public long EntidadId { get; set; }

        public Entidad Entidad { get; set; }
    }
}
