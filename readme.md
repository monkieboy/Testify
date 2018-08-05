## Why

Why even bother to make anything like this? Well, I have in the past not actually been a fan of the tooling around this Space such as Specflow. I am not even sure it is a good idea to promote anything like this at work, which is the main reason I wrote this. It is far from perfect, hell, one commit in, it shouldn't be expected to be fantastic.

The main reason is that I wanted to perform some automation with Selenium, but no one at work knows how to use it and actually perform manual executions of Selenium... Not efficient at all.

The plan is to add this to the proj to use as a guide, so they get used to Selenium. If it stays then great if they get good at it and throw this away then great too, just wanted something to get started, and this is it!

## Usage
Here is a basic usage:

        readonly FeatureFactory _featureFactory;
        private Feature _feature;

        public BddExample(ITestOutputHelper output)
        {
            _featureFactory = new FeatureFactory(output);
            _feature = _featureFactory.Create(
                "Broken Feature",
                "Feature that has a list of errors");
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
                .Verify();