namespace FinalProjectYear3;

public class Bullet
{
    string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    protected int _damage;
    protected int _size;
    protected int _accuracy;
   
}
