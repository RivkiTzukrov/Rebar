﻿using DAL.DataAccess;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Rebar.Controllers;

public class DailyReportController : BaseController
{
    readonly DailyReportDataAccess _dailyReportDataAccess;
    public DailyReportController()
    {
        _dailyReportDataAccess = new DailyReportDataAccess();
    }

    [HttpGet]
    public async Task<ActionResult<List<DailyReportModel>>> GetAll()
    {
        var result = await _dailyReportDataAccess.GetDailyReports();
        if (result.Count == 0)
        {
            return await Task.FromResult(NoContent());
        }
        return await Task.FromResult(result);
    }
}