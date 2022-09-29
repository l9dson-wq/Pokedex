using Database;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repoitory
{
    public class PokemonRepoitory
    {
        //Todas la operaciones relacionadas con la base de datos ( CRUD ) van aqui 

        private readonly DatabaseContext _dbContex; 

        public PokemonRepoitory(DatabaseContext DbContext)
        {
            _dbContex = DbContext;
        }

        public async Task AddAsync(Pokemon pokemon)
        {
            await _dbContex.pokemones.AddAsync(pokemon);
            await _dbContex.SaveChangesAsync(); 
        }

        public async Task UpdateAsync(Pokemon pokemon)
        {
            _dbContex.Entry(pokemon).State = EntityState.Modified;
            await _dbContex.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon pokemon)
        {
            _dbContex.Set<Pokemon>().Remove(pokemon);
            await _dbContex.SaveChangesAsync();
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _dbContex.Set<Pokemon>()
                .Include("Pokemon_type")
                .Include("Region")
                .Include("Secundary_pokemonType")
                .ToListAsync();
        }

        public async Task<Pokemon> GetByIdAsync(int id)
        {
            return await _dbContex.Set<Pokemon>().FindAsync(id);
        }

    }
}
