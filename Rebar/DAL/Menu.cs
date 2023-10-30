using DAL.DataAccess;
using DAL.Models;

namespace DAL;

public class Menu
{
    public List<ShakeModel> Shakes { get; set; }

    public Menu()
    {
        InitializeShakes();
    }

    public async void InitializeShakes()
    {
        ShakeDataAccess shakedb = new ShakeDataAccess();
        Shakes = await shakedb.GetAllShakes();
    }

    public List<ShakeModel> ShowMenu()
    {
        return Shakes;
    }

    public void AddShakeToMenu(ShakeModel shake)
    {
        ShakeDataAccess shakedb = new ShakeDataAccess();
        shakedb.CreateShake(shake);
        InitializeShakes();
    }
}
