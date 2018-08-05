using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class Scenario
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;

        public Scenario(ITestOutputHelper output, StepQueue stepQueue, string scenario)
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