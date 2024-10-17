namespace RedisCacheSln.Helper
{
    public class RedisConfigurationManager
    {
        public static IConfiguration AppSetting { get; }
        static RedisConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }
}
