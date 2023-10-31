using DAL.Models;

namespace DAL.DataAccess;

public class DailyReportDataAccess : DataAccess
{
    private const string DailyReportCollection = "dailyReport";

    public Task CreateDailyReport(DailyReportModel dailyReport)
    {
        var dailyReportCollection = ConnectToMongo<DailyReportModel>(DailyReportCollection);
        return dailyReportCollection.InsertOneAsync(dailyReport);
    }
}
