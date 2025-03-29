namespace MMS.Erp.Domain.Errors;

using MMS.Erp.Domain.Abstractions;


public static class ExpenseReportErrors
{
    private static readonly string Code = "ERP";

    public static readonly Error EmployeeNotFound = new($"{Code}01", "Employee not found");
}