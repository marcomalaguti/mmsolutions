namespace MMS.Erp.Application.Features.ExpenseReport.Commands.DeleteExpenseRecord;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Application.Services.ExpenseReport;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class DeleteExpenseRecordHandler(IEmployeeCommandsRepository employeeCommandsRepository,
                                          IExpenseReportService expenseReportService,
                                          IUnitOfWork unitOfWork) 
    : ICommandHandler<DeleteExpenseRecordCommand, Unit>
{
    public async Task<Result<Unit>> Handle(DeleteExpenseRecordCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeCommandsRepository.GetByIdAsync(request.EmployeeId);

        if (employee is null)
            return Result<Unit>.Failure(ExpenseReportErrors.EmployeeNotFound);

        var expenseReport = employee.ExpenseReports.FirstOrDefault(x => x.Id == request.ExpenseReportId);

        if (expenseReport is null)
            return Result<Unit>.Failure(ExpenseReportErrors.NotFound);

        var expenseRecord = expenseReport.GetExpenseRecord(request.ExpenseRecordId);

        if(expenseRecord is null)
            return Result<Unit>.Success(Unit.Value);

        if(string.IsNullOrWhiteSpace(expenseRecord.PathToAttachment) == false)
        {
            await expenseReportService.DeleteExpenseRecordAttachmentFromBlob(expenseRecord.PathToAttachment);
        }   

        expenseReport.RemoveExpenseRecord(expenseRecord);

        employeeCommandsRepository.Update(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}
