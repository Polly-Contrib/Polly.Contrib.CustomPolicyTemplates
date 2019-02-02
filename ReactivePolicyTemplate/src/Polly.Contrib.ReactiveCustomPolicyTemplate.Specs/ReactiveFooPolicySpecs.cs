using System;
using FluentAssertions;
using Xunit;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate.Specs
{
    public class ReactiveFooPolicySpecs
    {
        [Fact]
        public void ReplaceMeWithRealTests()
        {
            /*
             * This test is for illustrative purposes, to show the interfaces a typical synchronous non-generic policy fulfills.
             * Real tests should check policy behaviour.
             */
            ReactiveFooPolicy policy = Policy.Handle<Exception>().ReactiveFoo();

            policy.Should().BeAssignableTo<ISyncPolicy>();
            policy.Should().BeAssignableTo<IReactiveFooPolicy>();
        }

        [Fact]
        public void PolicyExecutesThePassedDelegate()
        {
            bool executed = false;
            ReactiveFooPolicy policy = Policy.Handle<Exception>().ReactiveFoo();

            policy.Execute(() => executed = true);

            executed.Should().BeTrue();
        }
        }
}
