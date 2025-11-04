using FluentValidation;
using Veterinaria.Models;

namespace Veterinaria.Validators
{
    public class HistorialMedicoValidator : AbstractValidator<HistorialMedico>
    {
        public HistorialMedicoValidator()
        {
            // Validación de Fecha
            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("La fecha del historial médico es obligatoria.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser futura.")
                .GreaterThan(DateTime.Now.AddYears(-20)).WithMessage("La fecha no puede ser mayor a 20 años atrás.");

            // Validación de TipoConsulta
            RuleFor(x => x.TipoConsulta)
                .NotEmpty().WithMessage("El tipo de consulta es obligatorio.")
                .MaximumLength(100).WithMessage("El tipo de consulta no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
                .WithMessage("El tipo de consulta solo puede contener letras y espacios.");

            // Validación de Diagnostico
            RuleFor(x => x.Diagnostico)
                .MaximumLength(2000).WithMessage("El diagnóstico no puede exceder los 2000 caracteres.");

            // Validación de Tratamiento
            RuleFor(x => x.Tratamiento)
                .MaximumLength(2000).WithMessage("El tratamiento no puede exceder los 2000 caracteres.");

            // Validación de Observaciones
            RuleFor(x => x.Observaciones)
                .MaximumLength(1000).WithMessage("Las observaciones no pueden exceder los 1000 caracteres.");

            // Validación de PesoRegistrado
            RuleFor(x => x.PesoRegistrado)
                .GreaterThan(0).WithMessage("El peso registrado debe ser mayor a 0.")
                .LessThanOrEqualTo(1000).WithMessage("El peso registrado no puede ser mayor a 1000 kg.");

            // Validación de Temperatura
            RuleFor(x => x.Temperatura)
                .MaximumLength(100).WithMessage("La temperatura no puede exceder los 100 caracteres.")
                .Matches(@"^[\d\.]+°?[CF]?$").When(x => !string.IsNullOrEmpty(x.Temperatura))
                .WithMessage("La temperatura debe tener un formato válido (ej: 38.5, 38.5°C, 101.3°F).");

            // Validación de MascotaId
            RuleFor(x => x.MascotaId)
                .NotEmpty().WithMessage("El ID de la mascota es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la mascota debe ser mayor a 0.");

            // Validación de VeterinarioId
            RuleFor(x => x.VeterinarioId)
                .NotEmpty().WithMessage("El ID del veterinario es obligatorio.")
                .GreaterThan(0).WithMessage("El ID del veterinario debe ser mayor a 0.");
        }
    }
}

