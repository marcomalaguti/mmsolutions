namespace MMS.Erp.Domain.AggregateRoots;

using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Entities;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Primitives;

public class Employee : AggregateRoot
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string FiscalCode { get; private set; } = string.Empty;
    public ICollection<ExpenseReport> ExpenseReports { get; private set; } = new List<ExpenseReport>();

    private Employee()
    {

    }

    private Employee(string firstName, string lastName, string fiscalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        FiscalCode = fiscalCode;
    }

    public static Result<Employee> CreateEmployee(string firstName, string lastName, string fiscalCode)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            return Result<Employee>.Failure(EmployeeErrors.FirstNameNotEmpty);
        if (string.IsNullOrWhiteSpace(lastName))
            return Result<Employee>.Failure(EmployeeErrors.LastNameNotEmpty);
        if (string.IsNullOrWhiteSpace(fiscalCode))
            return Result<Employee>.Failure(EmployeeErrors.FiscalCodeNotEmpty);

        firstName = firstName.Trim();
        firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);

        lastName = lastName.Trim();
        lastName = char.ToUpper(lastName[0]) + lastName.Substring(1);

        fiscalCode = fiscalCode.Trim().ToUpper();

        var employee = new Employee(firstName, lastName, fiscalCode);

        return Result<Employee>.Success(employee);
    }

    internal void SetExpenseReports(List<ExpenseReport> expenseReports)
    {
        ExpenseReports = expenseReports ?? new List<ExpenseReport>();
    }

    public void AddNewExpenseReport()
    {
        ExpenseReports.Add(ExpenseReport.CreateExpenseReport(Id));
    }
}
