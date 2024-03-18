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
    }
    public void LoadBullet(Bullet bullet)
    {
        if (_currentCapacity + bullet.Size > _maxCapacity)
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine("This bullet can't fit.");
        }
        else
        {
            _currentCapacity += bullet.Size;
            _magasine.Push(bullet);
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
        return _chamberedBullet;
    }
    public Bullet RemoveChamberedBullet()
    {
        Bullet _chamberedBullet = new();
        return _chamberedBullet;
    }
}
