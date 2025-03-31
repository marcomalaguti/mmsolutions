namespace MMS.Erp.Application.Features.PayCheck.Commands.CreatePayCheck;

using FluentValidation;

public class CreatePayCheckValidator : AbstractValidator<CreatePayCheckCommand>
{
    public CreatePayCheckValidator()
    {
        RuleFor(x => x.PaySlipPdf)
            .NotNull().WithMessage("PaySlip PDF is required.")
            .Must(file => file.ContentType == "application/pdf").WithMessage("PaySlip must be a valid PDF file.");

        RuleFor(x => x.F24Pdf)
            .NotNull().WithMessage("F24 PDF is required.")
            .Must(file => file.ContentType == "application/pdf").WithMessage("F24 must be a valid PDF file.");

        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("Employee ID must be greater than 0.");
    }
}
