namespace MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

using MediatR;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mappings;
using MMS.Erp.Domain.Repositories.Invoice;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllInvoicesHandler(IInvoiceCommandsRepository invoiceRepository) : IRequestHandler<GetAllInvoicesQuery, IEnumerable<InvoiceDto>>
{
    public async Task<IEnumerable<InvoiceDto>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        var invoices = await invoiceRepository.GetAllAsync();

        var ret = InvoiceMapper.MapToInvoiceDtoList(invoices);

        return ret;
    }
}
