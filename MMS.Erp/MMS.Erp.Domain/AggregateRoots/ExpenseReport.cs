namespace MMS.Erp.Domain.AggregateRoots;

using MMS.Erp.Domain.Entities;
using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Primitives;

public class ExpenseReport : AggregateRoot
{
    public ExpenseReportStateEnum StateId { get; private set; }
    public DateTime Date { get; private set; } = DateTime.Now;

    // Foreign Key
    public int EmployeeId { get; private set; }
    // Navigation Properties
    public Employee Employee { get; private set; } = null!;
    public ICollection<ExpenseRecord> ExpenseRecords { get; private set; } = new List<ExpenseRecord>();

    public ExpenseReport()
    {
        
    }

    public ExpenseReport(ExpenseReportStateEnum stateId,
                         DateTime date,
                         int employeeId)
    {
        StateId = stateId;
        Date = date;
        EmployeeId = employeeId;
    }

    private ExpenseReport(ExpenseReportStateEnum stateId,
                          DateTime date,
                          Employee employee,
                          List<ExpenseRecord>? expenseRecords = null)
    {
        StateId = stateId;
        Date = date;
        Employee = employee ?? throw new ArgumentNullException(nameof(employee));
        EmployeeId = employee.Id;
        ExpenseRecords = expenseRecords ?? new List<ExpenseRecord>();
    }

    public static ExpenseReport CreateExpenseReport(ExpenseReportStateEnum stateId,
                                                    DateTime date,
                                                    Employee employee,
                                                    List<ExpenseRecord>? expenseRecords = null)
    {
        if (employee == null)
            throw new ArgumentNullException(nameof(employee));

        return new ExpenseReport(stateId, date, employee, expenseRecords);
    }

    internal void SetEmployee(Employee employee)
    {
        Employee = employee ?? throw new ArgumentNullException(nameof(employee));
    }

    internal void SetExpenseRecords(List<ExpenseRecord> expenseRecords)
    {
        ExpenseRecords = expenseRecords ?? new List<ExpenseRecord>();
    }
}
