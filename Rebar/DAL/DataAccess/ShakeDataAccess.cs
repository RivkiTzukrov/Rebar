using DAL.Models;
using MongoDB.Driver;

namespace DAL.DataAccess;

public class ShakeDataAccess : DataAccess
{
    private const string ShakeCollection = "shake";

    public Task CreateShake(ShakeModel shake)
    {
        var shakeCollection = ConnectToMongo<ShakeModel>(ShakeCollection);
        return shakeCollection.InsertOneAsync(shake);
    }

    public async Task<List<ShakeModel>> GetAllShakes()
    {
        var shakesCollection = ConnectToMongo<ShakeModel>(ShakeCollection);
        var results = await shakesCollection.FindAsync(_ => true);
        return results.ToList();
    }
}
