namespace MMS.Erp.Application.Features.ExpenseReport.Queries.DownloadExpenseReport;

using FluentValidation;

public class DownloadExpenseReportValidator : AbstractValidator<DownloadExpenseReportQuery>
{
    public DownloadExpenseReportValidator()
    {
        RuleFor(x => x.ExpenseReportId)
             .GreaterThan(0).WithMessage("Expense ReportId ID must be greater than 0.")
             .NotEmpty().WithMessage("Expense ReportId ID is required.");
    }
}
