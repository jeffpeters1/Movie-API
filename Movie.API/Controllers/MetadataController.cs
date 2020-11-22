using Microsoft.AspNetCore.Mvc;
using Movie.API.Entities;
using Movie.API.Services;
using System;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("metadata")]
    public class MetadataController : ControllerBase
    {
        private readonly IMetadataRepository _metadataRepository;

        public MetadataController(IMetadataRepository metadataRepository)
        {
            _metadataRepository = metadataRepository
                ?? throw new ArgumentNullException(nameof(metadataRepository));
        }

        //========================
        // GET
        //========================

        [HttpGet("{movieId:int}")]
        public IActionResult GetByMovieId(int movieId)
        {
            var movieData = _metadataRepository.GetByMovieId(movieId);
            return Ok(movieData);
        }

        [HttpGet("{metadataId}", Name = "GetByMetadataId")]
        public IActionResult GetByMetadataId(int metadataId)
        {
            var metadata = _metadataRepository.GetById(metadataId);
            return Ok(metadata);
        }

        //========================
        // POST
        //========================

        [HttpPost]
        public ActionResult<Metadata> CreateMetadata(Metadata metadata)
        {
            var metadataId = _metadataRepository.Add(metadata);

            return CreatedAtRoute("GetByMetadataId", new { metadataId }, metadata);
        }
    }
}
