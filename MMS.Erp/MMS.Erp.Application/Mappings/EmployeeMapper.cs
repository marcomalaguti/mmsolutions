namespace MMS.Erp.Application.Mappings;

using Mapster;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.QueryModels.Employee;

public static partial class EmployeeMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<EmployeeModel, EmployeeDto>.NewConfig();
    }
}