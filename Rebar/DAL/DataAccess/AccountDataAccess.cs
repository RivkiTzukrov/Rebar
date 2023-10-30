using DAL.Models;
using MongoDB.Driver;
using System;

namespace DAL.DataAccess;

public class AccountDataAccess : DataAccess
{
    private const string AccountCollection = "account";

    public Task CreateAccount(AccountModel account)
    {
        var accountCollection = ConnectToMongo<AccountModel>(AccountCollection);
        return accountCollection.InsertOneAsync(account);
    }

    public async Task<List<AccountModel>> GetAccounts()
    {
        var accountsCollection = ConnectToMongo<AccountModel>(AccountCollection);
        var results = await accountsCollection.FindAsync(_ => true);
        return results.ToList();
    }

    public async Task AddOrderToAccount(OrderModel order, AccountModel a)
    {
        var accountsCollection = ConnectToMongo<AccountModel>(AccountCollection);
        var filter = Builders.Filter.Eq();
        var update = Builders<AccountModel>.Update.Push(a => a.Orders, order);
        return Builders<OrderDataAccess>.Update.Push(filter, order);
    }
}
