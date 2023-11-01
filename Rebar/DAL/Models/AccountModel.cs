using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAL.Models;

public class AccountModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]

    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public List<Order> Orders { get; set; }
    public double SumOfOrders { get; set; }

    public AccountModel()
    {
        Orders = new List<Order>();
        Id = Guid.NewGuid();
    }
}
