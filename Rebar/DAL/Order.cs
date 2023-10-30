namespace DAL;

public class Order
{
    public Guid Id { get; set; }
    public List<Shake> shakes { get; set; }
    public double SumOfPrices { get; set; }
    public string CustomerName { get; set; }
    public DateTime Date { get; set; }
    public List<Discount> Discounts { get; set; }

    public Order()
    {
        shakes = new List<Shake>();
        Date = DateTime.Now;
        Id = Guid.NewGuid();
    }

    public void AddShakeToOrder(Shake shake)
    {
        SumOfPrices += shake.PriceL;
        shakes.Add(shake);
    }
}
