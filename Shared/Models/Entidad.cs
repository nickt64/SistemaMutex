using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Entidad : EntidadBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public new long Id { get; set; }

        [Required][StringLength(11)]
        public string CUIT { get; set; }

        [Required][StringLength(20,ErrorMessage ="exede cantidad de digitos")]
        public string Matricula { get; set; }


        [Required(ErrorMessage = "campo requerido"),DefaultValue(false)]
        public bool DecJurada { get; set; }

        [Required][StringLength(255,ErrorMessage = "exede cantidad de digitos")]
        public string Nombre { get; set; }

        [Required][StringLength(80)]
        public string Provincia { get; set; }

        [Required][StringLength(100)]
        public string Direccion { get; set; }

        [Required][StringLength(60)]
        public string Localidad { get; set; }

        [Required][StringLength(60)]
        public string Partido_Depto { get; set; }

        [Required][StringLength(60)]
        public string RepEntidad { get; set; }

        public List<Libro> Libros { get; set; }


        [StringLength(50)]
        public string Codigo_Postal { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(300)]
        public string EMail { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(20)]
        public string Tipo_Entidad { get; set; }

        [StringLength(15)]
        public string Fecha_Inscripcion { get; set; }
        
        [StringLength(100)]
        public string Actividad { get; set; }

        [StringLength(150)]
        public string Estado { get; set; }
        

    }
}
