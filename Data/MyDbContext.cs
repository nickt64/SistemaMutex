using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions option) : base(option)
        {
            
        }

        //tablas sql (dbSet<T>)
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Rubrica> Rubricas { get; set; }
        public DbSet<Libro> Libros { get; set; }

    }
}
