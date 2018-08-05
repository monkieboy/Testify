using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class WhenAnd
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;
        private When _when;
        private WhenAnd _whenAnd;
        private string _and;

        public WhenAnd(ITestOutputHelper output, StepQueue stepQueue, string and, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.And, and, step));
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