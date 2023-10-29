namespace DAL;

public class Account
{
    public List<Order> Orders { get; set; }
    public double SumOfOrders { get; set; }

    public Account()
    {
        Orders = new List<Order>();
    }
}
