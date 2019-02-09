using System;
using System.Threading;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// A ReactiveFoo policy that can be applied to delegates.
    /// </summary>
    public class ReactiveFooPolicy : Policy, IReactiveFooPolicy
    {
        /* This is the non-generic ReactiveFooPolicy for synchronous executions.
         * With this policy, users can execute void-returning Actions, using .Execute(...),
         * or TResult-returning Func<>s, using the generic base-class _method_ .Execute<TResult>(...).
         * So, although the policy is non-generic, the Implementation<TResult>(...) method is generic in TResult. 
         */

        internal ReactiveFooPolicy(
            PolicyBuilder policyBuilder
            /* other configuration parameters */)
            : base(policyBuilder)
        {
            /* store any configuration parameters for the implementation to use. */
        }

        /// <inheritdoc/>
        protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
        {
            /* This method is intentionally a pass-through.
             Delegating to ReactiveFooEngine.Implementation<TResult>(...) allows the code to use that single synchronous implementation
             for both ReactiveFooPolicy and ReactiveFooPolicy<TResult>
             */
            return ReactiveFooEngine.Implementation(
                action, 
                context, 
                cancellationToken,
                ExceptionPredicates,
                ResultPredicates<TResult>.None // (because the non-generic policy doesn't handle results)
                /* The implementation should receive at least the above parameters,
                 * but more parameters can also be passed: eg anything the policy was configured with. */
                );
        }
    }
}