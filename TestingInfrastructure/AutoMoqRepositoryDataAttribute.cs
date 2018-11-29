using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Moq;
using MovieEntities.Repository;

namespace TestingInfrastructure
{
    public class AutoMoqDataRepositoryAttribute : AutoDataAttribute
    {
        public AutoMoqDataRepositoryAttribute()
            : base(InitializeFixture)
        {

        }

        /// <summary>
        /// Initialization function that is ran upon fixture being needed.  Takes advantage of dynamic creation for
        /// performance reasons
        /// </summary>
        /// <returns>Instance of IFixture for use within the tests</returns>
        private static IFixture InitializeFixture()
        {
            var fixture = new Fixture()
                .Customize(new CompositeCustomization(new AutoMoqCustomization(), new SingletonFixture()));
            fixture.Freeze<Mock<IRepository>>();
            return fixture;
        }
    }
}