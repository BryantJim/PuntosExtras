using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PuntosExtras.Entidades;

namespace PuntosExtras.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"DataBase\Personas.db");
        }
    }
}
