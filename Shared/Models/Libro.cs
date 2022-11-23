using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Libro : EntidadBase
    {
        [Key]
        public new int Id { get; set; }

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

        [Required]
        public bool Autorizado { get; set; }    


       public List<Rubrica> Rubricas { get; set; }

        [Required]
        public long EntidadId { get; set; }
        public  Entidad Entidad { get; set; }
    }
}
