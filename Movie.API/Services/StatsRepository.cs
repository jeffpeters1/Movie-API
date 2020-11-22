using Microsoft.Extensions.Configuration;
using Movie.API.Entities;
using Movie.API.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Movie.API.Services
{
    public class StatsRepository : IStatsRepository
    {
        private readonly IConfiguration config;
        private string filePath;
        private List<Stats> database = new List<Stats>();

        public StatsRepository(IConfiguration config)
        {
            this.config = config;
            filePath = this.config.GetSection("StatsCsvFilePath").Value;

            GetDataFromCsv();
        }

        public IEnumerable<Stats> GetAll()
        {
            return database.ToList();
        }

        //========================
        // PRIVATE
        //========================
        private void GetDataFromCsv()
        {
            var reader = new CSVReader<Stats>();
            var records = reader.GetData(filePath).ToList();

            database.AddRange(records);
        }
    }
}
