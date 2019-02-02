using System;
using System.Threading;
using Polly.Utilities;

namespace Polly.Contrib.ReactiveCustomPolicyTemplate /* Suggested pattern: Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    internal static class ReactiveFooEngine
    {
        internal static TResult Implementation<TResult>(
            Func<Context, CancellationToken, TResult> action, // The delegate the user passed to execute 
            Context context, // The context the user passed to execute (never null; Polly provides one if user does not)
            CancellationToken cancellationToken, // The cancellation token the user passed to execute; for co-operative cancellation to be effective, policy implementations should honour it at suitable points in the execution.
            ExceptionPredicates shouldHandleExceptionPredicates, // The exceptions the policy has been configured to handle.
            ResultPredicates<TResult> shouldHandleResultPredicates // The results the policy has been configured to handle.
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
             * The template below demonstrates how to use the exception predicates and result predicates - the information the user configured with Policy.Handle<Exception>(...) and .HandleResult(...)
             *
             * A Reactive policy handles exceptions and results.  For policies not handling exceptions, see ProactiveFooPolicy.
             *
             */


            try
            {
                TResult result = action(context, cancellationToken);


                if (!shouldHandleResultPredicates.AnyMatch(result))
                {
                    return result; // Not an outcome your policy handles - just return it.
                }

                // ==============================================================
                /* Code here the way your policy handles the return values it is configured to handle (if it is intended to handle results as well as exceptions). */
                // ==============================================================



                // The policy must eventually return some result.
                // The following line here just returns the result from the underlying call (perhaps after the policy has done some processing based on it)
                // but a policy could equally manipulate the result, substitute the result with another, etc.
                return result;

            }
            catch (Exception ex)
            {
                Exception handledException = shouldHandleExceptionPredicates.FirstMatchOrDefault(ex);
                if (handledException == null)
                {
                    throw; // Not an exception your policy handles - propagate the exception.
                }

                // ==============================================================
                /* Code here the way your policy handles the exceptions it is configured to handle. */
                // ==============================================================



                // The policy must eventually return some result or throw.
                // The lines here just rethrow the exception (perhaps after the policy has done some processing based on it)
                // but a policy could equally manipulate the exception, throw a different one, return a substitute result, etc.

                // The following line here rethrows the handled exception with original stacktrace;
                // the helper method makes the stack trace correct if the handled exception was an inner exception caught with Polly's HandleInner<>() syntax.
                handledException.RethrowWithOriginalStackTraceIfDiffersFrom(ex);
                throw; // Extra throw statement never hit; just to make the compiler not report: 'Not all code paths return a value'
            }
        }
    }
}
