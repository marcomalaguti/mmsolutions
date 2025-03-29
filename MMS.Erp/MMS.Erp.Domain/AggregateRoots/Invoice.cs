namespace MMS.Erp.Domain.AggregateRoots;

using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Primitives;

#pragma warning disable CS8618
public class Invoice : AggregateRoot
{
    public string Code { get; private set; }
    public DateTime InvoiceDate { get; private set; } = DateTime.Now;
    public decimal Amount { get; private set; }
    public int VAT { get; private set; } = 0;
    public decimal DutyStamp { get; private set; } = 2;
    public bool IsPaid { get; private set; } = false;

    // Foreign Key
    public int CustomerId { get; private set; }
    // Navigation Property (required)
    public Customer Customer { get; private set; } = null!;

    public Invoice()
    {
        
    }

    public Invoice(string code, DateTime invoiceDate, int customerId, decimal amount, int vat, decimal dutyStamp)
    {
        Code = code;
        InvoiceDate = invoiceDate;
        CustomerId = customerId;
        Amount = amount;
        VAT = vat;
        DutyStamp = dutyStamp;
    }

    public Invoice(string code,
                   DateTime invoiceDate,
                   Customer customer,
                   decimal amount,
                   int vat,
                   decimal dutyStamp)
    {
        Code = code;
        InvoiceDate = invoiceDate;
        Customer = customer;
        CustomerId = customer.Id;
        Amount = amount;
        VAT = vat;
        DutyStamp = dutyStamp;
        Customer = customer;
    }

    public static Result<Invoice> Create(string code,
                                       DateTime invoiceDate,
                                       Customer customer,
                                       decimal amount,
                                       int vat,
                                       decimal dutyStamp = 2)
    {
        if (customer is null)
            Result<Invoice>.Failure(CustomerErrors.CustomerNotFound);

        var invoice = new Invoice(code,
                                  invoiceDate,
                                  customer!,
                                  amount,
                                  vat,
                                  dutyStamp);

        return Result<Invoice>.Success(invoice);
    }
}
