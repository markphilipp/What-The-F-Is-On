using System;
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using DataCompiler.Helpers;
using Moq;
using MovieEntities.Models;
using MovieEntities.Repository;
using Xunit;
using TestingInfrastructure;
using MovieRating = MovieEntities.Serialization.MovieRating;

namespace DataCompiler.Tests
{
    public class MissingMovieSourceHelperTests
    {
        [Theory]
        [AutoMoqData]
        public void NewSourcesSaved([Frozen] Mock<IRepository> repository, MissingMovieSourceHelper missingMovieSourceHelper)
        {
            // ARRANGE
            var knownSources = GenerateKnownSources();
            var ratings = GenerateMovieRatings(knownSources);

            repository.Setup(r => r.Set<MovieSource>()).Returns(knownSources);

            // ACT
            missingMovieSourceHelper.AddMissingMovieSources(ratings);

            // ASSERT
            repository.Verify(r => r.AddRange(It.Is<IEnumerable<MovieSource>>(sources => sources.Count() == 1 &&
                                              sources.First().Code == "new-code-source" &&
                                              sources.First().Name == "new-code-source" )));
        }

        private List<MovieSource> GenerateKnownSources()
        {
            return TestingFixture.Current.Build<MovieSource>()
                .CreateMany(2)
                .ToList();
        }

        private static List<MovieRating> GenerateMovieRatings(List<MovieSource> knownSources)
        {
            // Set source to first two known sources
            return TestingFixture.Current
                .Build<MovieRating>()
                .With(r => r.Sources,
                    knownSources
                        .Take(2)
                        .Select(s => s.Code)
                        .Union(new[] { "new-code-source" })
                        .ToArray())
                .CreateMany(20)
                .ToList();
        }
    }
}