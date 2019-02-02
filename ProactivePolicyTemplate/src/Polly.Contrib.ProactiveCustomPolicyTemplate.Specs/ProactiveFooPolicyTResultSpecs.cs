using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate.Specs
{
    public class ProactiveFooPolicyTResultSpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical synchronous generic policy fulfills.
             * Real tests should check policy behaviour.
             */

            ProactiveFooPolicy<int> policy = ProactiveFooPolicy<int>.Create();

            policy.Should().BeAssignableTo<ISyncPolicy<int>>();
            policy.Should().BeAssignableTo<IProactiveFooPolicy<int>>();
        }

        [Fact]
        public void PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            ProactiveFooPolicy<int> policy = ProactiveFooPolicy<int>.Create();

            policy.Execute(() =>
            {
                executed = true;
                return default(int);
            });

            executed.Should().BeTrue();
        }
    }
}
