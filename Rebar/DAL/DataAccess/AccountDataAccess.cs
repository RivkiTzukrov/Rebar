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

    public Task UpdateAccount(AccountModel account)
    {
        var accountsCollection = ConnectToMongo<AccountModel>(AccountCollection);
        var filter = Builders<AccountModel>.Filter.Eq(a => a.Id, account.Id);
        return accountsCollection.ReplaceOneAsync(filter, account, new ReplaceOptions() { IsUpsert = true });

        //var update = Builders<AccountModel>.Update.Push("Account.$.Orders", order);
        //await accountsCollection.FindOneAndUpdateAsync(filter, update);
    }

    public Task UpdateAccount(OrderModel order)
    {
        var accountsCollection = ConnectToMongo<AccountModel>(AccountCollection);
        var filter = Builders<AccountModel>.Filter.Eq(a => a.CustomerName, order.CustomerName);
        var update = Builders<AccountModel>.Update.Push("Account.Orders", order);
        return accountsCollection.FindOneAndUpdateAsync(filter, update);
    }
}
