namespace MMS.Erp.Domain.Entities;

using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Primitives;

public class ExpenseReport : Entity
{
    public ExpenseReportStateEnum StateId { get; private set; }
    public DateTime Date { get; private set; } = DateTime.Now;

    public int EmployeeId { get; private set; }

    public ICollection<ExpenseRecord> ExpenseRecords { get; private set; } = new List<ExpenseRecord>();
    
    private ExpenseReport(ExpenseReportStateEnum stateId,
                         DateTime date,
                         int employeeId)
    {
        StateId = stateId;
        Date = date;
        EmployeeId = employeeId;
    }


    public static ExpenseReport CreateExpenseReport(int employeeId)
    {
        return new ExpenseReport(ExpenseReportStateEnum.Draft, DateTime.Now, employeeId);
    }

    internal void SetExpenseRecords(List<ExpenseRecord> expenseRecords)
    {
        ExpenseRecords = expenseRecords ?? new List<ExpenseRecord>();
    }
}
