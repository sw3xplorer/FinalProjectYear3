namespace FinalProjectYear3;

public class Magasine
{
    Stack<Bullet> _magasine;
    int _maxCapacity = 10;
    int _currentCapacity;
    public Magasine(Bullet bullet)
    {
        _magasine = new();
        _currentCapacity = 0;
    }
    public virtual void LoadBullet(Magasine magasine)
    {

    }
}
