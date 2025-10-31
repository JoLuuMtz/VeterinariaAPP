using Microsoft.EntityFrameworkCore;
using VeterinariaApp.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Repository
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly VeterinariaDB _context;

        public VeterinarioRepository(VeterinariaDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return await _context.Veterinarios.ToListAsync();
        }

        public async Task<Veterinario?> GetByIdAsync(int id)
        {
            return await _context.Veterinarios.FindAsync(id);
        }

        public async Task<Veterinario> CreateAsync(Veterinario veterinario)
        {
            _context.Veterinarios.Add(veterinario);
            await _context.SaveChangesAsync();
            return veterinario;
        }

        public async Task<Veterinario?> UpdateAsync(Veterinario veterinario)
        {
            _context.Entry(veterinario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return veterinario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var veterinario = await _context.Veterinarios.FindAsync(id);
            if (veterinario == null) return false;

            _context.Veterinarios.Remove(veterinario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Veterinarios.AnyAsync(v => v.Id == id);
        }
    }
}
