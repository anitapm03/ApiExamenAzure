using ApiExamenAzure.Data;
using ApiExamenAzure.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiExamenAzure.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        //get personajes
        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        //get personajes por su serie
        public async Task<List<Personaje>> GetPersonajesSerieAsync(string serie)
        {
            return await this.context.Personajes
                .Where(z => z.Serie == serie).ToListAsync();
        }

        //get series
        public async Task<List<string>> GetSeriesAsync()
        {
            var consulta = (from datos in this.context.Personajes
                            select datos.Serie).Distinct();
            return await consulta.ToListAsync();
        }

        //get personaje por id
        public async Task<Personaje> FindPersonajeAsync(int id)
        {
            return await this.context.Personajes.FirstOrDefaultAsync
                (x => x.IdPersonaje == id);
        }

        //insert personaje
        public async Task InsertPersonaje
            (int id, string nombre, string imagen, string serie)
        {
            Personaje pers = new Personaje();
            pers.IdPersonaje = id;
            pers.Nombre = nombre;
            pers.Imagen = imagen;
            pers.Serie = serie;
            this.context.Personajes.Add(pers);
            await this.context.SaveChangesAsync();
        }

        //update personaje
        public async Task UpdatePersonaje
            (int id, string nombre, string imagen, string serie)
        {
            Personaje pers = await this.FindPersonajeAsync(id);
            pers.Nombre = nombre;
            pers.Imagen = imagen;
            pers.Serie = serie;
            await this.context.SaveChangesAsync();
        }

        //delete personaje
        public async Task DeletePersonaje(int id)
        {
            Personaje pers = await this.FindPersonajeAsync(id);
            this.context.Personajes.Remove(pers);
            await this.context.SaveChangesAsync();
        }
    }
}
