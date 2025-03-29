namespace MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;

using MediatR;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Customer;
using MMS.Erp.Domain.Repositories.Invoice;
using System.Threading;
using System.Threading.Tasks;

internal class CreateInvoiceHandler(IInvoiceCommandsRepository invoiceRepository,
                                    ICustomerCommandsRepository customerRepository,
                                    IUnitOfWork unitOfWork) : IRequestHandler<CreateInvoiceCommand, int>
{
    public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId) ?? throw new ArgumentNullException(nameof(Customer));

        string code = $"FPR {request.SequenceNumber}/{DateTime.Now.ToString("yy")}";

        var invoice = Invoice.CreateInvoice(code,
                                            request.InvoiceDate,
                                            customer,
                                            request.Amount,
                                            request.VAT,
                                            request.DutyStamp ? 2 : 0);

        await invoiceRepository.AddAsync(invoice);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return invoice.Id;
    }
}
