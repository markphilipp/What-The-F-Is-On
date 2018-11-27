using MovieEntities.Models;

namespace MovieEntities.Interfaces
{
    public interface IMovieSourceConverter
    {
        MovieRatingSource CreateSourceFromName(string code);
    }
}