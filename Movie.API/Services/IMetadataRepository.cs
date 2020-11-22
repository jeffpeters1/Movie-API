using Movie.API.Entities;
using System.Collections.Generic;

namespace Movie.API.Services
{
    public interface IMetadataRepository
    {
        IEnumerable<Metadata> GetAll();

        Metadata GetById(int metadataId);

        List<Metadata> GetByMovieId(int movieId);

        int Add(Metadata metadata);
    }
}
