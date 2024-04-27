using DataTransferLayer.OtherObjects;

namespace ServiceLayer.Helper
{
    public class AppSettings
    {
        public static DtoAppSettings dtoAppSettings;

        public static void Init()
        {
            dtoAppSettings = new DtoAppSettings();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configuration = builder.Build();

            //dtoAppSettings.connetionStringsMySql = configuration.GetConnectionString("MySql");
            dtoAppSettings.originAudience = configuration["Authentication:Jwt:Audiences"];
            dtoAppSettings.originIssuer = configuration["Authentication:Jwt:Issuers"];
            dtoAppSettings.jwtSecret = configuration["Authentication:Jwt:JwtSecret"];
        }

        public static string GetConnectionStringMySql()
        {
            return dtoAppSettings.connetionStringsMySql;
        }

        public static string GetOriginAudience()
        {
            return dtoAppSettings.originAudience;
        }

        public static string GetOriginIssuer()
        {
            return (dtoAppSettings.originIssuer);
        }

        public static string GetJwtSecret()
        {
            return dtoAppSettings.jwtSecret;
        }
    }
}
