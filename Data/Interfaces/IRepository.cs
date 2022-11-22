using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{


    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
       
        Task Add(T entidad);
       
        void Delete(T entidad);
       
        void Update(T entidad);
        
        Task<T> GetById(int entidadId);
    }

}
