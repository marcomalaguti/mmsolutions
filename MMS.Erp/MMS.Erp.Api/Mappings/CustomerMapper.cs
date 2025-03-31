namespace MMS.Erp.Api.Mappings;

using Mapster;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Customer.Commands.CreateCustomer;


public static partial class CustomerMapper
{

    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreateCustomerRequest, CreateCustomerCommand>.NewConfig();
    }
}
