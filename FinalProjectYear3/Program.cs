using FinalProjectYear3;
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
BulletCollection _bulletCollection = new();
Bullet _bullet = new();
_9mm _9Mm = new();
_45ACP _45ACP = new();
_50Cal _50Cal = new();
Gun _gun = new();

_gun.UserControl();

Console.WriteLine("Mag fully emptied!");
Console.ReadLine();