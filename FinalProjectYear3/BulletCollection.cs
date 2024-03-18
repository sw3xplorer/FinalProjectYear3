namespace FinalProjectYear3;
public class BulletCollection : IContainsBullets
{
    public static List<Bullet> Bullets = new();
    public BulletCollection()
    {
        Bullets.Add(new _9mm { });
        Bullets.Add(new _45ACP { });
        Bullets.Add(new _50Cal { });
    }
    // public void GetBullets()
    // {
    //     int i = 0;
    //     foreach(Bullet bullet in _bullets)
    //     {
    //         Console.SetCursorPosition(0, 15 + i);
    //         Console.WriteLine(bullet.Name);
    //     }
    // }
}
