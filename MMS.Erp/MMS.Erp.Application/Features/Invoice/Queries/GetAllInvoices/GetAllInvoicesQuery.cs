namespace MMS.Erp.Application.Features.Invoice.Queries.GetAllInvoices;

using MediatR;
using MMS.Erp.Application.DTOs;
using System.Collections.Generic;

public class GetAllInvoicesQuery : IRequest<IEnumerable<InvoiceDto>>
{
}
