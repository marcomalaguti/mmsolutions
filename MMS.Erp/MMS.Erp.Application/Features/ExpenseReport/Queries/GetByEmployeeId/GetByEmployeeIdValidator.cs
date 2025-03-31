namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetByEmployeeId;

using FluentValidation;

public class GetByEmployeeIdValidator : AbstractValidator<GetByEmployeeIdQuery>
{
    public GetByEmployeeIdValidator()
    {
        RuleFor(x => x.EmployeeId)
             .GreaterThan(0).WithMessage("Employee ID must be greater than 0.")
             .NotEmpty().WithMessage("Employee ID is required.");
    }
}
