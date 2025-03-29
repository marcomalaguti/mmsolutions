namespace MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;

using MediatR;
using MMS.Erp.Application.Mediator.Messaging;
using System;

public class CreateInvoiceCommand : ICommand<int>
{
    public int SequenceNumber { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public int VAT { get; set; } = 0;
    public bool DutyStamp { get; set; } = false;
}
