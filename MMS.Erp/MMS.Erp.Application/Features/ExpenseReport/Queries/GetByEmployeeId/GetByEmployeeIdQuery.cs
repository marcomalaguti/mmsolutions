namespace MMS.Erp.Application.Features.ExpenseReport.Queries.GetByEmployeeId;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;

public class GetByEmployeeIdQuery : IQuery<IEnumerable<ExpenseReportDto>?>
{
    public int EmployeeId { get; set; }

    public GetByEmployeeIdQuery(int employeeId)
    {
        EmployeeId = employeeId;
    }
}
