using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Rubrica : EntidadBase
    {
        [Key]
        public new int Id { get; set; } 
        
        [Required]
        public int LibroId { get; set; }
        public Libro Libro { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaRubricacion { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }
    }
}
