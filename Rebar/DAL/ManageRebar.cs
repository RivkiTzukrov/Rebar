using DAL.DataAccess;
using DAL.Models;

namespace DAL;

public class ManageRebar
{
    private string password = "1234";
    public int NumOfOrdersToday { get; set; }
    public double DailyProfit { get; set; }
    public Menu Menu { get; set; }
    public List<AccountModel> accounts { get; set; }

    public ManageRebar()
    {
        InilializeAccount();
    }

    public async void InilializeAccount()
    {
        AccountDataAccess db = new AccountDataAccess();
        accounts = await db.GetAccounts();
    }

    public List<ShakeModel> ShowMenu()
    {
        return Menu.ShowMenu();
    }

    public bool TakeOrder(List<OrderedShake> orderedShakes, string CustomerName, double sumOfPrices)
    {
        if (orderedShakes.Count >9 || CustomerName == null)
        {
            return false;
        }
        Order order = new Order(CustomerName, orderedShakes, sumOfPrices);
        OrderModel orderModel = new OrderModel(order);
        OrderDataAccess db = new OrderDataAccess();
        db.CreateOrder(orderModel);
        return true;
    }

    public void AddShakeToMenu(ShakeModel shake)
    {
        Menu.AddShakeToMenu(shake);
    }
}
