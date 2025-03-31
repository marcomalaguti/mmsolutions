namespace MMS.Erp.Application.Mappings;

using Mapster;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.AggregateRoots;


public static partial class InvoiceMapper
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Invoice, InvoiceDto>.NewConfig();
    }
}
