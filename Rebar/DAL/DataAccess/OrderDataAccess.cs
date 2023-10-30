using DAL.Models;
using MongoDB.Driver;

namespace DAL.DataAccess;

public class OrderDataAccess : DataAccess
{
    private const string OrderCollection = "order";

    public Task CreateOrder(OrderModel order)
    {
        var orderCollection = ConnectToMongo<OrderModel>(OrderCollection);
        return orderCollection.InsertOneAsync(order);
    }
}
