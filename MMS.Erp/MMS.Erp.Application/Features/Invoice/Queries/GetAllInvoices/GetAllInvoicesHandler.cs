namespace MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

using MediatR;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mappings;
using MMS.Erp.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllInvoicesHandler(IInvoiceRepository invoiceRepository) : IRequestHandler<GetAllInvoicesQuery, IEnumerable<InvoiceDto>>
{
    public async Task<IEnumerable<InvoiceDto>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await invoiceRepository.GetAllAsync();

        var ret = InvoiceMapper.InvoiceListToInvoiceDtoList(invoices);

        return ret;
    }
}
