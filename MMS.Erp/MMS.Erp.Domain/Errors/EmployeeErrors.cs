namespace MMS.Erp.Domain.Errors;

using MMS.Erp.Domain.Abstractions;

internal static class EmployeeErrors
{
    private static readonly string Code = "EMP";

    public static readonly Error FirstNameNotEmpty = new($"{Code}01", "First name cannot be empty");
    public static readonly Error LastNameNotEmpty = new($"{Code}02", "Last name cannot be empty");
    public static readonly Error FiscalCodeNotEmpty = new($"{Code}03", "Fiscal Code cannot be empty");
}
