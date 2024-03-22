namespace FinalProjectYear3;

public class Magasine
{
    Stack<Bullet> _magasine;
    int _maxCapacity = 10;
    int _currentCapacity;
    public Magasine()
    {
        _magasine = new();
        _currentCapacity = 0;
        Console.SetCursorPosition(135, 0);
        Console.WriteLine($"Magasine: {_currentCapacity} / {_maxCapacity}");
    }
    public void LoadBullet(Bullet bullet)
    {
        if (_currentCapacity + bullet.Size > _maxCapacity)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("This bullet can't fit.");
            Task.Delay(2000).Wait();
        }
        else
        {
            _currentCapacity += bullet.Size;
            _magasine.Push(Bullet.CreateBullet(bullet));
            Console.SetCursorPosition(135, 0);
            Console.WriteLine($"Magasine: {_currentCapacity} / {_maxCapacity}");
        }
    }
    public int GetCapacity()
    {
        return _currentCapacity;
    }

    public Bullet LoadChamber()
    {
        Bullet _chamberedBullet = _magasine.Peek();
        _magasine.Pop();
        _currentCapacity -= _chamberedBullet.Size;
        return _chamberedBullet;
    }
    public Bullet RemoveChamberedBullet()
    {
        Bullet _chamberedBullet = new();
        return _chamberedBullet;
    }
}
