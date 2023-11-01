using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models;


public class OrderModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]

    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public DateTime OrderCreated { get; set; }
    public DateTime OrderCompleted { get; set; }
    public double SumOfPrices { get; set; }
    public List<Guid> ShakeIds { get; set; }

    public OrderModel(Order order)
    {
        Id = order.Id;
        CustomerName = order.CustomerName;
        OrderCreated = order.Date;
        OrderCompleted = DateTime.Now;
        SumOfPrices = order.SumOfPrices;
        ShakeIds = new List<Guid>();
        foreach (var shake in order.shakes)
        {
            ShakeIds.Add(shake.Id);
        }
    }

    public OrderModel(string customerName, double sumOfPrices)
    {
        Id = Guid.NewGuid();
        CustomerName = customerName;
        OrderCreated = DateTime.Now;
        SumOfPrices = sumOfPrices;
        ShakeIds = new List<Guid>() { new Guid(), new Guid() };
    }
}
