using FinalProjectYear3;
using System.Net;
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

BulletCollection _bulletCollection = new();
Bullet _bullet = new();
_9mm _9Mm = new();
_45ACP _45ACP = new();
_50Cal _50Cal = new();
Gun _gun = new();
if(NetManager.DecideHost() == "1")
{
    _gun.UserControl();
}
else
{
    Target.DrawTarget();
}

Console.WriteLine("Mag fully emptied!");
Console.ReadLine();