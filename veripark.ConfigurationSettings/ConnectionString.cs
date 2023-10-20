namespace veripark.ConfigurationSettings
{
    public class ConnectionString
    {
        public ConnectionString() { }
        /// <summary>
        /// dbConnectionString.
        /// </summary>
        public static string? dbConnectionString { get; private set; }

        public static void  ConfigurationService(string _dbconnectionString) {
            dbConnectionString = _dbconnectionString;
        }


    }
}