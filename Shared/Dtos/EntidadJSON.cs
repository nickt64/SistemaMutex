using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class EntidadJSON
    {
        public string Matricula { get; set; }
        public string Nombre { get; set; }
        public string Provincia { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Partido_Depto { get; set; }
        public string Codigo_Postal { get; set; }
        public string EMail { get; set; }
        public string Telefono { get; set; }
        public string CUIT { get; set; }
        public string Tipo_Entidad { get; set; }
        public string Fecha_Inscripcion { get; set; }
        public string Actividad { get; set; }
        public string Estado { get; set; }
    }
}
