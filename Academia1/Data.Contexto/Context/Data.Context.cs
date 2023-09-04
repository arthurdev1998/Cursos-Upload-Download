using Data.Contexto.DataConfig;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexto.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions <DataContext> options): base(options) 
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cursos>(new CursosConfiguration().Configure);
            base.OnModelCreating(modelBuilder);
        }

    }
}
