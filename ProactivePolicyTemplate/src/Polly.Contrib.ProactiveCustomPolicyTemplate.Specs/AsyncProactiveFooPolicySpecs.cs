using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate.Specs
{
    public class AsyncProactiveFooPolicySpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical asynchronous non-generic policy fulfills.
             * Real tests should check policy behaviour.
             */
            AsyncProactiveFooPolicy policy = AsyncProactiveFooPolicy.Create();

            policy.Should().BeAssignableTo<IAsyncPolicy>();
            policy.Should().BeAssignableTo<IProactiveFooPolicy>();
        }

        [Fact]
        public async Task PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            AsyncProactiveFooPolicy policy = AsyncProactiveFooPolicy.Create();

            await policy.ExecuteAsync(() =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            executed.Should().BeTrue();
        }

    }
}
