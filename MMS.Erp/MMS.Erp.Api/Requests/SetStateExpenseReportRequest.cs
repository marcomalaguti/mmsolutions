namespace MMS.Erp.Api.Requests;

using MMS.Erp.Domain.Enums;

public class SetStateExpenseReportRequest
{
    public ExpenseReportStateEnum StateId { get; set; }
}
