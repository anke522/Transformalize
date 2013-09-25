#region License

// /*
// Transformalize - Replicate, Transform, and Denormalize Your Data...
// Copyright (C) 2013 Dale Newman
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using Transformalize.Libs.NLog.Internal;

namespace Transformalize.Libs.NLog.Common
{
    /// <summary>
    ///     Helpers for asynchronous operations.
    /// </summary>
    public static class AsyncHelpers
    {
        /// <summary>
        ///     Iterates over all items in the given collection and runs the specified action
        ///     in sequence (each action executes only after the preceding one has completed without an error).
        /// </summary>
        /// <typeparam name="T">Type of each item.</typeparam>
        /// <param name="items">The items to iterate.</param>
        /// <param name="asyncContinuation">
        ///     The asynchronous continuation to invoke once all items
        ///     have been iterated.
        /// </param>
        /// <param name="action">The action to invoke for each item.</param>
        public static void ForEachItemSequentially<T>(IEnumerable<T> items, AsyncContinuation asyncContinuation, AsynchronousAction<T> action)
        {
            action = ExceptionGuard(action);
            AsyncContinuation invokeNext = null;
            var enumerator = items.GetEnumerator();

            invokeNext = ex =>
                             {
                                 if (ex != null)
                                 {
                                     asyncContinuation(ex);
                                     return;
                                 }

                                 if (!enumerator.MoveNext())
                                 {
                                     asyncContinuation(null);
                                     return;
                                 }

                                 action(enumerator.Current, PreventMultipleCalls(invokeNext));
                             };

            invokeNext(null);
        }

        /// <summary>
        ///     Repeats the specified asynchronous action multiple times and invokes asynchronous continuation at the end.
        /// </summary>
        /// <param name="repeatCount">The repeat count.</param>
        /// <param name="asyncContinuation">The asynchronous continuation to invoke at the end.</param>
        /// <param name="action">The action to invoke.</param>
        public static void Repeat(int repeatCount, AsyncContinuation asyncContinuation, AsynchronousAction action)
        {
            action = ExceptionGuard(action);
            AsyncContinuation invokeNext = null;
            var remaining = repeatCount;

            invokeNext = ex =>
                             {
                                 if (ex != null)
                                 {
                                     asyncContinuation(ex);
                                     return;
                                 }

                                 if (remaining-- <= 0)
                                 {
                                     asyncContinuation(null);
                                     return;
                                 }

                                 action(PreventMultipleCalls(invokeNext));
                             };

            invokeNext(null);
        }

        /// <summary>
        ///     Modifies the continuation by pre-pending given action to execute just before it.
        /// </summary>
        /// <param name="asyncContinuation">The async continuation.</param>
        /// <param name="action">The action to pre-pend.</param>
        /// <returns>Continuation which will execute the given action before forwarding to the actual continuation.</returns>
        public static AsyncContinuation PrecededBy(AsyncContinuation asyncContinuation, AsynchronousAction action)
        {
            action = ExceptionGuard(action);

            AsyncContinuation continuation =
                ex =>
                    {
                        if (ex != null)
                        {
                            // if got exception from from original invocation, don't execute action
                            asyncContinuation(ex);
                            return;
                        }

                        // call the action and continue
                        action(PreventMultipleCalls(asyncContinuation));
                    };

            return continuation;
        }

        /// <summary>
        ///     Attaches a timeout to a continuation which will invoke the continuation when the specified
        ///     timeout has elapsed.
        /// </summary>
        /// <param name="asyncContinuation">The asynchronous continuation.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>Wrapped continuation.</returns>
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Continuation will be disposed of elsewhere.")]
        public static AsyncContinuation WithTimeout(AsyncContinuation asyncContinuation, TimeSpan timeout)
        {
            return new TimeoutContinuation(asyncContinuation, timeout).Function;
        }

