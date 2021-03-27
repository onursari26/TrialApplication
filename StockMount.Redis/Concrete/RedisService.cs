using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Application.Redis.Enums;
using Application.Redis.Interfaces;

namespace Application.Redis.Concrete
{
    public class RedisService : IRedisService
    {
        private IConnectionMultiplexer _redis;

        public RedisService(IConfiguration configuration)
        {
            var config = $"{configuration["Redis:Host"]}:{configuration["Redis:Port"]}";

            _redis = ConnectionMultiplexer.ConnectAsync(config).GetAwaiter().GetResult();
        }

        public IDatabase GetDatabase(RedisDbType dbType)
        {
            return _redis.GetDatabase((int)dbType);
        }
    }
}
