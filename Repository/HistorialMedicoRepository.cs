using Microsoft.EntityFrameworkCore;
using Veterinaria.Interfaces;
using Veterinaria.Models;
using VeterinariaApp.Data;

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
            return await _context.HistorialesMedicos
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .ToListAsync();
        }

        public async Task<HistorialMedico?> GetByIdAsync(int id)
        {
            return await _context.HistorialesMedicos
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<IEnumerable<HistorialMedico>> GetByMascotaIdAsync(int mascotaId)
        {
            return await _context.HistorialesMedicos
                .Where(h => h.MascotaId == mascotaId)
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .ToListAsync();
        }

        public async Task<IEnumerable<HistorialMedico>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            return await _context.HistorialesMedicos
                .Where(h => h.VeterinarioId == veterinarioId)
                .Include(h => h.Mascota)
                .Include(h => h.Veterinario)
                .Include(h => h.Medicamentos)
                .ToListAsync();
        }

        public async Task<HistorialMedico> CreateAsync(HistorialMedico historialMedico)
        {
            _context.HistorialesMedicos.Add(historialMedico);
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
            var historialMedico = await _context.HistorialesMedicos.FindAsync(id);
            if (historialMedico == null) return false;

            _context.HistorialesMedicos.Remove(historialMedico);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.HistorialesMedicos.AnyAsync(h => h.Id == id);
        }
    }
}
