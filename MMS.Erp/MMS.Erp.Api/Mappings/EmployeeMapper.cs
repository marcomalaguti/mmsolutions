namespace MMS.Erp.Api.Mappings;

using Mapster;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Employee.Commands.CreateEmployee;


public static partial class EmployeeMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreateEmployeeRequest, CreateEmployeeCommand>.NewConfig();
    }
}