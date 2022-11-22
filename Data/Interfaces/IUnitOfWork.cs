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
        



        //metodos
        Task SaveChangesAsync();
    }
}
