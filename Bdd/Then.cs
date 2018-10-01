using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    /// <summary>
    /// Then Step in the spec build
    /// </summary>
    public class Then : ISpec
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;
        internal List<Exception> Errors = new List<Exception>();
        internal string Story;
        
        internal Then(ITestOutputHelper output, StepQueue stepQueue, string then, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.Then, then, step));
        }

        public ThenAnd And(string and, Action step)
        {
            return new ThenAnd(_output, _stepQueue, and, step) {Errors = Errors, Story = Story};
        }

        public BddResult Verify()
        {
            return new BddResult(_output, _stepQueue, Story) {Errors = Errors};
        }
    }
}