using Data.Interfaces;
using Data.Repositorios;
using Shared.Models;
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
        private readonly EntidadRepository _entidadRepository;

        private readonly LibroRepository _libroRepository;

        private readonly RubricaRepository _rubricaRepository;


        public UnitOfWork(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;

            //instanciacion del repositorio con parametro (_myDbContext);
            _entidadRepository = new EntidadRepository(_myDbContext);

            _libroRepository = new LibroRepository(_myDbContext);

            _rubricaRepository = new RubricaRepository(_myDbContext);

        }

        // EJEMPLO: 
        // public UsuariosRepository UsuarioRepository => _usuariosRepository;
        public EntidadRepository EntidadRepository => _entidadRepository;

        public LibroRepository LibroRepository => _libroRepository;

        public RubricaRepository RubricaRepository => _rubricaRepository;

        public async Task SaveChangesAsync()
        {
            await _myDbContext.SaveChangesAsync();
        }

    }

}
