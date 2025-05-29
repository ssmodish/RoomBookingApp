using Microsoft.Data.Sqlite;

namespace RoomBookingApp.Api
{
    public interface IDbHelpers
    {
        SqliteConnection GetPhysicalDbConnection();
        SqliteConnection GetInMemoryDbConnection();
    }
}
