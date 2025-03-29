namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;

using FluentValidation;

public class CreateExpenseReportCommandValidator : AbstractValidator<CreateExpenseReportCommand>
{
    public CreateExpenseReportCommandValidator()
    {
        // EmployeeId validation
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("Employee ID must be greater than 0.")
            .NotEmpty().WithMessage("Employee ID is required.");
    }
}