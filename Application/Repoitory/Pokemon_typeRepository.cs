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
    public class Pokemon_typeRepository
    {
        private readonly DatabaseContext _dbContex;

        public Pokemon_typeRepository(DatabaseContext DbContext)
        {
            _dbContex = DbContext;
        }

        public async Task AddAsync(Pokemon_type pokemon_type)
        {
            await _dbContex.pokemon_type.AddAsync(pokemon_type);
            await _dbContex.SaveChangesAsync();
        }

        public async Task UpdateAsync(Pokemon_type pokemon_type)
        {
            _dbContex.Entry(pokemon_type).State = EntityState.Modified;
            await _dbContex.SaveChangesAsync();
        }

        public async Task DeleteAsync(Pokemon_type pokemon_type)
        {
            _dbContex.Set<Pokemon_type>().Remove(pokemon_type);
            await _dbContex.SaveChangesAsync();
        }

        public async Task<List<Pokemon_type>> GetAllAsync()
        {
            return await _dbContex.Set<Pokemon_type>().ToListAsync();
        }

        public async Task<Pokemon_type> GetByIdAsync(int id)
        {
            return await _dbContex.Set<Pokemon_type>().FindAsync(id);
        }
    }
}
