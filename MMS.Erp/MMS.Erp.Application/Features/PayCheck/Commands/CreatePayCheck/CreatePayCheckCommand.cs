namespace MMS.Erp.Application.Features.PayCheck.Commands.CreatePayCheck;

using Microsoft.AspNetCore.Http;
using MMS.Erp.Application.Mediator.Messaging;
using System;

public class CreatePayCheckCommand : ICommand<int>
{
    public decimal SalaryAmount { get;  set; }
    public decimal TaxAmount { get;  set; }
    public bool IsSettled { get;  set; }
    public DateTime? Date { get; set; }
    public IFormFile? PaySlipPdf { get; set; }
    public IFormFile? F24Pdf { get; set; }
    public int EmployeeId { get; set; }
}
