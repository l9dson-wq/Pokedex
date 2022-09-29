using Database.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repoitory
{
    public class RegionRepository
    {
        //Todas la operaciones relacionadas con la base de datos ( CRUD ) van aqui 

        private readonly DatabaseContext _dbContex;

        public RegionRepository(DatabaseContext DbContext)
        {
            _dbContex = DbContext;
        }

        public async Task AddAsync(Region region)
        {
            await _dbContex.Regions.AddAsync(region);
            await _dbContex.SaveChangesAsync();
        }

        public async Task UpdateAsync(Region region)
        {
            _dbContex.Entry(region).State = EntityState.Modified;
            await _dbContex.SaveChangesAsync();
        }

        public async Task DeleteAsync(Region region)
        {
            _dbContex.Set<Region>().Remove(region);
            await _dbContex.SaveChangesAsync();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContex.Set<Region>().ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _dbContex.Set<Region>().FindAsync(id);
        }
    }
}
