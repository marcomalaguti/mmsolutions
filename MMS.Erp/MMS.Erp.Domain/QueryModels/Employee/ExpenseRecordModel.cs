namespace MMS.Erp.Domain.QueryModels.Employee;

using MMS.Erp.Domain.Enums;
using System;

public class ExpenseRecordModel
{
    public ExpenseRecordTypeEnum TypeId { get; set; }
    public string? Description { get; set; }
    public int? TraveledKm { get; set; }
    public decimal? KmReimbursement { get; set; }
    public decimal? Tolls { get; set; }
    public decimal? Meals { get; set; }
    public decimal? Accommodation { get; set; }
    public decimal? LumpSum { get; set; }
    public string? PathToAttachment { get; set; }
    public DateTime? Date { get; set; }
}
