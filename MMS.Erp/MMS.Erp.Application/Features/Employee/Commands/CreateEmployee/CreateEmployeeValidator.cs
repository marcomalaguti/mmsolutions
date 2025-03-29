namespace MMS.Erp.Application.Features.Employee.Commands.CreateEmployee;

using FluentValidation;

public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        // FirstName validation
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        // LastName validation
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        // FiscalCode validation
        RuleFor(x => x.FiscalCode)
            .NotEmpty().WithMessage("Fiscal code is required.")
            .Length(16).WithMessage("Fiscal code must be 16 characters long.")
            .Matches("^[A-Z0-9]+$").WithMessage("Fiscal code must contain only uppercase letters and numbers.");
    }
}