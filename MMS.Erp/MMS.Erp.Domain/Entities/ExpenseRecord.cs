namespace MMS.Erp.Domain.Entities;

using MMS.Erp.Domain.AggregateRoots;
using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Primitives;

public class ExpenseRecord : Entity
{
    public int ExpenseReportId { get; set; }
    public ExpenseRecordTypeEnum TypeId { get; set; }
    public required string Description { get; set; }
    public int? TraveledKm { get; set; }
    public decimal? KmReimbursement { get; set; }
    public decimal? Tolls { get; set; }
    public decimal? Meals { get; set; }
    public decimal? Accommodation { get; set; }
    public decimal? LumpSum { get; set; }
    public string? Path { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;


    public ExpenseReport ExpenseReport { get; set; }
}
