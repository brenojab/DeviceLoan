using System.IO;
using DeviceLoan.Interfaces;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeviceLoan.Droid.Data.SQLite))]
namespace DeviceLoan.Droid.Data
{
    public class SQLite : ISQLite
    {
        public SQLite()
        {
        }

        public SQLiteConnection CreateConnection()
        {
            var fileName = "DeviceLoan.db3";
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, fileName);
            var connection = new SQLiteConnection(path, false);
            return connection;
        }

    }
}