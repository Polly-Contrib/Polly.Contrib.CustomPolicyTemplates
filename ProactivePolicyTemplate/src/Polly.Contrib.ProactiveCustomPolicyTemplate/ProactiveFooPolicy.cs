using System;
using System.Threading;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// A ProactiveFoo policy that can be applied to delegates.
    /// </summary>
    public class ProactiveFooPolicy : Policy, IProactiveFooPolicy
    {
        /* This is the non-generic ProactiveFooPolicy for synchronous executions.
         * With this policy, users can execute void-returning Actions, using .Execute(...),
         * or TResult-returning Func<>s, using the generic base-class _method_ .Execute<TResult>(...).
         * So, although the policy is non-generic, the Implementation<TResult>(...) method is generic in TResult. 
         */

        /* It is a syntax convention for proactive Polly policies to use static creation methods rather than use constructors directly. It makes the syntax more similar to reactive policy syntax. */

        /// <summary>
        /// Constructs a new instance of <see cref="ProactiveFooPolicy"/>.
        /// </summary>
        /// <returns><see cref="ProactiveFooPolicy"/></returns>
        public static ProactiveFooPolicy Create(
            /* If configuration should be passed when creating the policy, pass it here ... */
            )
        {
            return new ProactiveFooPolicy(/* ... and pass it on to the constructor ... */);
        }

        internal ProactiveFooPolicy(/* configuration parameters */)
        {
            /* ... and the policy constructor can store configuration, for the implementation to use. */
        }

        /// <inheritdoc/>
        protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
        {
            /* This method is intentionally a pass-through.
             Delegating to ProactiveFooEngine.Implementation<TResult>(...) allows the code to use that single synchronous implementation
             for both ProactiveFooPolicy and ProactiveFooPolicy<TResult>
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