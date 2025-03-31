namespace MMS.Erp.Api.Mappings;

using Mapster;
using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;

public static partial class InvoiceMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<CreateInvoiceRequest, CreateInvoiceCommand>.NewConfig();
    }
}
