namespace MMS.Erp.Application.Features.Customer.Commands.CreateCustomer;

using FluentValidation;
using MMS.Erp.Domain.Enums;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        // Name validation
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");

        // Email validation
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");

        // Phone validation
        RuleFor(x => x.Phone)
            .Matches(@"^\+?[0-9]{7,15}$")
            .When(x => x.Phone is not null)
            .WithMessage("Phone number must be valid.");

        // Country validation
        RuleFor(x => x.Country)
            .IsInEnum().WithMessage("Country is required.");

        // City validation
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City must not exceed 100 characters.");

        // Address validation
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

        // VAT Number validation
        RuleFor(x => x.VatNumber)
            .NotEmpty().WithMessage("VAT Number is required.")
            .Matches(@"^[A-Z0-9]{8,12}$").WithMessage("VAT Number must be valid.");
    }
}
