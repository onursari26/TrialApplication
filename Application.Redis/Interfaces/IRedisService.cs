using StackExchange.Redis;
using Application.Redis.Enums;

namespace Application.Redis.Interfaces
{
    public interface IRedisService
    {
        IDatabase GetDatabase(RedisDbType dbType);
    }
}
