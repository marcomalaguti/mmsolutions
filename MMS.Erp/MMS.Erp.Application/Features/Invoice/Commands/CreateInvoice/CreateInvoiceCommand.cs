namespace MMS.Erp.Application.Features.Invoice.Commands.CreateInvoice;

using MediatR;
using System;

public class CreateInvoiceCommand : IRequest<int>
{
    public int SequenceNumber { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public int VAT { get; set; } = 0;
    public bool DutyStamp { get; set; } = false;
}
