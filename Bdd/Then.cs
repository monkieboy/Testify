using System;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class Then
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;

        public Then(ITestOutputHelper output, StepQueue stepQueue, string then, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.Then, then, step));
        }

        public BddResult Verify()
        {
            return new BddResult(_output, _stepQueue);
        }
    }
}