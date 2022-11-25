using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositorios
{
    public class LibroRepository : Repository<Libro>
    {
        public LibroRepository(MyDbContext myDbContext) : base(myDbContext)
        {

        }

        public async Task<List<Libro>> GetAllForEntidad(long id)
        {

            return await dbSet.Include(x => x.Entidad).Where(x => x.EntidadId == id).ToListAsync();
               
        }

    }
}
