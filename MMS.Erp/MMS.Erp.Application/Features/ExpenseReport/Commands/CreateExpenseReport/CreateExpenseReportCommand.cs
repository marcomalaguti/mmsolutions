namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;

public class CreateExpenseReportCommand : ICommand<int>
{
    public int EmployeeId { get; set; }
}
