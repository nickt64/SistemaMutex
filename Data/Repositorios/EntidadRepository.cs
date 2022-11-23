using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class EntidadRepository : Repository<Entidad>
    {
        public EntidadRepository(MyDbContext myDbContext) : base(myDbContext)
        {
        }

        //public async Task<Entidad> GetByCuit(int entidadCuit)
        //{
        //    return await dbSet.SingleOrDefaultAsync(T => T.CUIT.Equals(entidadCuit));
        //}
    }
}
