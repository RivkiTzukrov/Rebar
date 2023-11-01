//using DAL.DataAccess;
//using DAL.Models;

//namespace DAL;

//public class ManageRebar
//{
//    private string password = "1234";
//    public Menu Menu { get; set; }
//    public List<AccountModel> accounts { get; set; }

//    public ManageRebar()
//    {
//        InilializeAccounts();
//    }

//    public async void InilializeAccounts()
//    {
//        AccountDataAccess db = new AccountDataAccess();
//        accounts = await db.GetAccounts();
//    }

//    public bool TakeOrder(List<OrderedShake> orderedShakes, List<Discount> discounts, string CustomerName)
//    {
//        if (orderedShakes.Count > 9 || CustomerName == null)
//        {
//            return false;
//        }
//        double sumOfPrices = 0, discount = 0;
//        orderedShakes.ForEach(shake => sumOfPrices += shake.Price);
//        discounts.ForEach(dis => discount += dis.Percent);
//        sumOfPrices = sumOfPrices * (1 - discount);

//        Order order = new Order(CustomerName, orderedShakes, sumOfPrices);
//        OrderModel orderModel = new OrderModel(order);
//        AccountDataAccess accountdb = new AccountDataAccess();
//        AccountModel? account = accounts.Find(a => a.CustomerName == CustomerName);
//        if (account != null)
//        {
//            account.Orders.Add(order);
//            accountdb.UpdateAccount(account);
//        }
//        else
//        {
//            account = new AccountModel();
//            account.Orders.Add(order);
//            accountdb.CreateAccount(account);
//        }
//        InilializeAccounts();
//        OrderDataAccess orderdb = new OrderDataAccess();
//        orderdb.CreateOrder(orderModel);
//        return true;
//    }


//    public async Task<DailyReportModel?> CloseCashRegisterAsync(string password)
//    {
//        if (!this.password.Equals(password))
//        {
//            return null;
//        }
//        int numOfOrdersToday = 0;
//        double dailyProfit = 0;
//        OrderDataAccess orderdb = new OrderDataAccess();
//        var todaysOrders = await orderdb.GetTodaysOrders();
//        numOfOrdersToday = todaysOrders.Count();
//        todaysOrders.ForEach(o => dailyProfit += o.SumOfPrices);
//        DailyReportModel dailyReport = new DailyReportModel() { DailyProfit = dailyProfit, NumOfOrdersToday = numOfOrdersToday };
//        DailyReportDataAccess dailyReportdb = new DailyReportDataAccess();
//        await dailyReportdb.CreateDailyReport(dailyReport);
//        return dailyReport;
//    }
//}
