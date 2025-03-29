namespace MMS.Erp.Domain.AggregateRoots;

using MMS.Erp.Domain.Abstractions;
using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Errors;
using MMS.Erp.Domain.Primitives;

public class Customer : AggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
    public CountryEnum CountryId { get; private set; }
    public string? City { get; private set; }
    public string? Address { get; private set; }
    public string? VatNumber { get; private set; }

    public ICollection<Invoice> Invoices { get; private set; } = new List<Invoice>();

    public Customer()
    {

    }

    private Customer(string name,
                     string? email,
                     string? phone,
                     CountryEnum countryId,
                     string? city,
                     string? address,
                     string vatNumber)
    {
        Name = name;
        Email = email;
        Phone = phone;
        CountryId = countryId;
        City = city;
        Address = address;
        VatNumber = vatNumber;
    }

    public static Result<Customer> Create(string? name,
                                  string? email,
                                  string? phone,
                                  CountryEnum countryId,
                                  string? city,
                                  string? address,
                                  string? vatNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result<Customer>.Failure(CustomerErrors.InvalidName);

        if (string.IsNullOrWhiteSpace(vatNumber))
            return Result<Customer>.Failure(CustomerErrors.VatNumberNotEmpty);

        var customer = new Customer(name, email, phone, countryId, city, address, vatNumber);

        return Result<Customer>.Success(customer);  
    }
}
