namespace FinalProjectYear3;

public class Bullet
{
    // Declare variables which will be needed for bullets.
    protected string _name;
    // Variables that need to be public are turned into properties.
    public string Name
    {
        get
        {
            return _name;
        }
        private set
        {

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

    // A method which creates a clone (copy) of an instance of a bullet.
    public static Bullet CreateBullet(Bullet bulletType)
    {
        return (Bullet)bulletType.MemberwiseClone();
    }
    // Returns the damage of the bullet.
    public virtual int GetDamage()
    {
        return _damage;
    }
}
