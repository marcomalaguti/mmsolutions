namespace MMS.Erp.Application.Features.Customer.Commands.CreateCustomer;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Enums;

public class CreateCustomerCommand : ICommand<int>
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public CountryEnum Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? VatNumber { get; set; }
}
