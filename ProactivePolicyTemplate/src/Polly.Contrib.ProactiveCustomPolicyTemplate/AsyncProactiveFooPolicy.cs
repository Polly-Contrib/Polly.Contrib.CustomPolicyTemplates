using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// A ProactiveFoo policy that can be applied to asynchronous delegates.
    /// </summary>
    public class AsyncProactiveFooPolicy : AsyncPolicy, IProactiveFooPolicy
    {
        /* This is the non-generic ProactiveFooPolicy for asynchronous executions.
         * With this policy, users can asynchronously execute Task-returning methods, using .ExecuteAsync(...),
         * or TResult-returning Func<Task<TResult>>s, using the generic base-class _method_ .ExecuteAsync<TResult>(...).
         * So, although the policy is non-generic, the Implementation<AsyncTResult>(...) method is generic in TResult. 
         */

        /* It is a syntax convention for proactive Polly policies to use static creation methods rather than use constructors directly. It makes the syntax more similar to reactive policy syntax. */

        /// <summary>
        /// Constructs a new instance of <see cref="AsyncProactiveFooPolicy"/>.
        /// </summary>
        /// <returns><see cref="AsyncProactiveFooPolicy"/></returns>
        public static AsyncProactiveFooPolicy Create(
            /* If configuration should be passed when creating the policy, pass it here ... */
            )
        {
            return new AsyncProactiveFooPolicy(/* ... and pass it on to the constructor ... */);
        }

        internal AsyncProactiveFooPolicy(/* configuration parameters */)
        {
            /* ... and the policy constructor can store configuration, for the implementation to use. */
        }

        /// <inheritdoc/>
        protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken,Task<TResult>> action, Context context, CancellationToken cancellationToken,
            bool continueOnCapturedContext)
        {
            /* This method is intentionally a pass-through.
             Delegating to AsyncProactiveFooEngine.ImplementationAsync<TResult>(...) allows the code to use that single asynchronous implementation
             for both AsyncProactiveFooPolicy and AsyncProactiveFooPolicy<TResult>
             */
            return AsyncProactiveFooEngine.ImplementationAsync(
                action, 
                context, 
                cancellationToken, 
                continueOnCapturedContext
                /* The implementation should receive at least the above parameters,
                 * but more parameters can also be passed: eg anything the policy was configured with. */
                );
        }
    }
}