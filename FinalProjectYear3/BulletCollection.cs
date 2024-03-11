namespace FinalProjectYear3;
public class BulletCollection
{
    List<Bullet> _bullets = new();
    public BulletCollection()
    {
        _bullets.Add(new _9mm  {});
        _bullets.Add(new _45ACP {});
        _bullets.Add(new _50Cal {});
    }
    public void GetBullets()
    {
        int i = 0;
        foreach(Bullet bullet in _bullets)
        {
            Console.SetCursorPosition(0, 15 + i);
            Console.WriteLine(bullet.Name);
        }
    }
}
