using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Repository
{
    public class CitaRepository : ICitaRepository
    {
        private readonly VeterinariaDB _context;

        public CitaRepository(VeterinariaDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cita>> GetAllAsync()
        {
            return await _context.Citas
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .ToListAsync();
        }

        public async Task<Cita?> GetByIdAsync(int id)
        {
            return await _context.Citas
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cita>> GetByMascotaIdAsync(int mascotaId)
        {
            return await _context.Citas
                .Where(c => c.MascotaId == mascotaId)
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            return await _context.Citas
                .Where(c => c.VeterinarioId == veterinarioId)
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetByFechaAsync(DateTime fecha)
        {
            return await _context.Citas
                .Where(c => c.FechaHora.Date == fecha.Date)
                .Include(c => c.Mascota)
                .Include(c => c.Veterinario)
                .ToListAsync();
        }

        public async Task<Cita> CreateAsync(Cita cita)
        {
            _context.Citas.Add(cita);
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<Cita?> UpdateAsync(Cita cita)
        {
            _context.Entry(cita).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cita;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita == null) return false;

            _context.Citas.Remove(cita);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Citas.AnyAsync(c => c.Id == id);
        }
    }
}
