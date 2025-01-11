using System;
namespace HasLogistics
{
	public static class Database
	{
		private static string Host { get; set; } = "localHost";
        private static string Port { get; set; } = "5432";
        private static string Username { get; set; } = "postgres";
        private static string Password { get; set; } = "0616";
        private static string DatabaseName { get; set; } = "logisticsdb";

        public static string connectionString = $"" +
            $"Host={Host};" +
            $" Port={Port};" +
            $" Username={Username};" +
            $" Password={Password};" +
            $" Database={DatabaseName};";

    }
}

