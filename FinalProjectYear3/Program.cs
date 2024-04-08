using FinalProjectYear3;
using System.Net;
Console.WriteLine("1 for host or 2 for client.");
string _result = Console.ReadLine();
if(_result == "1")
{
    NetManager.Host();
}
else if(_result == "2")
{
    NetManager.Client();
}
else
{

}

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