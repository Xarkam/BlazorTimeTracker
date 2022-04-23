using System.Timers;

namespace BlazorTimeTracker.Pages
{
    public partial class Index
    {
        private const string DEFAUL_TIME = "00:00:00";
        private string elapsedTime = DEFAUL_TIME;
        System.Timers.Timer timer = new(1);
        DateTime starTime = DateTime.Now;
        private bool isRunning = false;

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DateTime currentTime = e.SignalTime;
            elapsedTime = $"{currentTime.Subtract(starTime)}";
            StateHasChanged();
        }
        
        void StartTimer()
        {
            starTime = DateTime.Now;
            timer = new System.Timers.Timer(1);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            isRunning = true;
        }

        void StopTimer()
        {
            isRunning = false;
            Console.WriteLine($"Elapsed time: {elapsedTime}");
            timer.Enabled = false;
            elapsedTime = DEFAUL_TIME;
        }

        void OnTimerChanged()
        {
            if (!isRunning)
                StartTimer();
            else
                StopTimer();
        }
    }
}