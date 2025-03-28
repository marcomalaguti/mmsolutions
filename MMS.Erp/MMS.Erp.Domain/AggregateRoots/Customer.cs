namespace MMS.Erp.Domain.AggregateRoots;

using MMS.Erp.Domain.Enums;
using MMS.Erp.Domain.Primitives;

public class Customer : AggregateRoot
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public CountryEnum CountryId { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? VatNumber { get; set; }

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();


    public Customer()
    {

    }

    private Customer(string name,
                     string email,
                     string phone,
                     CountryEnum countryId,
                     string city,
                     string address,
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

    public static Customer Create(string? name,
                                  string? email,
                                  string? phone,
                                  CountryEnum countryId,
                                  string? city,
                                  string? address,
                                  string? vatNumber)
    {
        var customer = new Customer(name!,
                                    email!,
                                    phone!,
                                    countryId,
                                    city!,
                                    address!,
                                    vatNumber!);
        return customer;
    }
}
