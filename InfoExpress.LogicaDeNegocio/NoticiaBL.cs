using InfoExpress.AccesoADatos;
using InfoExpress.EntidadesDeNegocio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoExpress.LogicaDeNegocio
{
    public class NoticiaBL
    {
        public async Task<int> CrearAsync(Noticia pNoticia)
        {
            return await NoticiaDAL.CrearAsync(pNoticia);
        }

        public async Task<int> ModificarAsync(Noticia pNoticia)
        {
            return await NoticiaDAL.ModificarAsync(pNoticia);
        }

        public async Task<int> EliminarAsync(Noticia pNoticia)
        {
            return await NoticiaDAL.EliminarAsync(pNoticia);
        }

        public async Task<Noticia> ObtenerPorIdAsync(Noticia pNoticia)
        {
            return await NoticiaDAL.ObtenerPorIdAsync(pNoticia);
        }

        public async Task<List<Noticia>> ObtenerTodosAsync()
        {
            return await NoticiaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Noticia>> BuscarAsync(Noticia pNoticia)
        {
            return await NoticiaDAL.BuscarAsync(pNoticia);
        }


        public async Task<List<Noticia>> BuscarIncluirCategoriaAsync(Noticia pNoticia)
        {
            return await NoticiaDAL.BuscarIncluirCategoriaAsync(pNoticia);
        }
    }
}
