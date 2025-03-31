namespace MMS.Erp.Application.DTOs;
using MMS.Erp.Domain.Enums;

public class ExpenseRecordDto
{
    public int Id { get; set; }
    public ExpenseRecordTypeEnum TypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public int? TraveledKm { get; set; }
    public decimal? KmReimbursement { get; set; }
    public decimal? Tolls { get; set; }
    public decimal? Meals { get; set; }
    public decimal? Accommodation { get; set; }
    public decimal? LumpSum { get; set; }
    public string? PathToAttachment { get; set; }
    public DateTime Date { get; set; }
    public decimal? Total => 
        ((TraveledKm ?? 0) * (KmReimbursement ?? 0)) +
        (Tolls ?? 0) +
        (Meals ?? 0) +
        (Accommodation ?? 0) +
        (LumpSum ?? 0);
}
