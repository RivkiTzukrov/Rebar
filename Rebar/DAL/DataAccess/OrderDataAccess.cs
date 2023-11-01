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

    public async Task<List<OrderModel>> GetTodaysOrders()
    {
        var orderCollection = ConnectToMongo<OrderModel>(OrderCollection);
        var results = await orderCollection.FindAsync(o=> o.OrderCompleted.Date == DateTime.Now.Date);
        return results.ToList();
    }
}
