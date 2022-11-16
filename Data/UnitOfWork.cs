using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    

    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _myDbContext;
        //campo de lectura privado por cada repositorio



        public UnitOfWork(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;

            //instanciacion del repositorio con parametro (_myDbContext);
        }

        // EJEMPLO: 
        // public UsuariosRepository UsuarioRepository => _usuariosRepository;
        public async Task SaveChangesAsync()
        {
            await _myDbContext.SaveChangesAsync();
        }

    }

}
