using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class RubricaRepository : Repository<Rubrica>
    {
        public RubricaRepository(MyDbContext myDbContext) : base(myDbContext)
        {

        }


    }
}
