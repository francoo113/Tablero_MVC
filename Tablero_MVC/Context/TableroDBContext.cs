using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Tablero_MVC.Models;

namespace Tablero_MVC.Context
{
    public class TableroDBContext : DbContext
    {
        public TableroDBContext(DbContextOptions<TableroDBContext> opciones)
            : base(opciones)
        {
        }

        public DbSet<Tablero> Tableros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }



    }
}
