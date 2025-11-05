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

        public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var emailLower = email.ToLower();
            var query = _context.Veterinarios.Where(v => v.Email != null && v.Email.ToLower() == emailLower);

            if (excludeId.HasValue)
                query = query.Where(v => v.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<bool> ExistsByDocumentoIdentidadAsync(string documentoIdentidad, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(documentoIdentidad))
                return false;

            var documentoLower = documentoIdentidad.ToLower();
            var query = _context.Veterinarios.Where(v =>
                v.DocumentoIdentidad != null && v.DocumentoIdentidad.ToLower() == documentoLower);

            if (excludeId.HasValue)
                query = query.Where(v => v.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<bool> ExistsByTelefonoAsync(string telefono, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            var telefonoLower = telefono.ToLower();
            var query = _context.Veterinarios.Where(v =>
                v.Telefono != null && v.Telefono.ToLower() == telefonoLower);

            if (excludeId.HasValue)
                query = query.Where(v => v.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<bool> ExistsByNumeroLicenciaAsync(string numeroLicencia, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(numeroLicencia))
                return false;

            var licenciaLower = numeroLicencia.ToLower();
            var query = _context.Veterinarios.Where(v =>
                v.NumeroLicencia != null && v.NumeroLicencia.ToLower() == licenciaLower);

            if (excludeId.HasValue)
                query = query.Where(v => v.Id != excludeId.Value);

            return await query.AnyAsync();
        }
    }
}
