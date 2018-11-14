using MovieEntities.Mapping.Models;

namespace MovieEntities.Mapping.Interfaces
{
    public interface IMovieSourceConverter
    {
        MovieSource GetSourceFromName(string name);
    }
}