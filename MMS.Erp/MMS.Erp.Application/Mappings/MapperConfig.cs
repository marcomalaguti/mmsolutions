namespace MMS.Erp.Application.Mappings;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.Entities;
using Riok.Mapperly.Abstractions;


[Mapper]
public static partial class InvoiceMapper
{
    public static partial InvoiceDto InvoiceToInvoiceDto(Invoice invoice);
    public static partial IEnumerable<InvoiceDto> InvoiceListToInvoiceDtoList(IEnumerable<Invoice> invoices);
}
