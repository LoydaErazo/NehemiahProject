using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UINProject.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Years> Years { get; set; }
        public DbSet<Cohortes> Cohortes { get; set; }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Estudiantes> Estudiantes { get; set; }
    }
}