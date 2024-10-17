﻿using Newtonsoft.Json;
using RedisCacheSln.Helper;
using StackExchange.Redis;

namespace RedisCacheSln.Services
{
    public class RadisCacheService: IRadisCacheService
    {
        private IDatabase _db;
        public RadisCacheService()
        {
            ConfigureRedis();
        }

        public object DeleteCacheData(string key)
        {
            bool _isKeyExist = _db.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _db.KeyDelete(key);
            }
            return false;
        }

        public T GetCacheData<T>(string key)
        {
            var value = _db.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public bool SetCacheData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }

        private void ConfigureRedis()
        {
            _db = RedisConnectionHelper.Connection.GetDatabase();
        }
    }
}
