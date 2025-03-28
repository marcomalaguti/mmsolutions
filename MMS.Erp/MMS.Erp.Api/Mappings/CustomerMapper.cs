namespace MMS.Erp.Api.Mappings;

using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Customer.Commands.CreateCustomer;
using Riok.Mapperly.Abstractions;

[Mapper]
public static partial class CustomerMapper
{
    public static partial CreateCustomerCommand MapToCreateCustomerCommand(CreateCustomerRequest invoice);
}
