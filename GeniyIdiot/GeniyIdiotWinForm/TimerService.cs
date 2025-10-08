using System;
using System.Windows.Forms;

namespace GeniyIdiotWinForm
{
    public class TimerService
    {
        private System.Windows.Forms.Timer _timer;
        private int _timeRemaining;
        private int _totalTime;
        private Action _onTimeExpired;
        private Action<int> _onTimerTick;
        private bool _isRunning = false;

        public TimerService(int totalTime, Action onTimeExpired, Action<int> onTimerTick = null)
        {
            _totalTime = totalTime;
            _timeRemaining = totalTime;
            _onTimeExpired = onTimeExpired;
            _onTimerTick = onTimerTick;
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_isRunning) return;

            _timeRemaining--;

            _onTimerTick?.Invoke(_timeRemaining);

            if (_timeRemaining <= 0)
            {
                _isRunning = false;
                _timer.Stop();
                _onTimeExpired?.Invoke();
            }
        }

        public void Start()
        {
            _timeRemaining = _totalTime;
            _isRunning = true;
            _timer.Start();
            _onTimerTick?.Invoke(_timeRemaining);
        }

        public void Stop()
        {
            _isRunning = false;
            _timer.Stop();
        }

        public void Restart()
        {
            _timeRemaining = _totalTime;
            _isRunning = true;
            _timer.Start();
            _onTimerTick?.Invoke(_timeRemaining); 
        }

        public int GetRemainingTime()
        {
            return _timeRemaining;
        }

        public bool IsRunning()
        {
            return _isRunning;
        }

        public void Dispose()
        {
            _isRunning = false;
            _timer?.Stop();
            _timer?.Dispose();
        }
    }
}