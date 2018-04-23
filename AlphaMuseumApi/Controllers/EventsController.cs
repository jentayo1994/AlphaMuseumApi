using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMuseumApi.DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AlphaMuseumApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Events")]
    public class EventsController : Controller
    {
        private MongoDbContext _dbContext;
        public EventsController(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<Event>> GetEvents()
        {
            return await _dbContext.Events.Find(_ => true).ToListAsync();
        }
    }
}