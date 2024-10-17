using StackExchange.Redis;

namespace RedisCacheSln.Helper
{
    public class RedisConnectionHelper
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection;
        static RedisConnectionHelper()
        {
            RedisConnectionHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect(RedisConfigurationManager.AppSetting["RedisCacheUrl"]);
            });
        }        
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
