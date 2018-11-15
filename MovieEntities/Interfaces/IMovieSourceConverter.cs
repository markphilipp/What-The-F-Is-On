using MovieEntities.Models;

namespace MovieEntities.Interfaces
{
    public interface IMovieSourceConverter
    {
        MovieSource GetSourceFromName(string name);
    }
}