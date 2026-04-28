namespace RatingLists_Backend.Configuration
{
    public static class EnviromentConfig
    {
        public static void Load(string envFilePath)
        {
            if (!File.Exists(envFilePath))
            {
                return;
            }

            foreach (var line in File.ReadAllLines(envFilePath))
            {
                var trimmedLine = line.Trim();

                if (string.IsNullOrWhiteSpace(trimmedLine) || trimmedLine.StartsWith('#'))
                {
                    continue;
                }

                var separatorIndex = trimmedLine.IndexOf('=');
                if (separatorIndex <= 0)
                {
                    continue;
                }

                var key = trimmedLine[..separatorIndex].Trim();
                var value = trimmedLine[(separatorIndex + 1)..].Trim().Trim('"');

                if (string.IsNullOrWhiteSpace(key) || !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(key)))
                {
                    continue;
                }

                Environment.SetEnvironmentVariable(key, value);
            }
        }

        public static string GetPostgresConnectionString()
        {
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost";
            var port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
            var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "ratinglists_db";
            var username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres";

            return $"Host={host};Port={port};Database={database};Username={username};Password={password}";
        }
    }
}
