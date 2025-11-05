using System;
using FluentValidation;
using Veterinaria.DTOs;

namespace Veterinaria.Validators
{
    public class HistorialMedicoCreateDTOValidator : AbstractValidator<HistorialMedicoCreateDTO>
    {
        public HistorialMedicoCreateDTOValidator()
        {
            RuleFor(x => x.Fecha)
                .NotEmpty().WithMessage("La fecha es obligatoria.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser futura.")
                .GreaterThan(DateTime.Now.AddYears(-50)).WithMessage("La fecha no puede ser mayor a 50 años atrás.");

            RuleFor(x => x.TipoConsulta)
                .NotEmpty().WithMessage("El tipo de consulta es obligatorio.")
                .MaximumLength(100).WithMessage("El tipo de consulta no puede exceder los 100 caracteres.");

            RuleFor(x => x.Diagnostico)
                .MaximumLength(2000).WithMessage("El diagnóstico no puede exceder los 2000 caracteres.");

            RuleFor(x => x.Tratamiento)
                .MaximumLength(2000).WithMessage("El tratamiento no puede exceder los 2000 caracteres.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(1000).WithMessage("Las observaciones no pueden exceder los 1000 caracteres.");

            RuleFor(x => x.PesoRegistrado)
                .GreaterThanOrEqualTo(0).WithMessage("El peso registrado debe ser mayor o igual a 0.")
                .LessThanOrEqualTo(1000).WithMessage("El peso registrado no puede ser mayor a 1000 kg.");

            RuleFor(x => x.Temperatura)
                .MaximumLength(100).WithMessage("La temperatura no puede exceder los 100 caracteres.");

            RuleFor(x => x.MascotaId)
                .NotEmpty().WithMessage("El ID de la mascota es obligatorio.")
                .GreaterThan(0).WithMessage("El ID de la mascota debe ser mayor a 0.");

            RuleFor(x => x.VeterinarioId)
                .NotEmpty().WithMessage("El ID del veterinario es obligatorio.")
                .GreaterThan(0).WithMessage("El ID del veterinario debe ser mayor a 0.");
        }
    }

    public class HistorialMedicoUpdateDTOValidator : AbstractValidator<HistorialMedicoUpdateDTO>
    {
        public HistorialMedicoUpdateDTOValidator()
        {
            When(x => x.Fecha.HasValue, () =>
            {
                RuleFor(x => x.Fecha.Value)
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha no puede ser futura.")
                    .GreaterThan(DateTime.Now.AddYears(-50)).WithMessage("La fecha no puede ser mayor a 50 años atrás.");
            });

            When(x => x.TipoConsulta != null, () =>
            {
                RuleFor(x => x.TipoConsulta)
                    .MaximumLength(100).WithMessage("El tipo de consulta no puede exceder los 100 caracteres.");
            });

            When(x => x.Diagnostico != null, () =>
            {
                RuleFor(x => x.Diagnostico)
                    .MaximumLength(2000).WithMessage("El diagnóstico no puede exceder los 2000 caracteres.");
            });

            When(x => x.Tratamiento != null, () =>
            {
                RuleFor(x => x.Tratamiento)
                    .MaximumLength(2000).WithMessage("El tratamiento no puede exceder los 2000 caracteres.");
            });

            When(x => x.Observaciones != null, () =>
            {
                RuleFor(x => x.Observaciones)
                    .MaximumLength(1000).WithMessage("Las observaciones no pueden exceder los 1000 caracteres.");
            });

            When(x => x.PesoRegistrado.HasValue, () =>
            {
                RuleFor(x => x.PesoRegistrado.Value)
                    .GreaterThanOrEqualTo(0).WithMessage("El peso registrado debe ser mayor o igual a 0.")
                    .LessThanOrEqualTo(1000).WithMessage("El peso registrado no puede ser mayor a 1000 kg.");
            });

            When(x => x.Temperatura != null, () =>
            {
                RuleFor(x => x.Temperatura)
                    .MaximumLength(100).WithMessage("La temperatura no puede exceder los 100 caracteres.");
            });
        }
    }
}
