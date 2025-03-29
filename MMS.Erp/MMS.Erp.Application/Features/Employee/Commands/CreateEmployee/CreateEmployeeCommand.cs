namespace MMS.Erp.Application.Features.Employee.Commands.CreateEmployee;

using MediatR;

public class CreateEmployeeCommand : IRequest<int>
{
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string FiscalCode { get; set; }

    public CreateEmployeeCommand()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        FiscalCode = string.Empty;
    }

    public CreateEmployeeCommand(string firstName,
                                 string lastName,
                                 string fiscalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        FiscalCode = fiscalCode;
    }
}
