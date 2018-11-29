using AutoFixture;

namespace TestingInfrastructure
{
    /// <summary>
    /// Registers a single fixture for use within tests
    /// </summary>
    public class SingletonFixture : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            TestingFixture.Current = fixture;
        }
    }
}