using MovieEntities.Models;

namespace MovieEntities.Converters
{
    public interface IMovieSourceConverter
    {
        MovieSource GetSourceFromName(string name);
    }
}