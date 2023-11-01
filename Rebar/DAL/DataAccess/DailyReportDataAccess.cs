using DAL.Models;
using MongoDB.Driver;

namespace DAL.DataAccess;

public class DailyReportDataAccess : DataAccess
{
    private const string DailyReportCollection = "dailyReport";

    public async Task<List<DailyReportModel>> GetDailyReports()
    {
        var dailyReportCollection = ConnectToMongo<DailyReportModel>(DailyReportCollection);
        var results = await dailyReportCollection.FindAsync(_ => true);
        return results.ToList();
    }

    public Task CreateDailyReport(DailyReportModel dailyReport)
    {
        var dailyReportCollection = ConnectToMongo<DailyReportModel>(DailyReportCollection);
        return dailyReportCollection.InsertOneAsync(dailyReport);
    }


}
