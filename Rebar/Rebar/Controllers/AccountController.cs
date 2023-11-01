
using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rebar.Controllers;

public class AccountController : BaseController
{
    readonly AccountDataAccess _dataAccess;
    public AccountController()
    {
        _dataAccess = new AccountDataAccess();
    }

    [HttpGet]
    public async Task<ActionResult<List<AccountModel>>> GetAll()
    {
        var result = await _dataAccess.GetAccounts();
        if (result.Count == 0)
        {
            return await Task.FromResult(NoContent());
        }
        return await Task.FromResult(result);
    }

    [HttpPut]
    public async Task Update(AccountModel account)
    {
        var result = _dataAccess.UpdateAccount(account);
        if (result == null)
        {
            await Task.FromResult(NoContent());
        }
        await Task.FromResult(result);
    }
}
