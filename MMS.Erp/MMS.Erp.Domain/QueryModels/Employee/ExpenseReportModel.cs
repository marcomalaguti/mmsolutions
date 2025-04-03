namespace MMS.Erp.Domain.QueryModels.Employee;

using MMS.Erp.Domain.Enums;
using System;

public class ExpenseReportModel
{
    public int Id { get; set; }
    public ExpenseReportStateEnum StateId { get; set; }
    public DateTime Date { get; set; }
    public int EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmployeeName => $"{FirstName} {LastName}";
}

