using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Repository
{
    public class HistorialMedicoRepository : IHistorialMedicoRepository
    {
        private readonly VeterinariaDB _context;

        public HistorialMedicoRepository(VeterinariaDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistorialMedico>> GetAllAsync()
        {
            return await _context.HistorialMedico
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .ToListAsync();
        }

        public async Task<HistorialMedico?> GetByIdAsync(int id)
        {
            return await _context.HistorialMedico
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<HistorialMedico>> GetByMascotaIdAsync(int mascotaId)
        {
            return await _context.HistorialMedico
                .Where(h => h.MascotaId == mascotaId)
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .ToListAsync();
        }

        public async Task<IEnumerable<HistorialMedico>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            return await _context.HistorialMedico
                .Where(h => h.VeterinarioId == veterinarioId)
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .ToListAsync();
        }

        public async Task<HistorialMedico> CreateAsync(HistorialMedico historialMedico)
        {
            _context.HistorialMedico.Add(historialMedico);
            await _context.SaveChangesAsync();
            return historialMedico;
        }

        public async Task<HistorialMedico?> UpdateAsync(HistorialMedico historialMedico)
        {
            _context.Entry(historialMedico).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return historialMedico;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var historialMedico = await _context.HistorialMedico.FindAsync(id);
            if (historialMedico == null) return false;

            _context.HistorialMedico.Remove(historialMedico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.HistorialMedico.AnyAsync(h => h.Id == id);
        }
    }
}
