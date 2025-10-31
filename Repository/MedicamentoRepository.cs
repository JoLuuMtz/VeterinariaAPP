using Microsoft.EntityFrameworkCore;
using VeterinariaApp.Data;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Repository
{
    public class MedicamentoRepository : IMedicamentoRepository
    {
        private readonly VeterinariaDB _context;

        public MedicamentoRepository(VeterinariaDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            return await _context.Medicamentos
                .Include(m => m.HistorialMedico)
                .ToListAsync();
        }

        public async Task<Medicamento?> GetByIdAsync(int id)
        {
            return await _context.Medicamentos
                .Include(m => m.HistorialMedico)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Medicamento>> GetByHistorialMedicoIdAsync(int historialMedicoId)
        {
            return await _context.Medicamentos
                .Where(m => m.HistorialMedicoId == historialMedicoId)
                .Include(m => m.HistorialMedico)
                .ToListAsync();
        }

        public async Task<Medicamento> CreateAsync(Medicamento medicamento)
        {
            _context.Medicamentos.Add(medicamento);
            await _context.SaveChangesAsync();
            return medicamento;
        }

        public async Task<Medicamento?> UpdateAsync(Medicamento medicamento)
        {
            _context.Entry(medicamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return medicamento;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null) return false;

            _context.Medicamentos.Remove(medicamento);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Medicamentos.AnyAsync(m => m.Id == id);
        }
    }
}
