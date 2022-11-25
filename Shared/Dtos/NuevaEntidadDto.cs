using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string Matricula { get; set; }

        [Required][StringLength(255)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(80)]
        public string Provincia { get; set; }

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }

        [Required]
        [StringLength(60)]
        public string Localidad { get; set; }

        [Required]
        [StringLength(60)]
        public string Partido_Depto { get; set; }

        [Required]
        [StringLength(60)]
        public string RepEntidad { get; set; }

        [StringLength(50)]
        public string Codigo_Postal { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(300)]
        public string EMail { get; set; }

        [StringLength(30)]
        public string Telefono { get; set; }
        public string CUIT { get; set; }
        public string Tipo_Entidad { get; set; }
        public string Fecha_Inscripcion { get; set; }
        public string Actividad { get; set; }
        public string Estado { get; set; }

        [DefaultValue(false)]
        public bool DecJurada { get; set; }

    }
}
