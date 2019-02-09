using System;
using System.Threading;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// A ProactiveFoo policy that can be applied to delegates returning a value of type <typeparamref name="TResult" />
    /// </summary>
    /// <typeparam name="TResult">The type of return values this policy will handle.</typeparam>
    public class ProactiveFooPolicy<TResult> : Policy<TResult>, IProactiveFooPolicy<TResult>
    {
        /* This is the generic ProactiveFooPolicy for synchronous executions.
         * With this policy, users can execute TResult-returning Func<>s.
         */

        /* It is a syntax convention for proactive Polly policies to use static creation methods rather than use constructors directly. It makes the syntax more similar to reactive policy syntax. */

        /// <summary>
        /// Constructs a new instance of <see cref="ProactiveFooPolicy{TResult}"/>.
        /// </summary>
        /// <returns><see cref="ProactiveFooPolicy{TResult}"/></returns>
        public static ProactiveFooPolicy<TResult> Create(
            /* If configuration should be passed when creating the policy, pass it here ... */
            )
        {
            return new ProactiveFooPolicy<TResult>(/* ... and pass it on to the constructor ... */);
        }

        internal ProactiveFooPolicy(/* configuration parameters */)
        {
            /* ... and the policy constructor can store configuration, for the implementation to use. */
        }

        /// <inheritdoc/>
        protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
        {
            /* This method is intentionally a pass-through.
             Delegating to ProactiveFooEngine.Implementation<TResult>(...) allows the code to use that single synchronous implementation
             for both ProactiveFooPolicy.Execute<TResult>() and ProactiveFooPolicy<TResult>.Execute(...)
             */
            return ProactiveFooEngine.Implementation(
                action, 
                context, 
                cancellationToken
                /* The implementation should receive at least the above parameters,
                 * but more parameters can also be passed: eg anything the policy was configured with. */
                );
        }
    }
}