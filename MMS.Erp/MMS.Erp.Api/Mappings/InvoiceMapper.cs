namespace MMS.Erp.Api.Mappings;

using MMS.Erp.Api.Requests;
using MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;
using Riok.Mapperly.Abstractions;


[Mapper]
public static partial class InvoiceMapper
{
    public static partial CreateInvoiceCommand MapToCreateInvoiceCommand(CreateInvoiceRequest invoice);
}