        /// <summary>
        ///     Iterates over all items in the given collection and runs the specified action
        ///     in parallel (each action executes on a thread from thread pool).
        /// </summary>
        /// <typeparam name="T">Type of each item.</typeparam>
        /// <param name="values">The items to iterate.</param>
        /// <param name="asyncContinuation">
        ///     The asynchronous continuation to invoke once all items
        ///     have been iterated.
        /// </param>
        /// <param name="action">The action to invoke for each item.</param>
        public static void ForEachItemInParallel<T>(IEnumerable<T> values, AsyncContinuation asyncContinuation, AsynchronousAction<T> action)
        {
            action = ExceptionGuard(action);

            var items = new List<T>(values);
            var remaining = items.Count;
            var exceptions = new List<Exception>();

            InternalLogger.Trace("ForEachItemInParallel() {0} items", items.Count);

            if (remaining == 0)
            {
                asyncContinuation(null);
                return;
            }

            AsyncContinuation continuation =
                ex =>
                    {
                        InternalLogger.Trace("Continuation invoked: {0}", ex);
                        int r;

                        if (ex != null)
                        {
                            lock (exceptions)
                            {
                                exceptions.Add(ex);
                            }
                        }

                        r = Interlocked.Decrement(ref remaining);
                        InternalLogger.Trace("Parallel task completed. {0} items remaining", r);
                        if (r == 0)
                        {
                            asyncContinuation(GetCombinedException(exceptions));
                        }
                    };

            foreach (var item in items)
            {
                var itemCopy = item;

                ThreadPool.QueueUserWorkItem(s => action(itemCopy, PreventMultipleCalls(continuation)));
            }
        }

        /// <summary>
        ///     Runs the specified asynchronous action synchronously (blocks until the continuation has
        ///     been invoked).
        /// </summary>
        /// <param name="action">The action.</param>
        /// <remarks>
        ///     Using this method is not recommended because it will block the calling thread.
        /// </remarks>
        public static void RunSynchronously(AsynchronousAction action)
        {
            var ev = new ManualResetEvent(false);
            Exception lastException = null;

            action(PreventMultipleCalls(ex =>
                                            {
                                                lastException = ex;
                                                ev.Set();
                                            }));
            ev.WaitOne();
            if (lastException != null)
            {
                throw new NLogRuntimeException("Asynchronous exception has occurred.", lastException);
            }
        }

        /// <summary>
        ///     Wraps the continuation with a guard which will only make sure that the continuation function
        ///     is invoked only once.
        /// </summary>
        /// <param name="asyncContinuation">The asynchronous continuation.</param>
        /// <returns>Wrapped asynchronous continuation.</returns>
        public static AsyncContinuation PreventMultipleCalls(AsyncContinuation asyncContinuation)
        {
#if !NETCF2_0
            // target is not available on .NET CF 2.0
            if (asyncContinuation.Target is SingleCallContinuation)
            {
                return asyncContinuation;
            }
#endif

            return new SingleCallContinuation(asyncContinuation).Function;
        }

        /// <summary>
        ///     Gets the combined exception from all exceptions in the list.
        /// </summary>
        /// <param name="exceptions">The exceptions.</param>
        /// <returns>Combined exception or null if no exception was thrown.</returns>
        public static Exception GetCombinedException(IList<Exception> exceptions)
        {
            if (exceptions.Count == 0)
            {
                return null;
            }

            if (exceptions.Count == 1)
            {
                return exceptions[0];
            }

            var sb = new StringBuilder();
            var separator = string.Empty;
            var newline = EnvironmentHelper.NewLine;
            foreach (var ex in exceptions)
            {
                sb.Append(separator);
                sb.Append(ex);
                sb.Append(newline);
                separator = newline;
            }

            return new NLogRuntimeException("Got multiple exceptions:\r\n" + sb);
        }

        private static AsynchronousAction ExceptionGuard(AsynchronousAction action)
        {
            return cont =>
                       {
                           try
                           {
                               action(cont);
                           }
                           catch (Exception exception)
                           {
                               if (exception.MustBeRethrown())
                               {
                                   throw;
                               }

                               cont(exception);
                           }
                       };
        }

        private static AsynchronousAction<T> ExceptionGuard<T>(AsynchronousAction<T> action)
        {
            return (T argument, AsyncContinuation cont) =>
                       {
                           try
                           {
                               action(argument, cont);
                           }
                           catch (Exception exception)
                           {
                               if (exception.MustBeRethrown())
                               {
                                   throw;
                               }

                               cont(exception);
                           }
                       };
        }
    }
}