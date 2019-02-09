using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// A ReactiveFoo policy that can be applied to asynchronous delegates.
    /// </summary>
    public class AsyncReactiveFooPolicy : AsyncPolicy, IReactiveFooPolicy
    {
        /* This is the non-generic ReactiveFooPolicy for asynchronous executions.
         * With this policy, users can asynchronously execute Task-returning methods, using .ExecuteAsync(...),
         * or TResult-returning Func<Task<TResult>>s, using the generic base-class _method_ .ExecuteAsync<TResult>(...).
         * So, although the policy is non-generic, the Implementation<AsyncTResult>(...) method is generic in TResult. 
         */

        internal AsyncReactiveFooPolicy(
            PolicyBuilder policyBuilder
            /* other configuration parameters */)
            : base(policyBuilder)
        {
            /* store any configuration parameters for the implementation to use. */
        }

        /// <inheritdoc/>
        protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken,
            bool continueOnCapturedContext)
        {
            /* This method is intentionally a pass-through.
             Delegating to AsyncReactiveFooEngine.ImplementationAsync<TResult>(...) allows the code to use that single asynchronous implementation
             for both AsyncReactiveFooPolicy and AsyncReactiveFooPolicy<TResult>
             */
            return AsyncReactiveFooEngine.ImplementationAsync(
                action,
                context,
                cancellationToken,
                continueOnCapturedContext,
                ExceptionPredicates,
                ResultPredicates<TResult>.None // (because this is the non-generic policy)
                /* The implementation should receive at least the above parameters,
                 * but more parameters can also be passed: eg anything the policy was configured with. */
                );
        }
    }
}