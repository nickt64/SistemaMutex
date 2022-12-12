using Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class EntidadIndexVM
    {
       

        [Required][StringLength(11, ErrorMessage = "dato CUIT requerido, 11 digitos")][MinLength(11)]
        public string cuit { get; set; }
        [Required]
        public int padron { get; set; }

        [Required]
        public string repEntidad { get; set; }

        [Required]
        public bool decJurada { get;set; }
    }
}
