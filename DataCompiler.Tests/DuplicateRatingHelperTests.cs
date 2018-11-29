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

namespace DataCompiler.Tests
{
    public class DuplicateRatingsHelperTests
    {
        [Theory]
        [AutoMoqData]
        public void DuplicateRatingsAreRemoved([Frozen] Mock<IRepository> repository, DuplicateRatingHelper duplicateRatingHelper)
        {
            // ARRANGE
            // Avoid circular references and create a list
            var storedRatings = GenerateMovieRatings();
            var ratings = GenerateMovieRatings();

            repository.Setup(r => r.Set<MovieRating>()).Returns(storedRatings);

            // Flip a stored rating to match a genearted one
            var randomRating = ratings.PickRandom();
            var randomStoredRating = storedRatings.PickRandom();
            randomStoredRating.Id = randomRating.Id;

            // ACT
            duplicateRatingHelper.CleanDuplicateRatings(ratings);

            // ASSERT
            Assert.Empty(ratings.Where(r => r.Id == randomRating.Id));        // Make sure duplicate was removed
        }

        private static List<MovieRating> GenerateMovieRatings()
        {
            return TestingFixture.Current.Build<MovieRating>()
                .Without(r => r.RatingSources)
                .CreateMany(20)
                .ToList();
        }
    }
}