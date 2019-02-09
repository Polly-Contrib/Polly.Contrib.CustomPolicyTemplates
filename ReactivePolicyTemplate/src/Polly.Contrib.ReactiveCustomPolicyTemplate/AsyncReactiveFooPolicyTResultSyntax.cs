namespace Polly.Contrib.ReactiveCustomPolicyTemplate
{
    /// <summary>
    /// Contains configuration syntax for the <see cref="AsyncReactiveFooPolicy{TResult}"/>
    /// </summary>
    public static class AsyncReactiveFooPolicyTResultSyntax
    {
        /// <summary>
        /// Constructs a new instance of <see cref="AsyncReactiveFooPolicy{TResult}"/>, configured to handle the exceptions and results specified in the <paramref name="policyBuilder"/>.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="policyBuilder">The policy builder.</param>
        /// <returns><see cref="AsyncReactiveFooPolicy{TResult}"/></returns>
        public static AsyncReactiveFooPolicy<TResult> AsyncReactiveFoo<TResult>(this PolicyBuilder<TResult> policyBuilder
            /* If configuration should be passed when creating the policy, pass it here ... */
        )
        {
            return new AsyncReactiveFooPolicy<TResult>(
                policyBuilder
                /* ... and pass it on to the constructor. */
            );
        }
    }
}
