using System;
using System.Collections.Generic;
using System.Text;

namespace Testify.Bdd
{
    public class StepQueue
    {
        internal readonly List<Spec> Steps;
        private readonly StringBuilder _story = new StringBuilder();

        private void UpdateStory(Spec spec) => _story.AppendLine(spec.ToString());

        public StepQueue() => Steps = new List<Spec>();

        internal void Enqueue(Spec spec)
        {
            UpdateStory(spec);
            Steps.Add(spec);
        }

        internal string Story()
        {
            return _story.ToString();
        }
    }
}
