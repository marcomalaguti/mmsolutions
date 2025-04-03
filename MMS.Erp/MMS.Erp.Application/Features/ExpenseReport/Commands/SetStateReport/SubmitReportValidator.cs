namespace MMS.Erp.Application.Features.ExpenseReport.Commands.SetStateReport;

using FluentValidation;

public class SetStateReportCommandValidator : AbstractValidator<SetStateReportCommand>
{
    public SetStateReportCommandValidator()
    {
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("EmployeeId must be greater than zero.");

        RuleFor(x => x.ExpenseReportId)
            .GreaterThan(0).WithMessage("ExpenseReportId must be greater than zero.");

        RuleFor(x => x.StateId)
            .IsInEnum()
            .WithMessage("Please provide a valid state.");
    }
}