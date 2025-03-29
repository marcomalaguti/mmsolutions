namespace MMS.Erp.Api.Mappings;

using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Employee.Commands.CreateEmployee;
using Riok.Mapperly.Abstractions;


[Mapper]
public static partial class EmployeeMapper
{
    public static partial CreateEmployeeCommand MapToCreateEmployeeCommand(CreateEmployeeRequest invoice);
}