namespace MMS.Erp.Application.Features.Employee.Commands.CreateEmployee;

using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class CreateEmployeeHandler(IEmployeeCommandsRepository employeeRepository,
                                     IUnitOfWork unitOfWork) : ICommandHandler<CreateEmployeeCommand, int>
{
    public async Task<Result<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var createEmployeeResult = Employee.CreateEmployee(request.FirstName, request.LastName, request.FiscalCode);

        if(createEmployeeResult.IsFailure)
            return Result<int>.Failure(createEmployeeResult.Error);

        var employee = createEmployeeResult.Value!;

        await employeeRepository.AddAsync(employee);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(employee.Id);
    }
}
