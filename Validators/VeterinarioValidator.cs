using FluentValidation;
using Veterinaria.Models;

namespace Veterinaria.Validators
{
    public class VeterinarioValidator : AbstractValidator<Veterinario>
    {
        public VeterinarioValidator()
        {
            // Validación de Nombre (heredado de Persona)
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");

            // Validación de Apellido (heredado de Persona)
            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")
                .WithMessage("El apellido solo puede contener letras y espacios.");

            // Validación de Teléfono (heredado de Persona)
            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.")
                .Matches(@"^[\d\s\-\+\(\)]+$").When(x => !string.IsNullOrEmpty(x.Telefono))
                .WithMessage("El teléfono debe contener solo números, espacios, guiones, signos + y paréntesis.");

            // Validación de Email (heredado de Persona)
            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("El formato del email no es válido.")
                .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres.");

            // Validación de DocumentoIdentidad (heredado de Persona)
            RuleFor(x => x.DocumentoIdentidad)
                .MaximumLength(20).WithMessage("El documento de identidad no puede exceder los 20 caracteres.");

            // Validación de NumeroLicencia
            RuleFor(x => x.NumeroLicencia)
                .MaximumLength(50).WithMessage("El número de licencia no puede exceder los 50 caracteres.");

            // Validación de Especialidad
            RuleFor(x => x.Especialidad)
                .MaximumLength(100).WithMessage("La especialidad no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").When(x => !string.IsNullOrEmpty(x.Especialidad))
                .WithMessage("La especialidad solo puede contener letras y espacios.");

            // Validación de FechaContratacion
            RuleFor(x => x.FechaContratacion)
                .NotEmpty().WithMessage("La fecha de contratación es obligatoria.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de contratación no puede ser futura.")
                .GreaterThan(DateTime.Now.AddYears(-50))
                .WithMessage("La fecha de contratación no puede ser mayor a 50 años atrás.");
        }
    }
}

