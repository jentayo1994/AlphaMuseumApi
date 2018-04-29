using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlphaMuseumApi.DbContext;
using AlphaMuseumApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ActionModel = AlphaMuseumApi.DbContext.Action;

namespace AlphaMuseumApi.Controllers
{
    [Produces("application/json")]
    [Route("api/actions")]
    public class ActionsController : Controller
    {
        private readonly MongoDbContext _dbContext;

        public ActionsController(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<ActionModel>> GetActions([FromQuery] FilterModel filter)
        {
            return await _dbContext.Actions.Find(_ => true).Skip(filter.Skip).Limit(filter.Limit).ToListAsync();
        }

        [HttpGet]
        [Route("count")]
        public async Task<long> GetCountOfActions()
        {
            return await _dbContext.Actions.CountAsync(_ => true);
        }
    }
}