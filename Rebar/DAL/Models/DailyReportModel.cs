using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models;

public class DailyReportModel
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]

    public Guid Id { get; }
    public int NumOfOrdersToday { get; set; }
    public double DailyProfit { get; set; }
}
