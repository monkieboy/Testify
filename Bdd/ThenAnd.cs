using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    /// <summary>
    /// This step is supplemental to the Then step, most probably won't be used much in a test suite.
    /// </summary>
    public class ThenAnd : ISpec
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;
        private Then _then;
        private ThenAnd _thenAnd;
        private string _and;
        internal List<Exception> Errors = new List<Exception>();
        internal string Story;

        internal ThenAnd(ITestOutputHelper output, StepQueue stepQueue, string and, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.And, and, step));
        }

        public ThenAnd And(string and, Action step)
        {
            return new ThenAnd(_output, _stepQueue, and, step) {Errors = Errors, Story = Story};
        }

        public BddResult Verify()
        {
            return new BddResult(_output, _stepQueue);
        }
    }
}