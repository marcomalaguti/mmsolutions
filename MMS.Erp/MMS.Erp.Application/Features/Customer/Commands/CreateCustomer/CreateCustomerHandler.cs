namespace MMS.Erp.Application.Features.Customer.Commands.CreateCustomer;

using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Repositories;
using MMS.Erp.Domain.Repositories.Customer;

internal class CreateCustomerHandler(ICustomerCommandsRepository customerRepository,
                                     IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerCommand, int>
{
    public async Task<Result<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var createCustomerResult = Customer.Create(request.Name,
                                       request.Email,
                                       request.Phone,
                                       request.Country,
                                       request.City,
                                       request.Address,
                                       request.VatNumber);

        if (createCustomerResult.IsFailure)
            return Result<int>.Failure(createCustomerResult.Error);

        var customer = createCustomerResult.Value!;

        await customerRepository.AddAsync(customer);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(customer.Id);
    }
}