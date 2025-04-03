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

    public void AddExpenseRecord(ExpenseRecord expenseRecord)
    {
        ExpenseRecords.Add(expenseRecord);
    }

    public void RemoveExpenseRecord(ExpenseRecord expenseRecord)
    {
        ExpenseRecords.Remove(expenseRecord);
    }

    public ExpenseRecord? GetExpenseRecord(int expenseRecordId)
    {
        return ExpenseRecords.FirstOrDefault(x => x.Id == expenseRecordId);
    }

    public void SetState(ExpenseReportStateEnum newReportState)
    {
        StateId = newReportState;
    }
}
