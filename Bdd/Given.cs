using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class Given : ISpec
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;

        internal Given(ITestOutputHelper output, StepQueue stepQueue, string given, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.Given, given, step));
        }

        public EagerGiven Eagerly()
        {
            return new EagerGiven(_output, _stepQueue);
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