using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class Feature
    {
        private readonly ITestOutputHelper _output;
        internal StepQueue StepQueue = new StepQueue();

        internal Feature(ITestOutputHelper output, string feature, string description)
        {
            if (string.IsNullOrWhiteSpace(feature)) throw new ArgumentNullException(nameof(feature), "Feature should be named.");
            _output = output;
            StepQueue.Enqueue(new Spec(SpecType.Feature, feature));
            if (!string.IsNullOrWhiteSpace(description))
                StepQueue.Enqueue(new Spec(SpecType.Description, description));
        }

        public Scenario WithScenario(string scenario)
        {
            return new Scenario(_output, StepQueue, scenario);
        }
    }
}