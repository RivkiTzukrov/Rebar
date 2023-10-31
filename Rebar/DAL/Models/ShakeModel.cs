using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace DAL.Models;

public class ShakeModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]

    readonly Guid Id;
    public string Name { get; set; }
    public string Description { get; set; }
    public double PriceL { get; set; }
    public double PriceM { get; set; }
    public double PriceS { get; set; }

    public ShakeModel()
    {
        Id = Guid.NewGuid();
    }
}
