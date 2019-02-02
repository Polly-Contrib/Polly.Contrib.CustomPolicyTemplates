using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate.Specs
{
    public class AsyncReactiveFooPolicySpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical asynchronous non-generic policy fulfills.
             * Real tests should check policy behaviour.
             */
            AsyncReactiveFooPolicy policy = Policy.Handle<Exception>().AsyncReactiveFoo();

            policy.Should().BeAssignableTo<IAsyncPolicy>();
            policy.Should().BeAssignableTo<IReactiveFooPolicy>();
        }

        [Fact]
        public async Task PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            AsyncReactiveFooPolicy policy = Policy.Handle<Exception>().AsyncReactiveFoo();

            await policy.ExecuteAsync(() =>
            {
                executed = true;
                return Task.CompletedTask;
            });

            executed.Should().BeTrue();
        }
    }
}
