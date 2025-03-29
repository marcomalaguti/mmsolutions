namespace MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Entities;
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

    public static Employee CreateEmployee(string firstName, string lastName, string fiscalCode)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));
        if (string.IsNullOrWhiteSpace(fiscalCode))
            throw new ArgumentException("Fiscal Code cannot be empty", nameof(fiscalCode));

        firstName = firstName.Trim();
        firstName = char.ToUpper(firstName[0]) + firstName.Substring(1);

        lastName = lastName.Trim();
        lastName = char.ToUpper(lastName[0]) + lastName.Substring(1);

        fiscalCode = fiscalCode.Trim().ToUpper();

        return new Employee(firstName, lastName, fiscalCode);
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
