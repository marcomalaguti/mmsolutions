namespace MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mappings;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllEmployeesHandler(IEmployeeQueriesRepository employeeRepository) : IQueryHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>?>
{
    public async Task<Result<IEnumerable<EmployeeDto>?>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetEmployeesAsync(cancellationToken);

        var ret = EmployeeMapper.MapToEmployeeDtoList(employees);

        return Result<IEnumerable<EmployeeDto>?>.Success(ret);
    }
}
