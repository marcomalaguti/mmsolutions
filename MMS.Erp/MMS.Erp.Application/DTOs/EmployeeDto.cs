namespace MMS.Erp.Application.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? FiscalCode { get; set; }

    public string FullName => $"{FirstName} {LastName}";

};
