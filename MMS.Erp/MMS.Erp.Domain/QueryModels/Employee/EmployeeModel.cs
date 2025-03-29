namespace MMS.Erp.Domain.QueryModels.Employee;
public class EmployeeModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FiscalCode { get; set; } = string.Empty;

    public EmployeeModel()
    {
        
    }

    public EmployeeModel(string firstName, string lastName, string fiscalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        FiscalCode = fiscalCode;
    }
}
