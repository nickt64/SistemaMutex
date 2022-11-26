using Data.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        //repositorios
        EntidadRepository EntidadRepository { get; }

        LibroRepository LibroRepository { get; }

        RubricaRepository RubricaRepository { get; }



        //metodos
        Task SaveChangesAsync();
    }
}
