namespace MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Customer;
using MMS.Erp.Domain.Repositories.Invoice;
using System.Threading;
using System.Threading.Tasks;

internal class CreateInvoiceHandler(IInvoiceCommandsRepository invoiceRepository,
                                    ICustomerCommandsRepository customerRepository,
                                    IUnitOfWork unitOfWork) : ICommandHandler<CreateInvoiceCommand, int>
{
    public async Task<Result<int>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var customer = await customerRepository.GetByIdAsync(request.CustomerId);

        if(customer is null)
        {
            return Result<int>.Failure(CustomerErrors.CustomerNotFound);
        }

        string code = $"FPR {request.SequenceNumber}/{DateTime.Now.ToString("yy")}";

        var createInvoiceResult = Invoice.Create(code,
                                            request.InvoiceDate,
                                            customer,
                                            request.Amount,
                                            request.VAT,
                                            request.DutyStamp ? 2 : 0);

        if (createInvoiceResult.IsFailure)
            return Result<int>.Failure(createInvoiceResult.Error);

        var invoice = createInvoiceResult.Value!;

        await invoiceRepository.AddAsync(invoice);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(invoice.Id);
    }
}
