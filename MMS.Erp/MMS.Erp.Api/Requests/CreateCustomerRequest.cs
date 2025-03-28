namespace MMS.Erp.Api.Requests;

public class CreateCustomerRequest
{
    public string? Name { get; set;} 
    public string? Email { get; set;} 
    public string? Phone { get; set; }
    public int? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }
    public string? VatNumber { get; set; }
}
