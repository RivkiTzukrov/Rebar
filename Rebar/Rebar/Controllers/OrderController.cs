using DAL;
using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rebar.Controllers;

public class OrderController : BaseController
{
    readonly OrderDataAccess _dataAccess;
    public OrderController()
    {
        _dataAccess = new OrderDataAccess();
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderModel>>> GetTodaysOrders()
    {
        var result = await _dataAccess.GetTodaysOrders();
        if (result.Count == 0)
        {
            return await Task.FromResult(NoContent());
        }
        return await Task.FromResult(result);
    }

    [HttpPost]
    public async Task Post(Order order)
    {
        if (order == null || order.shakes.Count() > 9 || order.CustomerName == null)
        {
            throw new Exception("Add order failed due to invalid input");
        }
        double discount = 0;
        order.Discounts.ForEach(dis => discount += dis.Percent);
        order.SumOfPrices *= (1 - discount);
        OrderModel orderModel = new OrderModel(order);
        await Task.FromResult(_dataAccess.CreateOrder(orderModel));
        AccountDataAccess accountdb = new AccountDataAccess();
        await accountdb.UpdateAccount(orderModel);
    }
}
