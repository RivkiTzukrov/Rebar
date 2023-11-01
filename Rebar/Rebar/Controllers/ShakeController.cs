using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rebar.Controllers;

public class ShakeController :BaseController
{
    readonly ShakeDataAccess _dataAccess;
    public ShakeController()
    {
        _dataAccess = new ShakeDataAccess();
    }

    [HttpGet]
    public async Task<ActionResult<List<ShakeModel>>> GetAll()
    {
        var result = await _dataAccess.GetAllShakes();
        if (result.Count == 0)
        {
            return await Task.FromResult(NoContent());
        }
        return await Task.FromResult(result);
    }

    [HttpPost]
    public async Task Post(ShakeModel shake)
    {
        await Task.FromResult(_dataAccess.CreateShake(shake));
    }
}
