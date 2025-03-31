namespace MMS.Erp.Domain.Entities;

using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Primitives;

public class ExpenseRecord : Entity
{
    public ExpenseRecordTypeEnum TypeId { get; private set; }
    public string Description { get; private set; }
    public int? TraveledKm { get; private set; }
    public decimal? KmReimbursement { get; private set; }
    public decimal? Tolls { get; private set; }
    public decimal? Meals { get; private set; }
    public decimal? Accommodation { get; private set; }
    public decimal? LumpSum { get; private set; }
    public string? PathToAttachment { get; private set; }
    public DateTime Date { get; private set; } = DateTime.Now;

    // Foreign Key
    public int ExpenseReportId { get; private set; }
    // Navigation Property (inizializzata con null! per evitare problemi con nullable reference types)
    public ExpenseReport ExpenseReport { get; private set; } = null!;

    public ExpenseRecord()
    {
        
    }

    public ExpenseRecord(ExpenseRecordTypeEnum typeId,
                         string description,
                         int? traveledKm,
                         decimal? kmReimbursement,
                         decimal? tolls,
                         decimal? meals,
                         decimal? accommodation,
                         decimal? lumpSum,
                         string? pathToAttachment,
                         DateTime date,
                         int expenseReportId)
    {
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
        ExpenseReportId = expenseReportId;
    }

    private ExpenseRecord(ExpenseRecordTypeEnum typeId,
                          string description,
                          int? traveledKm,
                          decimal? kmReimbursement,
                          decimal? tolls,
                          decimal? meals,
                          decimal? accommodation,
                          decimal? lumpSum,
                          string? pathToAttachment,
                          int expenseReportId)
    {
        TypeId = typeId;
        Description = description;
        TraveledKm = traveledKm;
        KmReimbursement = kmReimbursement;
        Tolls = tolls;
        Meals = meals;
        Accommodation = accommodation;
        LumpSum = lumpSum;
        PathToAttachment = pathToAttachment;
        Date = DateTime.Now;
        ExpenseReportId = expenseReportId;
    }

    public static Result<ExpenseRecord> Create(ExpenseRecordTypeEnum typeId,
                                               string description,
                                               int? traveledKm,
                                               decimal? kmReimbursement,
                                               decimal? tolls,
                                               decimal? meals,
                                               decimal? accommodation,
                                               decimal? lumpSum,
                                               string? pathToAttachment,
                                               int expenseReportId)
    {
        if (expenseReportId == 0)
            return Result<ExpenseRecord>.Failure(ExpenseReportErrors.NotFound);

        if(string.IsNullOrEmpty(description))
            return Result<ExpenseRecord>.Failure(ExpenseReportErrors.InvalidRecordDescription);

        var expenseRecord = new ExpenseRecord(typeId,
                                              description,
                                              traveledKm,
                                              kmReimbursement,
                                              tolls,
                                              meals,
                                              accommodation,
                                              lumpSum,
                                              pathToAttachment,
                                              expenseReportId);

        return Result<ExpenseRecord>.Success(expenseRecord);
    }
}
