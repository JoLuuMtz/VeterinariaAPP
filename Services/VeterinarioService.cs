using Veterinaria.DTOs;
using Veterinaria.Interfaces;
using Veterinaria.Models;

namespace Veterinaria.Services
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IVeterinarioRepository _veterinarioRepository;

        public VeterinarioService(IVeterinarioRepository veterinarioRepository)
        {
            _veterinarioRepository = veterinarioRepository;
        }

        public async Task<ServiceResult<IEnumerable<VeterinarioResponseDTO>>> GetAllAsync()
        {
            try
            {
                var veterinarios = await _veterinarioRepository.GetAllAsync();
                var veterinariosDTO = veterinarios.Select(v => MapToResponseDTO(v));
                return ServiceResult<IEnumerable<VeterinarioResponseDTO>>.Ok(veterinariosDTO);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<VeterinarioResponseDTO>>.Fail(
                    $"Error al obtener los veterinarios: {ex.Message}");
            }
        }

        public async Task<ServiceResult<VeterinarioResponseDTO>> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<VeterinarioResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var veterinario = await _veterinarioRepository.GetByIdAsync(id);
                if (veterinario == null)
                    return ServiceResult<VeterinarioResponseDTO>.Fail("Veterinario no encontrado.");

                return ServiceResult<VeterinarioResponseDTO>.Ok(MapToResponseDTO(veterinario));
            }
            catch (Exception ex)
            {
                return ServiceResult<VeterinarioResponseDTO>.Fail($"Error al obtener el veterinario: {ex.Message}");
            }
        }

        public async Task<ServiceResult<VeterinarioResponseDTO>> CreateAsync(VeterinarioCreateDTO veterinarioCreateDTO)
        {
            try
            {
                // Validar que el email no esté duplicado
                if (!string.IsNullOrWhiteSpace(veterinarioCreateDTO.Email))
                {
                    var emailExiste = await _veterinarioRepository.ExistsByEmailAsync(veterinarioCreateDTO.Email);
                    if (emailExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe un veterinario con este correo electrónico.");
                }

                // Validar que el documento de identidad no esté duplicado
                if (!string.IsNullOrWhiteSpace(veterinarioCreateDTO.DocumentoIdentidad))
                {
                    var documentoExiste =
                        await _veterinarioRepository.ExistsByDocumentoIdentidadAsync(veterinarioCreateDTO
                            .DocumentoIdentidad);
                    if (documentoExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe un veterinario con este documento de identidad.");
                }

                // Validar que el teléfono no esté duplicado
                if (!string.IsNullOrWhiteSpace(veterinarioCreateDTO.Telefono))
                {
                    var telefonoExiste =
                        await _veterinarioRepository.ExistsByTelefonoAsync(veterinarioCreateDTO.Telefono);
                    if (telefonoExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe un veterinario con este número de teléfono.");
                }

                // Validar que el número de licencia no esté duplicado
                if (!string.IsNullOrWhiteSpace(veterinarioCreateDTO.NumeroLicencia))
                {
                    var licenciaExiste =
                        await _veterinarioRepository.ExistsByNumeroLicenciaAsync(veterinarioCreateDTO.NumeroLicencia);
                    if (licenciaExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe un veterinario con este número de licencia.");
                }

                var veterinario = new Veterinario
                {
                    Nombre = veterinarioCreateDTO.Nombre,
                    Apellido = veterinarioCreateDTO.Apellido,
                    Telefono = veterinarioCreateDTO.Telefono,
                    Email = veterinarioCreateDTO.Email,
                    DocumentoIdentidad = veterinarioCreateDTO.DocumentoIdentidad,
                    NumeroLicencia = veterinarioCreateDTO.NumeroLicencia,
                    Especialidad = veterinarioCreateDTO.Especialidad,
                    FechaContratacion = DateTime.Now,
                    Activo = true
                };

                var veterinarioCreado = await _veterinarioRepository.CreateAsync(veterinario);
                return ServiceResult<VeterinarioResponseDTO>.Ok(MapToResponseDTO(veterinarioCreado));
            }
            catch (Exception ex)
            {
                return ServiceResult<VeterinarioResponseDTO>.Fail($"Error al crear el veterinario: {ex.Message}");
            }
        }

        public async Task<ServiceResult<VeterinarioResponseDTO>> UpdateAsync(int id,
            VeterinarioUpdateDTO veterinarioUpdateDTO)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<VeterinarioResponseDTO>.Fail("El ID debe ser mayor a 0.");

                var veterinario = await _veterinarioRepository.GetByIdAsync(id);
                if (veterinario == null)
                    return ServiceResult<VeterinarioResponseDTO>.Fail("Veterinario no encontrado.");

                // Validar que el email no esté duplicado (excluyendo el veterinario actual)
                if (!string.IsNullOrWhiteSpace(veterinarioUpdateDTO.Email))
                {
                    var emailExiste = await _veterinarioRepository.ExistsByEmailAsync(veterinarioUpdateDTO.Email, id);
                    if (emailExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe otro veterinario con este correo electrónico.");
                }

                // Validar que el documento de identidad no esté duplicado (excluyendo el veterinario actual)
                if (!string.IsNullOrWhiteSpace(veterinarioUpdateDTO.DocumentoIdentidad))
                {
                    var documentoExiste =
                        await _veterinarioRepository.ExistsByDocumentoIdentidadAsync(
                            veterinarioUpdateDTO.DocumentoIdentidad, id);
                    if (documentoExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe otro veterinario con este documento de identidad.");
                }

                // Validar que el teléfono no esté duplicado (excluyendo el veterinario actual)
                if (!string.IsNullOrWhiteSpace(veterinarioUpdateDTO.Telefono))
                {
                    var telefonoExiste =
                        await _veterinarioRepository.ExistsByTelefonoAsync(veterinarioUpdateDTO.Telefono, id);
                    if (telefonoExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe otro veterinario con este número de teléfono.");
                }

                // Validar que el número de licencia no esté duplicado (excluyendo el veterinario actual)
                if (!string.IsNullOrWhiteSpace(veterinarioUpdateDTO.NumeroLicencia))
                {
                    var licenciaExiste =
                        await _veterinarioRepository.ExistsByNumeroLicenciaAsync(veterinarioUpdateDTO.NumeroLicencia,
                            id);
                    if (licenciaExiste)
                        return ServiceResult<VeterinarioResponseDTO>.Fail(
                            "Ya existe otro veterinario con este número de licencia.");
                }

                // Actualización parcial: solo actualizar campos que no sean null
                if (veterinarioUpdateDTO.Nombre != null)
                    veterinario.Nombre = veterinarioUpdateDTO.Nombre;
                if (veterinarioUpdateDTO.Apellido != null)
                    veterinario.Apellido = veterinarioUpdateDTO.Apellido;
                if (veterinarioUpdateDTO.Telefono != null)
                    veterinario.Telefono = veterinarioUpdateDTO.Telefono;
                if (veterinarioUpdateDTO.Email != null)
                    veterinario.Email = veterinarioUpdateDTO.Email;
                if (veterinarioUpdateDTO.DocumentoIdentidad != null)
                    veterinario.DocumentoIdentidad = veterinarioUpdateDTO.DocumentoIdentidad;
                if (veterinarioUpdateDTO.NumeroLicencia != null)
                    veterinario.NumeroLicencia = veterinarioUpdateDTO.NumeroLicencia;
                if (veterinarioUpdateDTO.Especialidad != null)
                    veterinario.Especialidad = veterinarioUpdateDTO.Especialidad;
                if (veterinarioUpdateDTO.Activo.HasValue)
                    veterinario.Activo = veterinarioUpdateDTO.Activo.Value;

                var veterinarioActualizado = await _veterinarioRepository.UpdateAsync(veterinario);
                if (veterinarioActualizado == null)
                    return ServiceResult<VeterinarioResponseDTO>.Fail("Error al actualizar el veterinario.");

                return ServiceResult<VeterinarioResponseDTO>.Ok(MapToResponseDTO(veterinarioActualizado));
            }
            catch (Exception ex)
            {
                return ServiceResult<VeterinarioResponseDTO>.Fail($"Error al actualizar el veterinario: {ex.Message}");
            }
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    return ServiceResult<bool>.Fail("El ID debe ser mayor a 0.");

                var existe = await _veterinarioRepository.ExistsAsync(id);
                if (!existe)
                    return ServiceResult<bool>.Fail("Veterinario no encontrado.");

                var resultado = await _veterinarioRepository.DeleteAsync(id);
                if (!resultado)
                    return ServiceResult<bool>.Fail("Error al eliminar el veterinario.");

                return ServiceResult<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return ServiceResult<bool>.Fail($"Error al eliminar el veterinario: {ex.Message}");
            }
        }

        private static VeterinarioResponseDTO MapToResponseDTO(Veterinario veterinario)
        {
            return new VeterinarioResponseDTO
            {
                Id = veterinario.Id,
                Nombre = veterinario.Nombre,
                Apellido = veterinario.Apellido,
                Telefono = veterinario.Telefono,
                Email = veterinario.Email,
                DocumentoIdentidad = veterinario.DocumentoIdentidad,
                NumeroLicencia = veterinario.NumeroLicencia,
                Especialidad = veterinario.Especialidad,
                FechaContratacion = veterinario.FechaContratacion,
                Activo = veterinario.Activo
            };
        }
    }
}
