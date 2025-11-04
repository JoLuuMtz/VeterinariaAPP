using FluentValidation;
using Veterinaria.Models;

namespace Veterinaria.Validators
{
    public class MedicamentoValidator : AbstractValidator<Medicamento>
    {
        public MedicamentoValidator()
        {
            // Validación de Nombre
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del medicamento es obligatorio.")
                .MaximumLength(200).WithMessage("El nombre no puede exceder los 200 caracteres.");

            // Validación de Descripción
            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres.");

            // Validación de Dosis
            RuleFor(x => x.Dosis)
                .MaximumLength(100).WithMessage("La dosis no puede exceder los 100 caracteres.");

            // Validación de Frecuencia
            RuleFor(x => x.Frecuencia)
                .MaximumLength(100).WithMessage("La frecuencia no puede exceder los 100 caracteres.");

            // Validación de DuracionDias
            RuleFor(x => x.DuracionDias)
                .GreaterThan(0).WithMessage("La duración en días debe ser mayor a 0.")
                .LessThanOrEqualTo(365).WithMessage("La duración en días no puede ser mayor a 365 días.");

            // Validación de HistorialMedicoId
            RuleFor(x => x.HistorialMedicoId)
                .NotEmpty().WithMessage("El ID del historial médico es obligatorio.")
                .GreaterThan(0).WithMessage("El ID del historial médico debe ser mayor a 0.");
        }
    }
}

