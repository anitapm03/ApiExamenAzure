using ApiExamenAzure.Models;
using ApiExamenAzure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiExamenAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<Personaje>>> GetPersonajes()
        {
            return await this.repo.GetPersonajesAsync();
        }

        [HttpGet]
        [Route("[action]/{serie}")]
        public async Task<ActionResult<List<Personaje>>> 
            PersonajesSerie(string serie)
        {
            return await this.repo.GetPersonajesSerieAsync(serie);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<List<string>>> Series()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<ActionResult<Personaje>> FindPersonaje(int id)
        {
            return await this.repo.FindPersonajeAsync(id);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertPersonaje
            (Personaje personaje)
        {
            await this.repo.InsertPersonaje
                (personaje.IdPersonaje, personaje.Nombre,
                personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult> UpdatePersonaje
            (Personaje personaje)
        {
            await this.repo.UpdatePersonaje
                (personaje.IdPersonaje, personaje.Nombre,
                personaje.Imagen, personaje.Serie);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<ActionResult> DeletePersonaje(int id)
        {
            await this.repo.DeletePersonaje(id);
            return Ok();
        }
    }
}
