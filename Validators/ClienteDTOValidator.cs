using System;
using FluentValidation;
using Veterinaria.DTOs;

namespace Veterinaria.Validators
{
    public class ClienteCreateDTOValidator : AbstractValidator<ClienteCreateDTO>
    {
        public ClienteCreateDTOValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El apellido solo puede contener letras y espacios.");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.")
                .Matches(@"^[\d\s\-\+\(\)]+$").When(x => !string.IsNullOrEmpty(x.Telefono))
                .WithMessage("El teléfono debe contener solo números, espacios, guiones, signos + y paréntesis.");

            RuleFor(x => x.Email)
                .EmailAddress().When(x => !string.IsNullOrEmpty(x.Email))
                .WithMessage("El formato del email no es válido.")
                .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres.");

            RuleFor(x => x.DocumentoIdentidad)
                .MaximumLength(20).WithMessage("El documento de identidad no puede exceder los 20 caracteres.");

            RuleFor(x => x.Direccion)
                .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres.");
        }
    }

    public class ClienteUpdateDTOValidator : AbstractValidator<ClienteUpdateDTO>
    {
        public ClienteUpdateDTOValidator()
        {
            When(x => x.Nombre != null, () =>
            {
                RuleFor(x => x.Nombre)
                    .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.")
                    .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");
            });

            When(x => x.Apellido != null, () =>
            {
                RuleFor(x => x.Apellido)
                    .MaximumLength(100).WithMessage("El apellido no puede exceder los 100 caracteres.")
                    .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El apellido solo puede contener letras y espacios.");
            });

            When(x => x.Telefono != null, () =>
            {
                RuleFor(x => x.Telefono)
                    .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres.")
                    .Matches(@"^[\d\s\-\+\(\)]+$").WithMessage("El teléfono debe contener solo números, espacios, guiones, signos + y paréntesis.");
            });

            When(x => x.Email != null, () =>
            {
                RuleFor(x => x.Email)
                    .EmailAddress().WithMessage("El formato del email no es válido.")
                    .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres.");
            });

            When(x => x.DocumentoIdentidad != null, () =>
            {
                RuleFor(x => x.DocumentoIdentidad)
                    .MaximumLength(20).WithMessage("El documento de identidad no puede exceder los 20 caracteres.");
            });

            When(x => x.Direccion != null, () =>
            {
                RuleFor(x => x.Direccion)
                    .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres.");
            });
        }
    }
}
