namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetById;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;

public class GetByIdQuery : IQuery<ExpenseReportDto?>
{
    public int ExpenseReportId { get; set; }

    public GetByIdQuery(int expenseReportId)
    {
        ExpenseReportId = expenseReportId;
    }
}
