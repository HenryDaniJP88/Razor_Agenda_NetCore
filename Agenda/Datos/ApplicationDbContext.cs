using Microsoft.EntityFrameworkCore;
using Razor_Agenda.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_Agenda.Datos
{

      public class ApplicationDbContext : DbContext
      {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
           
            }

            //DataSet que nos permitira Obtener los datos de la tabla Categoria de la BD
            public DbSet<Categoria> Categoria { get; set; }

            //DataSet que nos permitira Obtener los datos de la tabla Contacto
            public DbSet<Contacto> Contacto { get; set; }
      }
}
