namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetById;

using FluentValidation;

public class GetByIdValidator : AbstractValidator<GetByIdQuery>
{
    public GetByIdValidator()
    {
        RuleFor(x => x.ExpenseReportId)
             .GreaterThan(0).WithMessage("Expense Report ID must be greater than 0.")
             .NotEmpty().WithMessage("Expense Report ID is required.");

    }
}
