using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class GivenAnd
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;

        public GivenAnd(ITestOutputHelper output, StepQueue stepQueue, string and, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.And, and, step));
        }

        public GivenAnd And(string and, Action step)
        {
            return new GivenAnd(_output, _stepQueue, and, step);
        }

        public When When(string when, Action step)
        {
            return new When(_output, _stepQueue, when, step);
        }
    }
}