using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class BddResult
    {
        private readonly ITestOutputHelper _output;
        private readonly List<Exception> _errors = new List<Exception>();
        private readonly StringBuilder _messages = new StringBuilder();
        private readonly string _story;

        internal BddResult(ITestOutputHelper output, StepQueue stepQueue)
        {
            _output = output;
            stepQueue.Steps.ForEach(x =>
            {
                try
                {
                    x.Step?.Invoke();
                }
                catch(NotImplementedException e)
                {
                    _errors.Add(e);
                }
                catch (Exception e)
                {
                    _errors.Add(e);
                }
            });
            _errors.ForEach(x => _output.WriteLine($"{x.Message}\r\n"));
            _story = stepQueue.Story();
            _output.WriteLine(_story);
            if (!Success) throw new Exception("Test Failed. See output for more details.");
        }

        public string Story => _story;

        public string ErrorMessages()
        {
            _errors.ForEach(x => _messages.AppendLine($"{x.Message}"));

            return _messages.ToString();
        }

        public List<Exception> Errors()
        {
            return _errors;
        }

        public bool Success => _errors.Count == 0;
    }
}