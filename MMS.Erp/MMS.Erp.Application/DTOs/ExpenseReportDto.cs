namespace MMS.Erp.Application.DTOs;

using DocumentFormat.OpenXml.Office2010.Excel;
using MMS.Erp.Domain.Enums;

public class ExpenseReportDto
{
    public int Id { get; set; }
    public ExpenseReportStateEnum StateId { get; set; }
    public DateTime Date { get; set; }
    public int EmployeeId { get; set; }
    public IEnumerable<ExpenseRecordDto> Records { get; set; } = new List<ExpenseRecordDto>();

    public string Label => $"{Id} - {Date.ToString("MMMM yyyy")}";
    public decimal Total => Records.Sum(r => 
    r.Total ?? 0);
    public string StateDescription => StateId.ToString();

    public ExpenseReportDto() { }

    public ExpenseReportDto(int id, ExpenseReportStateEnum stateId, DateTime date, int employeeId, IEnumerable<ExpenseRecordDto> records)
    {
        Id = id;
        StateId = stateId;
        Date = date;
        EmployeeId = employeeId;
        Records = records;
    }
}