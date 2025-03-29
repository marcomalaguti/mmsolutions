namespace MMS.Erp.Application.Features.Employee.Queries.GetAllEmployees;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;

public sealed record GetAllEmployeesQuery : IQuery<IEnumerable<EmployeeDto>?>;