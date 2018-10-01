using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace Testify.Bdd
{
    public class BddResult
    {
        private readonly ITestOutputHelper _output;
        internal List<Exception> Errors = new List<Exception>();
        private readonly StringBuilder _messages = new StringBuilder();

        internal BddResult(ITestOutputHelper output, StepQueue stepQueue, string story = "")
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
                    Errors.Add(e);
                }
                catch (Exception e)
                {
                    Errors.Add(e);
                }
            });
            Errors.ForEach(x => _output.WriteLine($"{x.Message}\r\n"));
            var s = stepQueue.Story();
            _output.WriteLine(s);
            if (!Success) throw new TestFailureException("Test Failed. See output for more details.", s, Errors);
        }

        public string ErrorMessages()
        {
            Errors.ForEach(x => _messages.AppendLine($"{x.Message}"));

            return _messages.ToString();
        }

        public List<Exception> ErrorList()
        {
            return Errors;
        }

        public bool Success => Errors.Count == 0;
    }
}