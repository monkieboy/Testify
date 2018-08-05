using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class FeatureFactory
    {
        private ITestOutputHelper _output;

        public FeatureFactory(ITestOutputHelper output)
        {
            _output = output;

        }

        public Feature Create(string feature, string description)
        {
            return new Feature(_output, feature, description);
        }
    }
}