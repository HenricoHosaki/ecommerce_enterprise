using EnterpriseGateway.Api.Domain.Enums;

namespace EnterpriseGateway.Api.Domain.Entities;

public class Customer
{
    public Guid Id {get; private set;}
    public string Name {get; set;}
    public string Email {get; set;}
    public DateTime CreatedAt {get; set;}
    public CustomerStatus Status {get; set;}

    public Customer(Guid id, string name, string email, DateTime createdAt, CustomerStatus status)
    {
        Id = id;
        Name = name;
        Email = email;
        CreatedAt = createdAt;
        Status = status;
    }
}