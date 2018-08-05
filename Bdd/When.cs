using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class When
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;

        public When(ITestOutputHelper output, StepQueue stepQueue, string when, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.When, when, step));
        }

        public WhenAnd And(string and, Action step)
        {
            return new WhenAnd(_output, _stepQueue, and, step);
        }

        public Then Then(string then, Action step)
        {
            return new Then(_output, _stepQueue, then, step);
        }
    }
}