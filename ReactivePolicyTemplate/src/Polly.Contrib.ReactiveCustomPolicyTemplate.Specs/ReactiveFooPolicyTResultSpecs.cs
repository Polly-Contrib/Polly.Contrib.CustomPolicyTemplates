using System;
using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate.Specs
{
    public class ReactiveFooPolicyTResultSpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical synchronous generic policy fulfills.
             * Real tests should check policy behaviour.
             */
            ReactiveFooPolicy<int> policy = Policy<int>.Handle<Exception>().ReactiveFoo();

            policy.Should().BeAssignableTo<ISyncPolicy<int>>();
            policy.Should().BeAssignableTo<IReactiveFooPolicy<int>>();
        }

        [Fact]
        public void PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            ReactiveFooPolicy<int> policy = Policy<int>.Handle<Exception>().ReactiveFoo();

            policy.Execute(() =>
            {
                executed = true;
                return default(int);
            });

            executed.Should().BeTrue();
        }
    }
}
