namespace MMS.Erp.Domain.Errors;

using MMS.Erp.Domain.Abstractions;

public static class CustomerErrors
{
    private static readonly string Code = "CST";

    public static readonly Error InvalidName = new($"{Code}01", "Name cannot be empty");
    public static readonly Error InvalidEmail = new($"{Code}01", "Email cannot be empty");
    public static readonly Error VatNumberNotEmpty = new($"{Code}03", "Vat number cannot be empty");
    public static readonly Error CustomerNotFound = new($"{Code}04", "Customer not found");
}