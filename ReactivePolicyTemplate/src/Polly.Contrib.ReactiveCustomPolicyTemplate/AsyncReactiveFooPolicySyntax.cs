namespace Polly.Contrib.ReactiveCustomPolicyTemplate
{
    /// <summary>
    /// Contains configuration syntax for the <see cref="AsyncReactiveFooPolicy"/>
    /// </summary>
    public static class AsyncReactiveFooPolicySyntax
    {
        /// <summary>
        /// Constructs a new instance of <see cref="AsyncReactiveFooPolicy"/>, configured to handle the exceptions specified in the <paramref name="policyBuilder"/>.
        /// </summary>
        /// <param name="policyBuilder">The policy builder.</param>
        /// <returns><see cref="AsyncReactiveFooPolicy"/></returns>
        public static AsyncReactiveFooPolicy AsyncReactiveFoo(this PolicyBuilder policyBuilder
            /* If configuration should be passed when creating the policy, pass it here ... */
        )
        {
            return new AsyncReactiveFooPolicy(
                policyBuilder.ExceptionPredicates
                /* ... and pass it on to the constructor. */
            );
        }
    }
}
