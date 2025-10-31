using Microsoft.EntityFrameworkCore;
using VeterinariaApp.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Repository
{
    public class MascotaRepository : IMascotaRepository
    {
        private readonly VeterinariaDB _context;

        public MascotaRepository(VeterinariaDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mascota>> GetAllAsync()
        {
            return await _context.Mascotas
                .Include(m => m.Cliente)
                .ToListAsync();
        }

        public async Task<Mascota?> GetByIdAsync(int id)
        {
            return await _context.Mascotas
                .Include(m => m.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Mascota>> GetByClienteIdAsync(int clienteId)
        {
            return await _context.Mascotas
                .Where(m => m.ClienteId == clienteId)
                .Include(m => m.Cliente)
                .ToListAsync();
        }

        public async Task<Mascota> CreateAsync(Mascota mascota)
        {
            _context.Mascotas.Add(mascota);
            await _context.SaveChangesAsync();
            return mascota;
        }

        public async Task<Mascota?> UpdateAsync(Mascota mascota)
        {
            _context.Entry(mascota).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return mascota;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null) return false;

            _context.Mascotas.Remove(mascota);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Mascotas.AnyAsync(m => m.Id == id);
        }
    }
}
