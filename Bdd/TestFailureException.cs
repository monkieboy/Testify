using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Testify.Bdd
{
    [Serializable]
    public class TestFailureException : Exception
    {
        private readonly string _story;
        private List<Exception> _errors;

        /// List of errors encountered during the test run.
        public List<Exception> Errors => _errors;

        public void SetErrors(List<Exception> value)
        {
            _errors = value;
        }

        public TestFailureException()
        {
        }

        public TestFailureException(string message) : base(message)
        {
        }

        public TestFailureException(string message, string story, List<Exception> errors) : base(message)
        {
            _story = story;
            SetErrors(errors);
        }

        public TestFailureException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TestFailureException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}