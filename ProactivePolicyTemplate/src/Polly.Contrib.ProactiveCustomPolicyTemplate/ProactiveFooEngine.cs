using System;
using System.Threading;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate /* Suggested pattern: Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    internal static class ProactiveFooEngine
    {
        internal static TResult Implementation<TResult>(
            Func<Context, CancellationToken, TResult> action, // The delegate the user passed to execute 
            Context context, // The context the user passed to execute (never null; Polly provides one if user does not)
            CancellationToken cancellationToken // The cancellation token the user passed to execute; for co-operative cancellation to be effective, policy implementations should honour it at suitable points in the execution.
            /* The implementation should receive at least the above parameters,
             * but more parameters can also be passed: eg anything the policy was configured with. */
            )
        {
            /*
             * Code your policy implementation (for synchronous executions) in this method.
             *
             * This:
             *
             *    TResult result = action(context, cancellationToken);
             *
             * is the code which executes the delegate which the caller passed to the policy.Execute(...) call.
             *
             *
             * Your custom policy can do anything around that call:
             *
             * - do something extra before execution (as Polly's CachePolicy does - it checks the cache)
             * - do something extra after execution  (as Polly's CachePolicy does - it stores in the cache a result returned from the execution)
             * - inject something into the execution (as Polly's TimeoutPolicy does - it injects an extra CancellationToken)
             * - delay execution                     (as Simmy's InjectLatencyPolicy does; as Polly's BulkheadEngine does if there is not capacity)
             * - execute it multiple times           (as Polly's RetryPolicy does)
             * - choose not to execute it at all     (as Polly's CircuitBreakerEngine and BulkheadEngine sometimes do)
             *
             * A ProActive policy is not intended to handle exceptions.  For policies handling exceptions, see ReactiveFooPolicy.
             *
             */


            TResult result = action(context, cancellationToken);


            return result;
        }
    }
}
