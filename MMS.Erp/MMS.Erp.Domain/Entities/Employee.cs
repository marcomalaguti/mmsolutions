namespace MMS.Erp.Domain.Entities;

using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Primitives;

public class Employee : Entity
{
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public ICollection<ExpenseReport> ExpenseReports { get; private set; } = new List<ExpenseReport>();

    private Employee()
    {

    }

    private Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Employee CreateEmployee(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty", nameof(lastName));

        return new Employee(firstName, lastName);
    }

    internal void SetExpenseReports(List<ExpenseReport> expenseReports)
    {
        ExpenseReports = expenseReports ?? new List<ExpenseReport>();
    }
}
