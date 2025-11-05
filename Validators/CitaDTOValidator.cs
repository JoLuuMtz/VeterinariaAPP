using System;
using FluentValidation;
using Veterinaria.DTOs;

namespace Veterinaria.Validators
{
    public class CitaCreateDTOValidator : AbstractValidator<CitaCreateDTO>
    {
        public CitaCreateDTOValidator()
        {
            RuleFor(x => x.FechaHora)
                .NotEmpty().WithMessage("La fecha y hora de la cita es obligatoria.")
                .GreaterThan(DateTime.Now).WithMessage("La fechas de las citas deben ser a futuro");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("El estado de la cita es obligatorio.")
                .MaximumLength(50).WithMessage("El estado no puede exceder los 50 caracteres.")
                .Must(x => x.ToLower() == "pendiente" || x.ToLower() == "confirmada" || x.ToLower() == "completada" || x.ToLower() == "cancelada")
                .WithMessage("El estado debe ser: Pendiente, Confirmada, Completada o Cancelada.");

            RuleFor(x => x.Motivo)
                .MaximumLength(500).WithMessage("El motivo no puede exceder los 500 caracteres.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(1000).WithMessage("Las observaciones no pueden exceder los 1000 caracteres.");

            RuleFor(x => x.MascotaId)
                .NotEmpty().WithMessage("El ID de la mascota es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la mascota debe ser mayor a 0.");

            RuleFor(x => x.VeterinarioId)
                .NotEmpty().WithMessage("El ID del veterinario es obligatorio.")
                .GreaterThan(0).WithMessage("El ID del veterinario debe ser mayor a 0.");
        }
    }

    public class CitaUpdateDTOValidator : AbstractValidator<CitaUpdateDTO>
    {
        public CitaUpdateDTOValidator()
        {
            When(x => x.FechaHora.HasValue, () =>
            {
                RuleFor(x => x.FechaHora.Value)
                    .GreaterThan(DateTime.Now).WithMessage("La fechas de las citas deben ser a futuro");
            });

            When(x => x.Estado != null, () =>
            {
                RuleFor(x => x.Estado)
                    .MaximumLength(50).WithMessage("El estado no puede exceder los 50 caracteres.")
                    .Must(x => x.ToLower() == "pendiente" || x.ToLower() == "confirmada" || x.ToLower() == "completada" || x.ToLower() == "cancelada")
                    .WithMessage("El estado debe ser: Pendiente, Confirmada, Completada o Cancelada.");
            });

            When(x => x.Motivo != null, () =>
            {
                RuleFor(x => x.Motivo)
                    .MaximumLength(500).WithMessage("El motivo no puede exceder los 500 caracteres.");
            });

            When(x => x.Observaciones != null, () =>
            {
                RuleFor(x => x.Observaciones)
                    .MaximumLength(1000).WithMessage("Las observaciones no pueden exceder los 1000 caracteres.");
            });
        }
    }
}
