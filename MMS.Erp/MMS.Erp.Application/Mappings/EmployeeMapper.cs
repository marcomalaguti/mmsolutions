namespace MMS.Erp.Application.Mappings;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.QueryModels.Employee;
using Riok.Mapperly.Abstractions;
using System.Collections.Generic;

[Mapper]
public static partial class EmployeeMapper
{
    public static partial IEnumerable<EmployeeDto> MapToEmployeeDtoList(IEnumerable<EmployeeModel> employeeModels);
}