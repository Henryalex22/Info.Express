using InfoExpress.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoExpress.AccesoADatos
{
    public class NoticiaDAL
    {
        public static async Task<int> CrearAsync(Noticia pNoticia)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pNoticia);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Noticia pNoticia)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var noticia = await bdContexto.Noticia.FirstOrDefaultAsync(s => s.Id == pNoticia.Id);
                noticia.IdCategoria = pNoticia.IdCategoria;
                noticia.Titulo = pNoticia.Titulo;
                noticia.Contenido = pNoticia.Contenido;
                noticia.FechaPublicacion = pNoticia.FechaPublicacion;
                noticia.Imagen = pNoticia.Imagen;
                bdContexto.Update(noticia);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Noticia pNoticia)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var noticia = await bdContexto.Noticia.FirstOrDefaultAsync(s => s.Id == pNoticia.Id);
                bdContexto.Noticia.Remove(noticia);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Noticia> ObtenerPorIdAsync(Noticia pNoticia)
        {
            var noticia = new Noticia();
            using (var bdContexto = new BDContexto())
            {
                noticia = await bdContexto.Noticia.FirstOrDefaultAsync(s => s.Id == pNoticia.Id);
            }
            return noticia;
        }


        public static async Task<List<Noticia>> ObtenerTodosAsync()
        {
            List<Noticia> noticias;
            using (var bdContexto = new BDContexto())
            {
                noticias = await bdContexto.Noticia.ToListAsync();
            }
            return noticias;
        }

        internal static IQueryable<Noticia> QuerySelect(IQueryable<Noticia> pQuery, Noticia pNoticia)
        {
            if (pNoticia.IdCategoria > 0)
                pQuery = pQuery.Where(s => s.IdCategoria == pNoticia.IdCategoria);

            if (!string.IsNullOrWhiteSpace(pNoticia.Titulo))
                pQuery = pQuery.Where(s => s.Titulo.Contains(pNoticia.Titulo));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pNoticia.Top_Aux > 0)
                pQuery = pQuery.Take(pNoticia.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Noticia>> BuscarAsync(Noticia pNoticia)
        {
            var noticias = new List<Noticia>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Noticia.AsQueryable();
                select = QuerySelect(select, pNoticia);
                noticias = await select.ToListAsync();
            }
            return noticias;
        }
        public static async Task<List<Noticia>> BuscarIncluirCategoriaAsync(Noticia pNoticia)
        {
            var noticias = new List<Noticia>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Noticia.AsQueryable();
                select = QuerySelect(select, pNoticia).Include(s => s.Categoria).AsQueryable();
                noticias = await select.ToListAsync();
            }
            return noticias;
        }

    }
}
