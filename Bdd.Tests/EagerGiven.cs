using FluentAssertions;
using Testify.Bdd;
using Xunit;
using Xunit.Abstractions;

namespace Bdd.Tests
{
    [TestCaseOrderer("Bdd.Tests.TestPriorityOrderer", "Bdd.Tests")]
    public class EagerGivenTests
    {
        static int Count { get; set; } 
        private static EagerGiven _evaluatedGiven;

        public EagerGivenTests(ITestOutputHelper output)
        {
            var featureFactory = new FeatureFactory(output: output);
            _evaluatedGiven = _evaluatedGiven ?? featureFactory
                .Create("EagerGiven", "Testing an eagerly evaluated Given")
                .WithScenario("Eager call")
                .Given("step is setup", () => Count++)
                .Eagerly();
        }
        
        [Fact, TestPriority(1)]
        public void TestA_Should_run_Given_step_eagerly()
        {
            _evaluatedGiven
                .When("counter is incremented by this test", () => Count++)
                .Then("count is incremented to 2", () => Count.Should().Be(2))
                .Verify();
        }
        
        [Fact, TestPriority(2)]
        public void TestB_Should_run_repeated_Given_step_eagerly_so_count_increases_only_in_the_When_as_the_given_has_already_executed()
        {
            _evaluatedGiven
                .When("repeating counter increment", () => Count++)
                .Then("count is incremented to 3", () => Count.Should().Be(3))
                .Verify();
        }
        
    }
}