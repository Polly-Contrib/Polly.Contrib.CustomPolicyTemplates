namespace Polly.Contrib.ReactiveCustomPolicyTemplate
{
    /// <summary>
    /// Contains configuration syntax for the <see cref="ReactiveFooPolicy{TResult}"/>
    /// </summary>
    public static class ReactiveFooPolicyTResultSyntax
    {
        /// <summary>
        /// Constructs a new instance of <see cref="ReactiveFooPolicy{TResult}"/>, configured to handle the exceptions and results specified in the <paramref name="policyBuilder"/>.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="policyBuilder">The policy builder.</param>
        /// <returns><see cref="ReactiveFooPolicy{TResult}"/></returns>
        public static ReactiveFooPolicy<TResult> ReactiveFoo<TResult>(this PolicyBuilder<TResult> policyBuilder
            /* If configuration should be passed when creating the policy, pass it here ... */
        )
        {
            return new ReactiveFooPolicy<TResult>(
                policyBuilder
                /* ... and pass it on to the constructor. */
            );
        }
    }
}
