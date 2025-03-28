namespace MMS.Erp.Application.Features.Customer.Commands.CreateCustomer;

using MediatR;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;

internal class CreateCustomerHandler(ICustomerRepository customerRepository,
                                     IUnitOfWork unitOfWork) : IRequestHandler<CreateCustomerCommand, int>
{
    public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(request.Name,
                                       request.Email,
                                       request.Phone,
                                       request.Country,
                                       request.City,
                                       request.Address,
                                       request.VatNumber);

        await customerRepository.AddAsync(customer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}