using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAL.Models;

public class AccountModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]

    readonly Guid Id;
    public string CustomerName { get; }
    public List<Order> Orders { get; set; }
    public double SumOfOrders { get; set; }

    public AccountModel()
    {
        Orders = new List<Order>();
        Id = Guid.NewGuid();
    }
}
