using InfoExpress.EntidadesDeNegocio;
using InfoExpress.LogicaDeNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace InfoExpress.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private NoticiaBL noticiaBL = new NoticiaBL();

        [HttpGet]
        public async Task<IEnumerable<Noticia>> Get()
        {
            return await noticiaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Noticia> Get(int id)
        {
            Noticia noticia = new Noticia();
            noticia.Id = id;
            return await noticiaBL.ObtenerPorIdAsync(noticia);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Noticia noticia)
        {
            try
            {
                await noticiaBL.CrearAsync(noticia);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Noticia noticia)
        {

            if (noticia.Id == id)
            {
                await noticiaBL.ModificarAsync(noticia);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Noticia noticia = new Noticia();
                noticia.Id = id;
                await noticiaBL.EliminarAsync(noticia);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Noticia>> Buscar([FromBody] object pNoticia)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strNoticia = JsonSerializer.Serialize(pNoticia);
            Noticia noticia = JsonSerializer.Deserialize<Noticia>(strNoticia, option);
            return await noticiaBL.BuscarAsync(noticia);

        }
    }
}
