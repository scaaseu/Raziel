using Newtonsoft.Json.Linq;
using Raziel.Core.FileSystem;

namespace Raziel.Database;

public static class InjectJsonCredentials 
{
    public static string Sql(SqlType sqlType) {

        if (sqlType == SqlType.SQLite) {
            string filepath = Path.Combine(Path.Combine(PathFinder.SolutionDir(), "Raziel.Database"), "SQLiteConnectionString.json");

            if (File.Exists(filepath)) {
                using (StreamReader reader = new StreamReader(filepath)) {
                    string json = reader.ReadToEnd();
                    var credentials = JObject.Parse(json);
                    string connectionString = credentials["DefaultConnection"].ToString();
                    return connectionString;
                }
            } else {
                throw new FileNotFoundException($"The SQLite credentials are not found at this path: {filepath}");
            }
        }
        else {
            throw new NotImplementedException();
        }
    }

}