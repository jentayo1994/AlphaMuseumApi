using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMuseumApi.DbContext;
using AlphaMuseumApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AlphaMuseumApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private readonly MongoDbContext _dbContext;
        public EventsController(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<Event>> GetEvents([FromQuery] FilterModel filter)
        {
            return await _dbContext.Events.Find(_ => true).Skip(filter.Skip).Limit(filter.Limit).ToListAsync();
        }
        [HttpGet]
        [Route("count")]
        public async Task<long> GetCountOfEvents()
        {
            return await _dbContext.Events.CountAsync(_ => true);
        }
    }
}