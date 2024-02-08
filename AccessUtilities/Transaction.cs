using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polly;
namespace AccessUtilities
{
    public static class Transaction
    {
        public static async Task<T> ExecuteAsync<T>(this Task<T> task, int intent, int time)
        {
            return await Policy.Handle<Exception>().WaitAndRetryAsync(intent, i => TimeSpan.FromMilliseconds(time)).ExecuteAsync(async () =>
            {
                return await task;
            });
        }
    }
}
