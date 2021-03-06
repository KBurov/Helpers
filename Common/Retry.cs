﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers.Common
{
    /// <summary>
    /// Implements simple retry logic for an actions.
    /// </summary>
    public static class Retry
    {
        /// <summary>
        /// Repeat action <paramref name="numberOfRetries" /> times with <paramref name="timeoutInMilliseconds" /> delay.
        /// </summary>
        /// <param name="action">repeatable action</param>
        /// <param name="numberOfRetries">number of times to repeat</param>
        /// <param name="timeoutInMilliseconds">delay between repeating action</param>
        public static void Times(Action action, uint numberOfRetries, uint? timeoutInMilliseconds = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action), $"{nameof(action)} cannot be null");

            if (numberOfRetries > 0u) {
                var repeat = true;

                while (repeat)
                    try {
                        action();

                        repeat = false;
                    }
                    catch {
                        if (--numberOfRetries == 0u)
                            throw;

                        if (timeoutInMilliseconds.HasValue)
                            Thread.Sleep((int) timeoutInMilliseconds.Value);
                    }
            }
        }

        /// <summary>
        /// Repeat action <paramref name="numberOfRetries" /> times with <paramref name="timeoutInMilliseconds" /> delay (async version).
        /// </summary>
        /// <param name="action">repeatable action</param>
        /// <param name="numberOfRetries">number of times to repeat</param>
        /// <param name="timeoutInMilliseconds">delay between repeating action</param>
        public static async void TimesAsync(Func<Task> action, uint numberOfRetries, uint? timeoutInMilliseconds = null)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action), $"{nameof(action)} cannot be null");

            if (numberOfRetries > 0u) {
                var repeat = true;

                while (repeat)
                    try {
                        await action();

                        repeat = false;
                    }
                    catch {
                        if (--numberOfRetries == 0u)
                            throw;

                        if (timeoutInMilliseconds.HasValue)
                            await Task.Delay((int) timeoutInMilliseconds.Value);
                    }
            }
        }

        /// <summary>
        /// Repeat func <paramref name="numberOfRetries" /> times with <paramref name="timeoutInMilliseconds" /> delay.
        /// </summary>
        /// <typeparam name="T">type of func result</typeparam>
        /// <param name="func">repeatable func</param>
        /// <param name="numberOfRetries">number of times to repeat</param>
        /// <param name="timeoutInMilliseconds">delay between repeating action</param>
        /// <returns>func result</returns>
        public static T Times<T>(Func<T> func, uint numberOfRetries, uint? timeoutInMilliseconds = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func), $"{nameof(func)} cannot be null");
            if (numberOfRetries == 0)
                throw new ArgumentException($"{nameof(numberOfRetries)} should be greater than 0");

            while (true)
                try {
                    return func();
                }
                catch {
                    if (--numberOfRetries == 0u)
                        throw;

                    if (timeoutInMilliseconds.HasValue)
                        Thread.Sleep((int) timeoutInMilliseconds.Value);
                }
        }

        /// <summary>
        /// Repeat func <paramref name="numberOfRetries" /> times with <paramref name="timeoutInMilliseconds" /> delay (async version).
        /// </summary>
        /// <typeparam name="T">type of func result</typeparam>
        /// <param name="func">repeatable func</param>
        /// <param name="numberOfRetries">number of times to repeat</param>
        /// <param name="timeoutInMilliseconds">delay between repeating action</param>
        /// <returns>func result</returns>
        public static async Task<T> TimesAsync<T>(Func<Task<T>> func, uint numberOfRetries, uint? timeoutInMilliseconds = null)
        {
            if (func == null)
                throw new ArgumentNullException(nameof(func), $"{nameof(func)} cannot be null");
            if (numberOfRetries == 0)
                throw new ArgumentException($"{nameof(numberOfRetries)} should be greater than 0");

            while (true)
                try {
                    return await func();
                }
                catch {
                    if (--numberOfRetries == 0u)
                        throw;

                    if (timeoutInMilliseconds.HasValue)
                        await Task.Delay((int) timeoutInMilliseconds.Value);
                }
        }
    }
}