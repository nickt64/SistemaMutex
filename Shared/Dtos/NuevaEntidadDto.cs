using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class NuevaEntidadDto
    {
        [Required]
        [StringLength(20, ErrorMessage = "solo letras minimo 2 caracteres")]
        public string matricula { get; set; }

        [Required][StringLength(255)]
        public string nombre { get; set; }

        [Required]
        [StringLength(80)]
        public string provincia { get; set; }

        [Required]
        [StringLength(100)]
        public string direccion { get; set; }

        [Required]
        [StringLength(60)]
        public string localidad { get; set; }

        [Required]
        [StringLength(60)]
        public string partido_depto { get; set; }

        [Required]
        [StringLength(60)]
        public string RepEntidad { get; set; }

        [StringLength(50)]
        public string codigo_postal { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string mail { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }
        public string CUIT { get; set; }
        public string Tipo_Entidad { get; set; }
        public string Fecha_Inscripcion { get; set; }
        public string Actividad { get; set; }
        public string Estado { get; set; }

    }
}
