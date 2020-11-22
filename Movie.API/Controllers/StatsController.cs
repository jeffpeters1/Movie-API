using Microsoft.AspNetCore.Mvc;
using Movie.API.Entities;
using Movie.API.Services;
using System;
using System.Collections.Generic;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("movies/stats")]
    public class StatsController : ControllerBase
    {
        private readonly IStatsRepository _statsRepository;

        public StatsController(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository
                ?? throw new ArgumentNullException(nameof(statsRepository));
        }

        //========================
        // GET
        //========================

        [HttpGet()]
        public ActionResult<IEnumerable<Stats>> GetStats()
        {
            var stats = _statsRepository.GetAll();
            return Ok(stats);
        }
    }
}
