using System;
using FluentValidation;
using Veterinaria.DTOs;

namespace Veterinaria.Validators
{
    public class MedicamentoCreateDTOValidator : AbstractValidator<MedicamentoCreateDTO>
    {
        public MedicamentoCreateDTOValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

            RuleFor(x => x.Dosis)
                .MaximumLength(100).WithMessage("La dosis no puede exceder los 100 caracteres.");

            RuleFor(x => x.Frecuencia)
                .MaximumLength(100).WithMessage("La frecuencia no puede exceder los 100 caracteres.");

            RuleFor(x => x.DuracionDias)
                .GreaterThanOrEqualTo(0).WithMessage("La duración en días debe ser mayor o igual a 0.");

            RuleFor(x => x.HistorialMedicoId)
                .NotEmpty().WithMessage("El ID del historial médico es obligatorio.")
                .GreaterThan(0).WithMessage("El ID del historial médico debe ser mayor a 0.");
        }
    }

    public class MedicamentoUpdateDTOValidator : AbstractValidator<MedicamentoUpdateDTO>
    {
        public MedicamentoUpdateDTOValidator()
        {
            When(x => x.Nombre != null, () =>
            {
                RuleFor(x => x.Nombre)
                    .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.");
            });

            When(x => x.Descripcion != null, () =>
            {
                RuleFor(x => x.Descripcion)
                    .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");
            });

            When(x => x.Dosis != null, () =>
            {
                RuleFor(x => x.Dosis)
                    .MaximumLength(100).WithMessage("La dosis no puede exceder los 100 caracteres.");
            });

            When(x => x.Frecuencia != null, () =>
            {
                RuleFor(x => x.Frecuencia)
                    .MaximumLength(100).WithMessage("La frecuencia no puede exceder los 100 caracteres.");
            });

            When(x => x.DuracionDias.HasValue, () =>
            {
                RuleFor(x => x.DuracionDias.Value)
                    .GreaterThanOrEqualTo(0).WithMessage("La duración en días debe ser mayor o igual a 0.");
            });
        }
    }
}
