namespace MMS.Erp.Application.Features.ExpenseReport.Commands.DeleteExpenseRecord;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;

public class DeleteExpenseRecordCommand : ICommand<Unit>
{
    public int EmployeeId { get; set; }
    public int ExpenseReportId { get; set; }
    public int ExpenseRecordId { get; set; }

    public DeleteExpenseRecordCommand(int employeeId, int expenseReportId, int expenseRecordId )
    {
        EmployeeId = employeeId;
        ExpenseReportId = expenseReportId;
        ExpenseRecordId = expenseRecordId;
    }
}
