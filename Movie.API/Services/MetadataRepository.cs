using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Movie.API.Entities;
using Movie.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movie.API.Services
{
    public class MetadataRepository : IMetadataRepository
    {
        private readonly IConfiguration config;
        private string filePath;
        private List<Metadata> database = new List<Metadata>();

        public MetadataRepository(IConfiguration config)
        {
            this.config = config;
            filePath = this.config.GetSection("MetadataCsvFilePath").Value;

            GetDataFromCsv();
        }

        //========================
        // GET
        //========================
        public Metadata GetById(int metadataId)
        {
            if (metadataId <= 0)
            {
                throw new ArgumentNullException(nameof(metadataId));
            }

            return database.FirstOrDefault(m => m.Id == metadataId);
        }

        public List<Metadata> GetByMovieId(int movieId)
        {
            if (movieId <= 0)
            {
                throw new ArgumentNullException(nameof(movieId));
            }

            return database.Where(m => m.MovieId == movieId).ToList();
        }

        public IEnumerable<Metadata> GetAll()
        {
            return database.OrderBy(m => m.MovieId);
        }

        //========================
        // POST
        //========================
        public int Add(Metadata metadata)
        {
            var id = GetNextId();

            metadata.Id = id;

            database.Add(metadata);

            return id;
        }

        //========================
        // PRIVATE
        //========================
        private void GetDataFromCsv()
        {
            var reader = new CSVReader<Metadata>();
            var records = reader.GetData(filePath).ToList();

            database.AddRange(records);
        }

        private int GetNextId()
        {
            var maxId = database.Max(x => x.Id);

            return ++maxId;
        }
    }
}
