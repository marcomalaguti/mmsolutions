namespace MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.Enums;

public class ExpenseReportDto
{
    public int Id { get; set; }
    public ExpenseReportStateEnum StateId { get; set; }
    public DateTime Date { get; set; }
    public int EmployeeId { get; set; }
    public IEnumerable<ExpenseRecordDto> Records { get; set; } = new List<ExpenseRecordDto>();
    public string Label => $"{Id} - {Date.ToString("MMMM yyyy")}";

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