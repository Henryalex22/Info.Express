using InfoExpress.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoExpress.AccesoADatos
{
    public class BDContexto : DbContext
    {

        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Data Source= DESKTOP-NFDMETJ;Initial Catalog=InfoExpress;Integrated Security=True; Trust Server Certificate=true");
        }
    }
}
