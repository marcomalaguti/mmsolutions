namespace MMS.Erp.Application.Features.ExpenseReport.Commands.DeleteExpenseRecord;

using FluentValidation;

public class DeleteExpenseRecordValidator : AbstractValidator<DeleteExpenseRecordCommand>
{
    public DeleteExpenseRecordValidator()
    {
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("Employee ID must be greater than 0.");

        RuleFor(x => x.ExpenseReportId)
            .GreaterThan(0).WithMessage("Expense Report ID must be greater than 0.");

    }
}
