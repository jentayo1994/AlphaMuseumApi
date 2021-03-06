﻿using System;
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
    [Route("api/HistoryEvents")]
    public class HistoryEventsController : Controller
    {
        private readonly MongoDbContext _dbContext;
        public HistoryEventsController(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<HistoryEvent>> GetHistoryEvents([FromQuery] FilterModel filter)
        {
            return await _dbContext.HistoryEvents.Find(_ => true).Skip(filter.Skip).Limit(filter.Limit).ToListAsync();
        }

        [HttpGet]
        [Route("count")]
        public async Task<long> GetCountOfHistoryEvents()
        {
            return await _dbContext.HistoryEvents.CountAsync(_ => true);
        }
    }
}