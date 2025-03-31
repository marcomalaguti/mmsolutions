namespace MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

using MapsterMapper;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mappings;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllEmployeesHandler(IEmployeeQueriesRepository employeeRepository, IMapper mapper) : IQueryHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>?>
{
    public async Task<Result<IEnumerable<EmployeeDto>?>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetEmployeesAsync(cancellationToken);

        var ret = mapper.Map<IEnumerable<EmployeeDto>>(employees);

        return Result<IEnumerable<EmployeeDto>?>.Success(ret);
    }
}
