using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Shared.Models;

namespace Data.Repositorios
{

    public abstract class Repository<T> : IRepository<T> where T : EntidadBase
    {
        private readonly MyDbContext _myDbContext;
        protected DbSet<T> dbSet;
        //
        public Repository(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
            dbSet = myDbContext.Set<T>();
        }

        public async Task Add(T entidad)
        {
            await dbSet.AddAsync(entidad);

        }

        public void Delete(T entidad)
        {
            entidad.Eliminado = true;
            dbSet.Update(entidad);
        }

        public async Task<List<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }


        public async Task<T> GetById(int entidadId)
        {
            return await dbSet.SingleOrDefaultAsync(T => T.Id == entidadId);
        }

        public void Update(T entidad)
        {
            dbSet.Attach(entidad);
            _myDbContext.Entry(entidad).State = EntityState.Modified;
        }
    }

}

