

namespace GeniyIdiotConsoleApp;

public class ConsoleTimerService
{
    private readonly int _totalTime;
    private int _timeRemaining;
    private readonly Action _onTimeExpired;
    private readonly Action<int> _onTimerTick;
    private CancellationTokenSource _cancellationTokenSource;
    private bool _isRunning = false;

    public ConsoleTimerService(int totalTime, Action onTimeExpired, Action<int> onTimerTick = null)
    {
        _totalTime = totalTime;
        _timeRemaining = totalTime;
        _onTimeExpired = onTimeExpired;
        _onTimerTick = onTimerTick;
    }

    public void Start()
    {
        if (_isRunning) return;

        _timeRemaining = _totalTime;
        _isRunning = true;
        _cancellationTokenSource = new CancellationTokenSource();

        Task.Run(async () =>
        {
            while (_isRunning && _timeRemaining > 0)
            {
                await Task.Delay(1000, _cancellationTokenSource.Token);

                if (!_isRunning) break;

                _timeRemaining--;
                _onTimerTick?.Invoke(_timeRemaining);

                if (_timeRemaining <= 0)
                {
                    _isRunning = false;
                    _onTimeExpired?.Invoke();
                }
            }
        }, _cancellationTokenSource.Token);
    }

    public void Stop()
    {
        _isRunning = false;
        _cancellationTokenSource?.Cancel();
    }

    public void Restart()
    {
        Stop();
        Start();
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
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
    }
}

