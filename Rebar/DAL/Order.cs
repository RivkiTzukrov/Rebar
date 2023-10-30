namespace DAL;

public class Order
{
    public Guid Id { get; set; }
    public List<OrderedShake> shakes { get; set; }
    public double SumOfPrices { get; set; }
    public string CustomerName { get; set; }
    public DateTime Date { get; set; }
    public List<Discount> Discounts { get; set; }

    public Order(string customerName, List<OrderedShake> orderedShakes, double sumOfPrices)
    {
        shakes = new List<OrderedShake>();
        Discounts = new List<Discount>();
        Date = DateTime.Now;
        Id = Guid.NewGuid();
        CustomerName = customerName;
        shakes = orderedShakes;
        SumOfPrices = sumOfPrices;
    }

    //public void AddShakeToOrder(OrderedShake shake)
    //{
    //    SumOfPrices += shake.Price;
    //    shakes.Add(shake);
    //}
}
