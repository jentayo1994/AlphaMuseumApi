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
    [Route("api/Articles")]
    public class ArticlesController : Controller
    {
        private readonly MongoDbContext _dbContext;
        public ArticlesController(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<Article>> GetArticles([FromQuery] FilterModel filter)
        {
            return await _dbContext.Articles.Find(_ => true).Skip(filter.Skip).Limit(filter.Limit).ToListAsync();
        }
        [HttpGet]
        [Route("count")]
        public async Task<long> GetCountOfArticles()
        {
            return await _dbContext.Articles.CountAsync(_ => true);
        }
    }
}