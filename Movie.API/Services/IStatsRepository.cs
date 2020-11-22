using Movie.API.Entities;
using System.Collections.Generic;

namespace Movie.API.Services
{
    public interface IStatsRepository
    {
        IEnumerable<Stats> GetAll();
    }
}
