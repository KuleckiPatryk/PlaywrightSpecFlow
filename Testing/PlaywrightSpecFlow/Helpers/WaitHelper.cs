namespace PlaywrightSpecFlow.Helpers
{
    public class WaitHelper
    {
        public static bool Wait(Func<bool> condition, TimeSpan timeout, TimeSpan sleepInterval)
        {
            var taskConditionCheck = Task.Run(async () =>
            {
                while (!condition())
                {
                    await Task.Delay(sleepInterval).ConfigureAwait(false);
                }
            });

            var taskTimeoutCheck = Task.Run(async () => { await Task.Delay(timeout).ConfigureAwait(false); });

            while (true)
            {
                if (taskConditionCheck.IsCompleted)
                {
                    return true;
                }

                if (taskTimeoutCheck.IsCompleted)
                {
                    return false;
                }

                Thread.Sleep(sleepInterval);
            }
        }
    }
}
