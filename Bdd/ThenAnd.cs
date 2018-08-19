using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class ThenAnd
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;
        private Then _then;
        private ThenAnd _thenAnd;
        private string _and;

        public ThenAnd(ITestOutputHelper output, StepQueue stepQueue, string and, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.And, and, step));
        }

        public ThenAnd And(string and, Action step)
        {
            return new ThenAnd(_output, _stepQueue, and, step);
        }

        public BddResult Verify()
        {
            return new BddResult(_output, _stepQueue);
        }
    }
}