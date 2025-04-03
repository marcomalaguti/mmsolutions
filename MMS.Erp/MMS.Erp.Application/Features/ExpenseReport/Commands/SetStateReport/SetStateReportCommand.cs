namespace MMS.Erp.Application.Features.ExpenseReport.Commands.SetStateReport;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Enums;

public class SetStateReportCommand : ICommand<Unit>
{
    public int EmployeeId { get; set; }
    public int ExpenseReportId { get; set; }
    public ExpenseReportStateEnum StateId { get; set; }

    public SetStateReportCommand(int employeeId, int expenseReportId, ExpenseReportStateEnum stateId)
    {
        EmployeeId = employeeId;
        ExpenseReportId = expenseReportId;
        StateId = stateId;
    }
}
