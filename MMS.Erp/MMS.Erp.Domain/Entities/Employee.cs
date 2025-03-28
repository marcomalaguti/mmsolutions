namespace MMS.Erp.Domain.Entities;

using MMS.Erp.Domain.Primitives;

public class Employee : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    private Employee(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}
