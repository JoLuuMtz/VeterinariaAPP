using FluentValidation;
using Veterinaria.Models;

namespace Veterinaria.Validators
{
    public class CitaValidator : AbstractValidator<Cita>
    {
        public CitaValidator()
        {
            // Validación de FechaHora
            RuleFor(x => x.FechaHora)
                .NotEmpty().WithMessage("La fecha y hora de la cita es obligatoria.")
                .GreaterThan(DateTime.Now.AddMinutes(-30)).WithMessage(
                    "La fecha y hora de la cita debe ser válida y no puede ser más de 30 minutos en el pasado.");

            // Validación de Estado
            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("El estado de la cita es obligatorio.")
                .MaximumLength(50).WithMessage("El estado no puede exceder los 50 caracteres.")
                .Must(x => x.ToLower() == "pendiente" ||
                           x.ToLower() == "confirmada" ||
                           x.ToLower() == "completada" ||
                           x.ToLower() == "cancelada")
                .WithMessage("El estado debe ser: Pendiente, Confirmada, Completada o Cancelada.");

            // Validación de Motivo
            RuleFor(x => x.Motivo)
                .MaximumLength(500).WithMessage("El motivo no puede exceder los 500 caracteres.");

            // Validación de Observaciones
            RuleFor(x => x.Observaciones)
                .MaximumLength(1000).WithMessage("Las observaciones no pueden exceder los 1000 caracteres.");

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

