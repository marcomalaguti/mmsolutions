namespace MMS.Erp.Application.Features.Employee.Commands.CreateEmployee;

using MediatR;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class CreateEmployeeHandler(IEmployeeCommandsRepository employeeRepository,
                                     IUnitOfWork unitOfWork) : IRequestHandler<CreateEmployeeCommand, int>
{
    public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = Employee.CreateEmployee(request.FirstName, request.LastName, request.FiscalCode);

        await employeeRepository.AddAsync(employee);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
