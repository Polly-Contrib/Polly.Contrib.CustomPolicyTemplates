using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate.Specs
{
    public class AsyncProactiveFooPolicyTResultSpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical asynchronous generic policy fulfills.
             * Real tests should check policy behaviour.
             */
            AsyncProactiveFooPolicy<int> policy = AsyncProactiveFooPolicy<int>.Create();

            policy.Should().BeAssignableTo<IAsyncPolicy<int>>();
            policy.Should().BeAssignableTo<IProactiveFooPolicy<int>>();
        }

        [Fact]
        public async Task PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            AsyncProactiveFooPolicy<int> policy = AsyncProactiveFooPolicy<int>.Create();

            await policy.ExecuteAsync(() =>
            {
                executed = true;
                return Task.FromResult(0);
            });

            executed.Should().BeTrue();
        }

    }
}
