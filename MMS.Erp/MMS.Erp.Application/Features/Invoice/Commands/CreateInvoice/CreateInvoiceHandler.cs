namespace MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;

using MediatR;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

internal class CreateInvoiceHandler(IInvoiceRepository invoiceRepository,
                                    IUnitOfWork unitOfWork) : IRequestHandler<CreateInvoiceCommand, int>
{
    public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        string code = $"FPR {request.SequenceNumber}/{DateTime.Now.ToString("yy")}";

        var invoice = Invoice.CreateInvoice(code,
                                            request.InvoiceDate,
                                            request.CustomerId,
                                            request.Amount,
                                            request.VAT,
                                            request.DutyStamp ? 2 : 0);

        await invoiceRepository.AddAsync(invoice);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return invoice.Id;
    }
}
