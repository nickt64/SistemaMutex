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

        public async Task<Entidad> GetById(long entidadId)
        {
            return await dbSet.SingleOrDefaultAsync(T => T.Id == entidadId);
        }

        public async Task<List<Entidad>> ObtenerPorEstado(bool estado)
        {
            return await dbSet.Where(x => x.Eliminado == estado).ToListAsync();
        }
    }
}
