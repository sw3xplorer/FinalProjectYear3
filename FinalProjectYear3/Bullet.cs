namespace FinalProjectYear3;

public class Bullet
{
    protected string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        private set
        {
            // _name = value;
        }
    }

    protected int _damage;
    protected int _size;
    public int Size
    {
        get
        {
            return _size;
        }
        private set
        {

        }
    }
    protected int _accuracy;
    public int Accuracy
    {
        get
        {
            return _accuracy;
        }
        private set
        {

        }
    }
    public virtual void DisplayDamage(Gun gun)
    {
        if (gun.GetHitTarget())
        {
            // Placeholder positions
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Target hit!");
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(_damage);
        }
        else
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Missed!");
        }
    }

    public static Bullet CreateBullet(Bullet bulletType)
    {
        return (Bullet)bulletType.MemberwiseClone();
    }
}
