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


    public ExpenseRecordDto() { }


    public ExpenseRecordDto(int id, ExpenseRecordTypeEnum typeId, string description, int? traveledKm, decimal? kmReimbursement, decimal? tolls, decimal? meals, decimal? accommodation, decimal? lumpSum, string? pathToAttachment, DateTime date)
    {
        Id = id;
        TypeId = typeId;
        Description = description;
        TraveledKm = traveledKm;
        KmReimbursement = kmReimbursement;
        Tolls = tolls;
        Meals = meals;
        Accommodation = accommodation;
        LumpSum = lumpSum;
        PathToAttachment = pathToAttachment;
        Date = date;
    }
}
