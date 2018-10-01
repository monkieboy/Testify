using System;
using FluentAssertions;
using Testify.Bdd;
using Xunit;
using Xunit.Abstractions;

namespace Bdd.Tests
{
    public class BddExample
    {
        readonly FeatureFactory _featureFactory;
        private Feature _feature;

        public ITestOutputHelper Output { get; }

        public BddExample(ITestOutputHelper output)
        {
            _featureFactory = new FeatureFactory(output);
            _feature = _featureFactory.Create(
                "Broken Feature",
                "Feature that has a list of errors");
            Output = output;
        }

        private static void Noop() { }

        [Fact]
        public void BddExampleTest()
        {
            var bddResult = _featureFactory.Create("MyFeature", "Describe this feature")
                .WithScenario("Testing the DSL")
                .Given("All clauses work", Noop)
                .And("The 'ANDS' work", Noop)
                .And("Double check 'AND' on Given", Noop)
                .When("Some activity happened", Noop)
                .And("Something else may have occured", Noop)
                .And("Double check 'And' on When", Noop)
                .Then("About to verify something expected changed", Noop)
                .And("Now then has and also", Noop)
                .Verify();

        }
        

        [Fact]
        public void Test_should_pass()
        {
            var bddResult = _featureFactory.Create("Feature", "Description")
                .WithScenario("Scenario")
                .Given("One", Noop)
                .When("Two", Noop)
                .Then("Three", Noop)
                .Verify();

            bddResult.Success.Should().BeTrue();
        }

        [Fact]
        public void TestFailureException_thrown_when_an_error_is_encountered()
        {
            var ex =
              Assert.ThrowsAny<TestFailureException>(() =>
                _feature
                .WithScenario("This should error")
                .Given("The Given clause is invalid", () => throw new NotImplementedException())
                .When("This clause is called", () => throw new Exception("The When Failed"))
                .Then("This may as well fail also", () => throw new Exception("The Then failed too!"))
                .Verify()
            );

            ex.Errors.Should().HaveCount(3);

            Output.WriteLine($"First Error: {ex.Errors[2].Message}");
        }
    }
}