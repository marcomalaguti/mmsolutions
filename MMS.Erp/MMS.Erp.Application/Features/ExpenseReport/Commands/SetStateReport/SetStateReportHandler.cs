namespace MMS.Erp.Application.Features.ExpenseReport.Commands.SetStateReport;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class SetStateReportHandler(IEmployeeCommandsRepository employeeCommandsRepository,
                                   IUnitOfWork unitOfWork)
    : ICommandHandler<SetStateReportCommand, Unit>
{
    public async Task<Result<Unit>> Handle(SetStateReportCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeCommandsRepository.GetByIdAsync(request.EmployeeId);

        if (employee is null)
            return Result<Unit>.Failure(ExpenseReportErrors.EmployeeNotFound);

        var expenseReport = employee.ExpenseReports.FirstOrDefault(x => x.Id == request.ExpenseReportId);

        if (expenseReport is null)
            return Result<Unit>.Failure(ExpenseReportErrors.NotFound);

        expenseReport.SetState(request.StateId);

        employeeCommandsRepository.Update(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Unit>.Success(Unit.Value);
    }
}