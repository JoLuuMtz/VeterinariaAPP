using System;
using FluentValidation;
using Veterinaria.DTOs;

namespace Veterinaria.Validators
{
    public class MascotaCreateDTOValidator : AbstractValidator<MascotaCreateDTO>
    {
        public MascotaCreateDTOValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre de la mascota es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");

            RuleFor(x => x.Especie)
                .MaximumLength(50).WithMessage("La especie no puede exceder los 50 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").When(x => !string.IsNullOrEmpty(x.Especie))
                .WithMessage("La especie solo puede contener letras y espacios.");

            RuleFor(x => x.Raza)
                .MaximumLength(100).WithMessage("La raza no puede exceder los 100 caracteres.")
                .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").When(x => !string.IsNullOrEmpty(x.Raza))
                .WithMessage("La raza solo puede contener letras y espacios.");

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de nacimiento no puede ser futura.")
                .GreaterThan(DateTime.Now.AddYears(-50)).WithMessage("La fecha de nacimiento no puede ser mayor a 50 años atrás.");

            RuleFor(x => x.Sexo)
                .MaximumLength(10).WithMessage("El sexo no puede exceder los 10 caracteres.")
                .Must(x => string.IsNullOrEmpty(x) || x.ToLower() == "macho" || x.ToLower() == "hembra")
                .When(x => !string.IsNullOrEmpty(x.Sexo))
                .WithMessage("El sexo debe ser 'Macho' o 'Hembra'.");

            RuleFor(x => x.Color)
                .MaximumLength(50).WithMessage("El color no puede exceder los 50 caracteres.");

            RuleFor(x => x.Peso)
                .GreaterThan(0).WithMessage("El peso debe ser mayor a 0.")
                .LessThanOrEqualTo(1000).WithMessage("El peso no puede ser mayor a 1000 kg.");

            RuleFor(x => x.Observaciones)
                .MaximumLength(500).WithMessage("Las observaciones no pueden exceder los 500 caracteres.");

            RuleFor(x => x.ClienteId)
                .GreaterThan(0).When(x => x.ClienteId.HasValue)
                .WithMessage("El ID del cliente debe ser mayor a 0 si está presente.");
        }
    }

    public class MascotaUpdateDTOValidator : AbstractValidator<MascotaUpdateDTO>
    {
        public MascotaUpdateDTOValidator()
        {
            When(x => x.Nombre != null, () =>
            {
                RuleFor(x => x.Nombre)
                    .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres.")
                    .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("El nombre solo puede contener letras y espacios.");
            });

            When(x => x.Especie != null, () =>
            {
                RuleFor(x => x.Especie)
                    .MaximumLength(50).WithMessage("La especie no puede exceder los 50 caracteres.")
                    .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("La especie solo puede contener letras y espacios.");
            });

            When(x => x.Raza != null, () =>
            {
                RuleFor(x => x.Raza)
                    .MaximumLength(100).WithMessage("La raza no puede exceder los 100 caracteres.")
                    .Matches(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$").WithMessage("La raza solo puede contener letras y espacios.");
            });

            When(x => x.FechaNacimiento.HasValue, () =>
            {
                RuleFor(x => x.FechaNacimiento.Value)
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de nacimiento no puede ser futura.")
                    .GreaterThan(DateTime.Now.AddYears(-50)).WithMessage("La fecha de nacimiento no puede ser mayor a 50 años atrás.");
            });

            When(x => x.Sexo != null, () =>
            {
                RuleFor(x => x.Sexo)
                    .MaximumLength(10).WithMessage("El sexo no puede exceder los 10 caracteres.")
                    .Must(x => x.ToLower() == "macho" || x.ToLower() == "hembra")
                    .WithMessage("El sexo debe ser 'Macho' o 'Hembra'.");
            });

            When(x => x.Color != null, () =>
            {
                RuleFor(x => x.Color)
                    .MaximumLength(50).WithMessage("El color no puede exceder los 50 caracteres.");
            });

            When(x => x.Peso.HasValue, () =>
            {
                RuleFor(x => x.Peso.Value)
                    .GreaterThan(0).WithMessage("El peso debe ser mayor a 0.")
                    .LessThanOrEqualTo(1000).WithMessage("El peso no puede ser mayor a 1000 kg.");
            });

            When(x => x.Observaciones != null, () =>
            {
                RuleFor(x => x.Observaciones)
                    .MaximumLength(500).WithMessage("Las observaciones no pueden exceder los 500 caracteres.");
            });

            When(x => x.ClienteId.HasValue, () =>
            {
                RuleFor(x => x.ClienteId.Value)
                    .GreaterThan(0).WithMessage("El ID del cliente debe ser mayor a 0 si está presente.");
            });
        }
    }
}
