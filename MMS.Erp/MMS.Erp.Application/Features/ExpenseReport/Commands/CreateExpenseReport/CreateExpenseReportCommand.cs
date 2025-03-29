namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;

using MediatR;

public class CreateExpenseReportCommand : IRequest<int>
{
    public int EmployeeId { get; set; }
}
