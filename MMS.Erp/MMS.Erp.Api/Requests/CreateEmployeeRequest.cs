namespace MMS.Erp.Api.Requests;

using MediatR;

public class CreateEmployeeRequest : IRequest<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FiscalCode { get; set; }
}
