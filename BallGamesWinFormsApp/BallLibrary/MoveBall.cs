using Timer = System.Windows.Forms.Timer;
using BallLibrary;


public class MoveBall : RandomSizeAndPointBall
{
    private Timer _timer;
    public int radius;
    public bool IsStopped { get; protected set; } = false;
    public MoveBall(Form form) : base(form)
    {
        _timer = new Timer();
        var random = new Random();
        vx = random.Next(-10, 10);
        vy = random.Next(-10, 10);
        _timer.Interval = 20;
        _timer.Tick += _timer_Tick;
    }

    private void _timer_Tick(object? sender, EventArgs e)
    {
        Move();
    }

    public void Start() { _timer.Start(); }
    
    public void Stop() { _timer.Stop(); IsStopped = true; }
}
