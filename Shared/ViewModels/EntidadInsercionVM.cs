using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class EntidadInsercionVM
    {
        public EntidadInsercionVM()
        {

        }
        public EntidadInsercionVM(EntidadJSON entidadJson, bool decJurada, string representanteEntidad)
        {
            this.EntidadJson = entidadJson;
            this.DecJurada = decJurada;
            this.RepresentanteEntidad = representanteEntidad;
        }
        public string RepresentanteEntidad { get; set; }

        public EntidadJSON EntidadJson { get; set; }

        public bool DecJurada { get; set; }
    }
}
