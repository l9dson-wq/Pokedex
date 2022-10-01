using Database.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Repoitory
{
    public class PokemonType2Repository
    {
        private readonly DatabaseContext _dbContex;

        public PokemonType2Repository(DatabaseContext DbContext)
        {
            _dbContex = DbContext;
        }

        public async Task AddAsync(Pokemon_type2 pokemon_type2)
        {
            await _dbContex.pokemon_type2.AddAsync(pokemon_type2);
            await _dbContex.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemon_type2 pokemon_type)
        {
            _dbContex.Entry(pokemon_type).State = EntityState.Modified;
            await _dbContex.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon_type2 pokemon_type)
        {
            _dbContex.Set<Pokemon_type2>().Remove(pokemon_type);
            await _dbContex.SaveChangesAsync();
        }

        public async Task<List<Pokemon_type2>> GetAllAsync()
        {
            return await _dbContex.Set<Pokemon_type2>().ToListAsync();
        }

        public async Task<Pokemon_type2> GetByIdAsync(int id)
        {
            return await _dbContex.Set<Pokemon_type2>().FindAsync(id);
        }
    }
}
