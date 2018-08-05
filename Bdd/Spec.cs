using System;

namespace Testify.Bdd
{
    internal class Spec
    {
        public Spec(SpecType specType, string sentence, Action step = null)
        {
            _specType = specType;
            _sentence = sentence;
            Step = step;
        }

        private readonly string _sentence;
        private readonly SpecType _specType;
        internal readonly Action Step;

        public override string ToString()
        {
            switch (_specType)
            {
                case SpecType.Feature: return $"FEATURE:\r\n\t{_sentence}\r\n";
                case SpecType.Description: return $"DESCRIPTION:\r\n\t{_sentence}\r\n";
                case SpecType.Scenario: return $"SCENARIO:\r\n\t{_sentence}\r\n";
                case SpecType.Given: return $"Given {_sentence}";
                case SpecType.And: return $"\tAnd {_sentence}";
                case SpecType.When: return $"When {_sentence}";
                case SpecType.Then: return $"Then {_sentence}";
                default: return "\r\n\t\t\t---------";
            }
        }
    }
}