using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Contrib.ProactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    internal static class AsyncProactiveFooEngine
    {
        internal static async Task<TResult> ImplementationAsync<TResult>(
            Func<Context, CancellationToken, Task<TResult>> action, // The delegate the user passed to execute 
            Context context, // The context the user passed to execute (never null; Polly provides one if user does not) 
            CancellationToken cancellationToken, // The cancellation token the user passed to execute; for co-operative cancellation to be effective, policy implementations should honour it at suitable points in the execution.
            bool continueOnCapturedContext // Whether to continue executions on captured context (ConfigureAwait(...)); defaults to false, if not user-specfied.
            /* The  */
            )
        {
            /*
             * Code your policy implementation (for asynchronous executions) in this method.
             *
             * This:
             *
             *    TResult result = await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
             *
             * is the code which executes the delegate which the caller passed to the policy.ExecuteAsync(...) call.
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
             * A ProActive policy is not intended to handle exceptions.  For policies handling exceptions, see AsyncReactiveFooPolicy.
             *
             * In asynchronous implementations, every awaited call should be decorated .ConfigureAwait(continueOnCapturedContext);
             */



            TResult result = await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);



            return result;
        }
    }
}
