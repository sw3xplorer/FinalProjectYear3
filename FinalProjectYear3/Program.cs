using FinalProjectYear3;
using System.Net; // Add System.Net for network functions
Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight); // Enlarge window.

// Create instances of classes to be used.
BulletCollection _bulletCollection = new();
Bullet _bullet = new();
Bullet9mm _9Mm = new();
Bullet45ACP _45ACP = new();
Bullet50Cal _50Cal = new();
// A method which decides if THIS instance of the program is the host or the client.
if (NetManager.DecideHost() == "1")
{
    // Gives host controls
    Gun _gun = new();
    _gun.UserControl();
    Console.WriteLine("Mag fully emptied!");
}
else
{
    // Gives client controls and draws a target ASCII on the client screen
    Target.DrawTarget();
}

Console.ReadLine();