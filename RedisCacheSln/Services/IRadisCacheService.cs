namespace RedisCacheSln.Services
{
    public interface IRadisCacheService
    {
        /// <summary>
        /// Get Cache Data by key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T GetCacheData<T>(string key);

        /// <summary>
        /// Set Cache Data including key
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expirationTime"></param>
        /// <returns></returns>
        bool SetCacheData<T>(string key, T value, DateTimeOffset expirationTime);

        /// <summary>
        /// Delete Cache Data by using key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object DeleteCacheData(string key);


    }
}
