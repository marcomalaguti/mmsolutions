namespace MMS.Erp.Application.Features.ExpenseReport.Commands.CreateExpenseRecord;

using Microsoft.AspNetCore.Http;
using MMS.Erp.Application.DTOs;
using MMS.Erp.Application.Mediator.Messaging;
using MMS.Erp.Domain.Enums;

public class CreateExpenseRecordCommand : ICommand<ExpenseRecordDto?>
{
    public ExpenseRecordTypeEnum TypeId { get; set; }
    public string? Description { get; set; }
    public int? TraveledKm { get; set; }
    public decimal? KmReimbursement { get; set; }
    public decimal? Tolls { get; set; }
    public decimal? Meals { get; set; }
    public decimal? Accommodation { get; set; }
    public decimal? LumpSum { get; set; }
    public IFormFile? Attachment { get; set; }
    public int ExpenseReportId { get; set; }
    public int EmployeeId { get; set; }
}
