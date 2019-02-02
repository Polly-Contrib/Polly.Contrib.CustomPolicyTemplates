using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate.Specs
{
    public class ProactiveFooPolicySpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical synchronous non-generic policy fulfills.
             * Real tests should check policy behaviour.
             */
            ProactiveFooPolicy policy = ProactiveFooPolicy.Create();

            policy.Should().BeAssignableTo<ISyncPolicy>();
            policy.Should().BeAssignableTo<IProactiveFooPolicy>();
        }

        [Fact]
        public void PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            ProactiveFooPolicy policy = ProactiveFooPolicy.Create();

            policy.Execute(() => executed = true);

            executed.Should().BeTrue();
        }

    }
}
