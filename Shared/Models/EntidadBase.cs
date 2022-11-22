using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public abstract class EntidadBase
    {
        
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool Eliminado { get; set; }
    }
}
