using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    /// <summary>
    /// Use this step after When to add more clauses.
    /// </summary>
    public class WhenAnd : ISpec
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;
        internal List<Exception> Errors = new List<Exception>();
        internal string Story;
        
        internal WhenAnd(ITestOutputHelper output, StepQueue stepQueue, string and, Action step)
        {
            _output = output;
            _stepQueue = stepQueue;
            _stepQueue.Enqueue(new Spec(SpecType.And, and, step));
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