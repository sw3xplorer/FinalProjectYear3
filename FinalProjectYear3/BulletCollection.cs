namespace FinalProjectYear3;
public class BulletCollection
{
    // List containing all the bullets in this program.
    public static List<Bullet> Bullets = new();
    // Constructor adding the bullets to the list upon launching the app.
    public BulletCollection()
    {
        Bullets.Add(new _9mm { });
        Bullets.Add(new _45ACP { });
        Bullets.Add(new _50Cal { });
    }
}
