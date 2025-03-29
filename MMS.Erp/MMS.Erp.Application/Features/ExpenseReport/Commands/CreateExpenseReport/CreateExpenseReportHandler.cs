namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseReport;

using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class CreateExpenseReportHandler(IEmployeeCommandsRepository employeeRepository,
                                          IUnitOfWork unitOfWork) : ICommandHandler<CreateExpenseReportCommand, int>
{
    public async Task<Result<int>> Handle(CreateExpenseReportCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId);

        if (employee == null)
            return Result<int>.Failure(ExpenseReportErrors.EmployeeNotFound);

        employee.AddNewExpenseReport();

        employeeRepository.Update(employee);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var expenseReportId = employee.ExpenseReports.Last().Id;

        return Result<int>.Success(expenseReportId);
    }
}
