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
        public EntidadInsercionVM(EntidadJSON entidadJson, string repEntidad, bool decJurada)
        {
            this.entidadJson = entidadJson;
            this.repEntidad = repEntidad;
            this.decJurada = decJurada;
        }
        public EntidadJSON entidadJson { get; set; }

        public string repEntidad { get; set; }

        public bool decJurada { get; set; }
    }
}
