namespace MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

internal class GetAllInvoicesHandler : IQueryHandler<GetAllInvoicesQuery, IEnumerable<InvoiceDto>>
{
    public async Task<Result<IEnumerable<InvoiceDto>>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        //var invoices = await invoiceRepository.GetAllAsync();

        //var ret = InvoiceMapper.MapToInvoiceDtoList(invoices);

        //return ret;

        throw new NotImplementedException();
    }
}
