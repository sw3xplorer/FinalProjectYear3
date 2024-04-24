namespace FinalProjectYear3;
public class BulletCollection
{
    // List containing all the bullets in this program.
    public static List<Bullet> Bullets = new();
    // Constructor adding the bullets to the list upon launching the app.
    public BulletCollection()
    {
        Bullets.Add(new Bullet9mm { });
        Bullets.Add(new Bullet45ACP { });
        Bullets.Add(new Bullet50Cal { });
    }
}
