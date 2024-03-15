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
   
}
