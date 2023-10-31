namespace DAL;

public class OrderedShake
{
    public Guid Id { get; }
    public string Name { get; set; }
    public double Price { get; set; }
    public Size Size { get; set; }

    public OrderedShake()
    {
        Id = Guid.NewGuid();
    }

    //public List<OrderedShake> ConvertShakeToOrderedShake(List<Shake> shakes)
    //{
    //    List<OrderedShake> orderedShakes = new List<OrderedShake>();
    //    foreach (var shake in shakes)
    //    {
    //        orderedShakes.Add(new OrderedShake(shake.Name, ));
    //    }
    //}
}


public enum Size
{
    S = 1,
    M,
    L
}