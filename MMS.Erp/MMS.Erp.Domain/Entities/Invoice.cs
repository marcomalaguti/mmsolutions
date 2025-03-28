namespace MMS.Erp.Domain.Entities;

using MMS.Erp.Domain.Primitives;

public class Invoice : Entity
{
    public required string Code { get; set; }
    public DateTime InvoiceDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public int VAT { get; set; } = 0;
    public decimal DutyStamp { get; set; } = 2;
    public bool IsPaid { get; set; } = false;

    public Invoice()
    {

    }

    private Invoice(string code,
                   DateTime invoiceDate,
                   int customerId,
                   decimal amount,
                   int vat,
                   decimal dutyStamp)
    {
        Code = code;
        InvoiceDate = invoiceDate;
        CustomerId = customerId;
        Amount = amount;
        VAT = vat;
        DutyStamp = dutyStamp;
    }

    public static Invoice CreateInvoice(string code,
                                       DateTime invoiceDate,
                                       int customerId,
                                       decimal amount,
                                       int vat,
                                       decimal dutyStamp = 2)
    {
        var invoice = new Invoice(code,
                                  invoiceDate,
                                  customerId,
                                  amount,
                                  vat,
                                  dutyStamp);
        return invoice;
    }
}
