using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate.Specs
{
    public class AsyncReactiveFooPolicyTResultSpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical asynchronous generic policy fulfills.
             * Real tests should check policy behaviour.
             */
            AsyncReactiveFooPolicy<int> policy = Policy<int>.Handle<Exception>().AsyncReactiveFoo();

            policy.Should().BeAssignableTo<IAsyncPolicy<int>>();
            policy.Should().BeAssignableTo<IReactiveFooPolicy<int>>();
        }

        [Fact]
        public async Task PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            AsyncReactiveFooPolicy<int> policy = Policy<int>.Handle<Exception>().AsyncReactiveFoo();

            await policy.ExecuteAsync(() =>
            {
                executed = true;
                return Task.FromResult(0);
            });

            executed.Should().BeTrue();
        }
    }
}
