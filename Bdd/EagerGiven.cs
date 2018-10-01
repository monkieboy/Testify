using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    /// <summary>
    /// Use this if you want your test to evaluate once in a setup, set a static field in your ctor and use null coalesce to check if it has already been evaluated.
    /// </summary>
    public class EagerGiven
    {
        private readonly ITestOutputHelper _output;
        private readonly StepQueue _stepQueue;
        private readonly List<Exception> _errors = new List<Exception>();
        private string _story;
        private bool _invoked;

        internal EagerGiven(ITestOutputHelper output, StepQueue stepQueue)
        {
            _output = output;
            _stepQueue = stepQueue;
        }

        private bool Success => _errors.Count == 0;
        
        public GivenAnd And(string and, Action step)
        {
            Evaluate();            
            return new GivenAnd(_output, new StepQueue(), and, step) {Errors = _errors, Story = _story};
        }

        public When When(string when, Action step)
        {
            Evaluate();
            return new When(_output, new StepQueue(), when, step);
        }

        private void Evaluate()
        {
            if (_invoked)
            {
                _output.WriteLine(_story);
                return;
            }

            try
            {
                _stepQueue.Steps.ForEach(x =>
                {
                    try
                    {
                        x.Step?.Invoke();
                    }
                    catch (NotImplementedException e)
                    {
                        _errors.Add(e);
                    }
                    catch (Exception e)
                    {
                        _errors.Add(e);
                    }
                });
                _errors.ForEach(x => _output.WriteLine($"{x.Message}\r\n"));
                _story = _stepQueue.Story();
                _output.WriteLine(_story);
                if (!Success)
                    throw new TestFailureException("Test Failed. See output for more details.", _story, _errors);
            }
            finally
            {
                _invoked = true;
            }
        }
    }
}