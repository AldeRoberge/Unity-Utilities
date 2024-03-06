using System;
using System.Threading.Tasks;
using UnityEngine;

namespace AldeRoberge.UnityUtilities.Dispatcher
{
    public partial class Dispatcher
    {
        public void RunAsync(Func<Task> action) => InvokeAsync(action);
        
        /// <summary>
        /// Creates a new thread and safely runs an async function on it.
        /// Will return immediately.
        /// Will print on error.
        /// </summary>
        /// Dispatcher.Instance.InvokeAsync(async () => {});
        public void InvokeAsync(Func<Task> action)
        {
            // Wraps the action in a task, catches any exceptions and logs them
            Task.Run(async () =>
            {
                try
                {
                    await action();
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }).ContinueWith(t =>
            {
                if (t.Exception != null)
                {
                    Debug.LogException(t.Exception);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}