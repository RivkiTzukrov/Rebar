namespace DAL;

public class Order
{
    public Guid Id { get; }
    public List<OrderedShake> shakes { get; set; }
    public double SumOfPrices { get; set; }
    public string CustomerName { get; set; }
    public DateTime Date { get; }
    public List<Discount> Discounts { get; set; }

    public Order()
    {
        Date = DateTime.Now;
        Id = Guid.NewGuid();
    }
}
