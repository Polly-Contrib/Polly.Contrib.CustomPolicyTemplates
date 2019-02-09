using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// A ReactiveFoo policy that can be applied to asynchronous delegates returning a value of type <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of return values this policy will handle.</typeparam>
    public class AsyncReactiveFooPolicy<TResult> : AsyncPolicy<TResult>, IReactiveFooPolicy<TResult>
    {
        /* This is the generic ReactiveFooPolicy for asynchronous executions.
         * With this policy, users can execute TResult-returning Func<Task<TResult>>s.
         */

        internal AsyncReactiveFooPolicy(
            PolicyBuilder<TResult> policyBuilder
            /* other configuration parameters */)
            : base(policyBuilder)
        {
            /* store any configuration parameters for the implementation to use. */
        }

        /// <inheritdoc/>
        protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken,
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
                ResultPredicates
                /* The implementation should receive at least the above parameters,
                 * but more parameters can also be passed: eg anything the policy was configured with. */
                );
        }
    }
}