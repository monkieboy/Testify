using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    /// <summary>
    /// Specify the scenario of the test to provide more context to the readers of your tests.
    /// </summary>
    public class Scenario
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;

        internal Scenario(ITestOutputHelper output, StepQueue stepQueue, string scenario)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.Scenario, scenario));
        }

        public Given Given(string given, Action step)
        {
            return new Given(_output, _stepQueue, given, step);
        }
    }
}