namespace DAL.Models;

public class ShakeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double PriceL { get; set; }
    public double PriceM { get; set; }
    public double PriceS { get; set; }

    public ShakeModel()
    {
        Id = Guid.NewGuid();
    }
}
