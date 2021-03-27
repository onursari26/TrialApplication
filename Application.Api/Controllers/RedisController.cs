using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StackExchange.Redis;
using Application.Redis.Enums;
using Application.Redis.Interfaces;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Application.Core.Context;
using Application.Data.Entities.Concrete;

namespace Application.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IRedisService _redisService;

        private readonly IDatabase _redisStringDb;
        private readonly IDatabase _redisListDb;
        private readonly IDatabase _redisSetDb;
        private readonly IDatabase _redisHashDb;

        private const string stringKey = "stringKey";
        private const string listKey = "listKey";
        private const string setKey = "setKey";
        private const string hashKey = "hashKey";

        AplicationContext _context;
        public RedisController(IRedisService redisService, AplicationContext context)
        {
            _redisService = redisService;

            _redisStringDb = _redisService.GetDatabase(RedisDbType.String);
            _redisListDb = _redisService.GetDatabase(RedisDbType.List);
            _redisSetDb = _redisService.GetDatabase(RedisDbType.Set);
            _redisHashDb = _redisService.GetDatabase(RedisDbType.Hash);

            _context = context;
        }

        [HttpPost]
        [Route("api/setString")]
        public async Task<IActionResult> StringSet(object value)
        {
            await _redisStringDb.StringSetAsync(stringKey, JsonConvert.SerializeObject(value));

            return Ok();
        }

        [HttpGet]
        [Route("api/getString")]
        public async Task<IActionResult> StringGet()
        {
            var result = await _redisStringDb.StringGetAsync(stringKey);

            var json = JsonConvert.DeserializeObject(result);

            return Ok(json);
        }

        [HttpPost]
        [Route("api/listPush")]
        public async Task<IActionResult> ListPush(object data)
        {
            await _redisListDb.ListLeftPushAsync(listKey, JsonConvert.SerializeObject(data));

            return Ok();
        }

        [HttpGet]
        [Route("api/getList")]
        public async Task<IActionResult> GetList()
        {
            List<object> objects = new();

            var result = await _redisListDb.ListRangeAsync(listKey);

            result.ToList().ForEach(x =>
            {
                objects.Add(JsonConvert.DeserializeObject(x));
            });


            return Ok(objects);
        }

        [HttpPost]
        [Route("api/setAdd")]
        public async Task<IActionResult> SetAdd(object data)
        {
            await _redisSetDb.SetAddAsync(setKey, JsonConvert.SerializeObject(data));

            return Ok();
        }

        [HttpGet]
        [Route("api/members")]
        public async Task<IActionResult> SetMembers()
        {
            List<object> objects = new();

            var result = await _redisSetDb.SetMembersAsync(setKey);

            result.ToList().ForEach(x =>
            {
                objects.Add(JsonConvert.DeserializeObject(x));
            });


            return Ok(objects);
        }

        [HttpPost]
        [Route("api/hashSet")]
        public async Task<IActionResult> HashSet(string name, object value)
        {
            await _redisHashDb.HashSetAsync(hashKey, name, JsonConvert.SerializeObject(value));

            return Ok();
        }

        [HttpGet]
        [Route("api/hashGet")]
        public async Task<IActionResult> HashGetAll()
        {
            Dictionary<string, object> objects = new();

            var result = await _redisHashDb.HashGetAllAsync(hashKey);

            result.ToList().ForEach(x =>
            {
                objects.Add(x.Name, JsonConvert.DeserializeObject(x.Value));
            });


            return Ok(objects);
        }
    }
}
