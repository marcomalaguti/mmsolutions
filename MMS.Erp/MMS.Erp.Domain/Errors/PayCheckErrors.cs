namespace MMS.Erp.Domain.Errors;

using MMS.Erp.Domain.Abstractions;

internal static class PayCheckErrors
{
    private static readonly string Code = "PCK";

    public static readonly Error InvalidEmployeeId = new($"{Code}01", "Employee ID cannot be empty.");
    public static readonly Error InvalidSalary = new($"{Code}02", "Salary amount must be greater than 0.");
    public static readonly Error InvalidTax = new($"{Code}03", "Tax amount must be greater than 0.");
}
