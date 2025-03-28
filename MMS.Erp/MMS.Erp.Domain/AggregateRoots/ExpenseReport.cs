namespace MMS.Erp.Domain.AggregateRoots;

using MMS.Erp.Domain.Entities;
using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Primitives;

public class ExpenseReport : AggregateRoot
{
    public ExpenseReportStateEnum StateId { get; set; }
    public int EmployeeId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public IReadOnlyCollection<ExpenseRecord>? Records { get; set; }
}