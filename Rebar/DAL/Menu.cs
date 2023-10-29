namespace DAL;

public class Menu
{
    public List<Shake> Shakes { get; set; }
    public Menu()
    {
        Shakes = new List<Shake>();
    }

    public List<Shake> ShowMenu()
    {
        return Shakes;
    }

    public void AddShakeToMenu(Shake shake)
    {
        Shakes.Add(shake);
    }
}
