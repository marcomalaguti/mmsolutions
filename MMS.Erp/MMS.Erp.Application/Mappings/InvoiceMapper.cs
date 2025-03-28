﻿namespace MMS.Erp.Application.Mappings;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.AggregateRoots;
using Riok.Mapperly.Abstractions;


[Mapper]
public static partial class InvoiceMapper
{
    public static partial InvoiceDto MapToInvoiceDto(Invoice invoice);

    public static partial IEnumerable<InvoiceDto> MapToInvoiceDtoList(IEnumerable<Invoice> invoices);
}
