namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseRecord;

using FluentValidation;

public class CreateExpenseRecordCommandValidator : AbstractValidator<CreateExpenseRecordCommand>
{
    public CreateExpenseRecordCommandValidator()
    {
        RuleFor(x => x.TypeId)
            .IsInEnum().WithMessage("Invalid expense record type.");

        RuleFor(x => x.Description)
            .MaximumLength(255).WithMessage("Description must not exceed 255 characters.");

        RuleFor(x => x.KmReimbursement)
            .GreaterThanOrEqualTo(0).WithMessage("Kilometer reimbursement must be 0 or greater.")
            .When(x => x.TraveledKm.HasValue);

        RuleFor(x => x.Tolls)
            .GreaterThanOrEqualTo(0).WithMessage("Tolls must be 0 or greater.")
            .When(x => x.TraveledKm.HasValue);

        RuleFor(x => x.Meals)
            .GreaterThanOrEqualTo(0).WithMessage("Meals expense must be 0 or greater.")
            .When(x => x.Meals.HasValue);

        RuleFor(x => x.Accommodation)
            .GreaterThanOrEqualTo(0).WithMessage("Accommodation expense must be 0 or greater.")
            .When(x => x.Accommodation.HasValue);

        RuleFor(x => x.LumpSum) //Forfettario
            .GreaterThanOrEqualTo(0).WithMessage("Lump sum must be 0 or greater.")
            .When(x => x.LumpSum.HasValue);

        RuleFor(x => x.ExpenseReportId)
            .GreaterThan(0).WithMessage("Expense report ID must be greater than 0.");

        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("Employee ID must be greater than 0.");
    }
}

