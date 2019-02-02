namespace Polly.Contrib.ReactiveCustomPolicyTemplate /* Use a namespace broadly describing the topic, eg Polly.Contrib.Logging, Polly.Contrib.RateLimiting */
{
    /// <summary>
    /// Defines properties common to synchronous and asynchronous ReactiveFoo policies.
    /// </summary>
    public interface IReactiveFooPolicy : IsPolicy
    {
        /* Define properties (if any) or methods (if any) you may want to expose on ReactiveFooPolicy.

         - Perhaps the custom policy takes configuration properties which you want to expose.
         - Perhaps the custom policy exposes methods for manual control.

        ... but it is equally common to have none.
         */
    }

    /// <summary>
    /// Defines properties common to generic, synchronous and asynchronous ReactiveFoo policies.
    /// </summary>
    public interface IReactiveFooPolicy<TResult> : IReactiveFooPolicy
    {
        /* Define properties (if any) or methods (if any) you may want to expose on ReactiveFooPolicy<TResult>.

           Typically, IProactiveFooPolicy<TResult> : IProactiveFooPolicy, so you would only expose here any 
           extra properties/methods typed in <TResult> for TResult policies.
         */
    }
}
