namespace MMS.Erp.Domain.QueryModels.Employee;
public class EmployeeModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FiscalCode { get; set; } = string.Empty;

    public EmployeeModel()
    {
        
    }

    public EmployeeModel(int id, string firstName, string lastName, string fiscalCode)
    {
        Id = id;    
        FirstName = firstName;
        LastName = lastName;
        FiscalCode = fiscalCode;
    }
}
