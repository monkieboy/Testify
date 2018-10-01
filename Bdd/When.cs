using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    /// <summary>
    /// The action step of the spec, use this to identify the main act of the subject under test.
    /// </summary>
    public class When : ISpec
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;
        internal List<Exception> Errors = new List<Exception>();
        internal string Story;
        
        internal When(ITestOutputHelper output, StepQueue stepQueue, string when, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.When, when, step));
        }

        public WhenAnd And(string and, Action step)
        {
            return new WhenAnd(_output, _stepQueue, and, step) {Errors = Errors, Story = Story};
        }

        public Then Then(string then, Action step)
        {
            return new Then(_output, _stepQueue, then, step) {Errors = Errors, Story = Story};
        }
    }
}