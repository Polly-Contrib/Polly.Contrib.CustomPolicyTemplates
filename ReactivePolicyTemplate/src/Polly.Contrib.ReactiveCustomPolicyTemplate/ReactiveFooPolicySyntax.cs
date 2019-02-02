namespace Polly.Contrib.ReactiveCustomPolicyTemplate
{
    /// <summary>
    /// Contains configuration syntax for the <see cref="ReactiveFooPolicy"/>
    /// </summary>
    public static class ReactiveFooPolicySyntax
    {
        /// <summary>
        /// Constructs a new instance of <see cref="ReactiveFooPolicy"/>, configured to handle the exceptions specified in the <paramref name="policyBuilder"/>.
        /// </summary>
        /// <param name="policyBuilder">The policy builder.</param>
        /// <returns><see cref="ReactiveFooPolicy"/></returns>
        public static ReactiveFooPolicy ReactiveFoo(this PolicyBuilder policyBuilder
            /* If configuration should be passed when creating the policy, pass it here ... */
        )
        {
            return new ReactiveFooPolicy(
                policyBuilder.ExceptionPredicates
                /* ... and pass it on to the constructor. */
            );
        }
    }
}
