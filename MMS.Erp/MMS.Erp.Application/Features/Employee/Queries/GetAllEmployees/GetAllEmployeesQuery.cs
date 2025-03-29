namespace MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

using MediatR;
using MMS.Erp.Application.DTOs;

public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>?>
{
}
