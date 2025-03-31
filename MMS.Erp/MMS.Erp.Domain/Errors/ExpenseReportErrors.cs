namespace MMS.Erp.Domain.Errors;

using MMS.Erp.Domain.Abstractions;


public static class ExpenseReportErrors
{
    private static readonly string Code = "ERP";

    public static readonly Error NotFound = new($"{Code}01", "Expense Report not found");
    public static readonly Error EmployeeNotFound = new($"{Code}02", "Employee not found");
    public static readonly Error InvalidRecordDescription = new($"{Code}03", "Record description cannot be empty");
}