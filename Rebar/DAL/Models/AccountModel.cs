namespace DAL.Models;

public class AccountModel
{
    public string CustomerName { get; set; }
    public Guid Id { get; set; }
    public List<Order> Orders { get; set; }
    public double SumOfOrders { get; set; }

    public AccountModel()
    {
        Orders = new List<Order>();
        Id = Guid.NewGuid();
    }
}
