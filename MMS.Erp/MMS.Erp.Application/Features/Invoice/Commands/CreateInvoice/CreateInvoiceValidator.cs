namespace MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;

using FluentValidation;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(x => x.SequenceNumber)
            .GreaterThan(0).WithMessage("SequenceNumber must be greater than 0.");

        RuleFor(x => x.InvoiceDate)
            .NotNull().WithMessage("InvoiceDate cannot be null.")
            .LessThanOrEqualTo(DateTime.Now).WithMessage("InvoiceDate cannot be in the future.");

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("CustomerId cannot be empty or default.");

        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than 0.");

        RuleFor(x => x.VAT)
            .InclusiveBetween(0, 100).WithMessage("VAT must be between 0 and 100.");

        RuleFor(x => x.DutyStamp)
            .NotNull().WithMessage("DutyStamp must be specified (true or false).");
    }
}
