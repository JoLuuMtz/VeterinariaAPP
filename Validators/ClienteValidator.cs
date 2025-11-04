using FluentValidation;
using VeterinariaApp.Models;

namespace Veterinaria.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
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

            // Validación de Dirección
            RuleFor(x => x.Direccion)
                .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres.");

            // Validación de FechaRegistro
            RuleFor(x => x.FechaRegistro)
                .NotEmpty().WithMessage("La fecha de registro es obligatoria.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de registro no puede ser futura.");
        }
    }
}

