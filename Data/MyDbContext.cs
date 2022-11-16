using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions option) : base(option)
        {

        }

        //tablas sql (dbSet<T>)
    }
}
