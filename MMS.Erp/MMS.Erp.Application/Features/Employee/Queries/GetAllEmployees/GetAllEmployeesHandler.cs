namespace MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

using MediatR;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mappings;
using MMS.Erp.Domain.Repositories.Employee;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllEmployeesHandler(IEmployeeQueriesRepository employeeRepository) : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>?>
{
    public async Task<IEnumerable<EmployeeDto>?> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetEmployeesAsync(cancellationToken);
        var ret = EmployeeMapper.MapToEmployeeDtoList(employees);
        return ret;
    }
}
