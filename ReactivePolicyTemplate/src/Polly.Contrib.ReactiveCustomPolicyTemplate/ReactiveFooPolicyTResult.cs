using System;
using System.Threading;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// A ReactiveFoo policy that can be applied to delegates returning a value of type <typeparamref name="TResult" />
    /// </summary>
    /// <typeparam name="TResult">The type of return values this policy will handle.</typeparam>
    public class ReactiveFooPolicy<TResult> : Policy<TResult>, IReactiveFooPolicy<TResult>
    {
        /* This is the generic ReactiveFooPolicy for synchronous executions.
         * With this policy, users can execute TResult-returning Func<>s.
         */

        internal ReactiveFooPolicy(
            ExceptionPredicates exceptionPredicates,
            ResultPredicates<TResult> resultPredicates
            /* other configuration parameters */)
            : base(exceptionPredicates, resultPredicates)
        {
            /* store any configuration parameters for the implementation to use. */
        }

        /// <inheritdoc/>
        protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
        {
            /* This method is intentionally a pass-through.
             Delegating to ReactiveFooEngine.Implementation<TResult>(...) allows the code to use that single synchronous implementation
             for both ReactiveFooPolicy.Execute<TResult>() and ReactiveFooPolicy<TResult>.Execute(...)
             */
            return ReactiveFooEngine.Implementation(
                action, 
                context, 
                cancellationToken,
                ExceptionPredicates,
                ResultPredicates
                /* The implementation should receive at least the above parameters,
                 * but more parameters can also be passed: eg anything the policy was configured with. */
                );
        }
    }
}