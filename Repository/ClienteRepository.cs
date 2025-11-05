using Microsoft.EntityFrameworkCore;
using VeterinariaApp.Data;
using Veterinaria.Interfaces;
using VeterinariaApp.Models;

namespace Veterinaria.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly VeterinariaDB _context;

        public ClienteRepository(VeterinariaDB context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente?> UpdateAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Clientes.AnyAsync(c => c.Id == id);
        }

        public async Task<bool> ExistsByEmailAsync(string email, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var emailLower = email.ToLower();
            var query = _context.Clientes.Where(c => c.Email != null && c.Email.ToLower() == emailLower);

            if (excludeId.HasValue)
                query = query.Where(c => c.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<bool> ExistsByDocumentoIdentidadAsync(string documentoIdentidad, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(documentoIdentidad))
                return false;

            var documentoLower = documentoIdentidad.ToLower();
            var query = _context.Clientes.Where(c =>
                c.DocumentoIdentidad != null && c.DocumentoIdentidad.ToLower() == documentoLower);

            if (excludeId.HasValue)
                query = query.Where(c => c.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<bool> ExistsByTelefonoAsync(string telefono, int? excludeId = null)
        {
            if (string.IsNullOrWhiteSpace(telefono))
                return false;

            var telefonoLower = telefono.ToLower();
            var query = _context.Clientes.Where(c =>
                c.Telefono != null && c.Telefono.ToLower() == telefonoLower);

            if (excludeId.HasValue)
                query = query.Where(c => c.Id != excludeId.Value);

            return await query.AnyAsync();
        }
    }
}
