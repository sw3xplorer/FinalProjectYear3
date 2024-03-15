using System.Security.Cryptography.X509Certificates;

namespace FinalProjectYear3;

public class Gun
{
    bool _confirmAction;
    bool _escKeyPressed;
    int _choice;
    public Magasine Mag = new();
    Bullet _bulletInChamber = new();

    public void UserControl()
    {
        _escKeyPressed = false;
        Select(1, 5, 3, "Load magasine", "Fire", "", false);
        if(_choice == 0)
        {
            Console.Clear();
            while(Mag.GetCapacity() < 10 && !_escKeyPressed)
            {
                Select(2, 5, 3, "9mm", "45 ACP", "50 caliber", true);
            }
        }
        else
        {

        }
    }
    // public void ddd()
    // {
    //     Mag.LoadBullet(new _45ACP());
    // }
    public void Fire()
    {
        _bulletInChamber = Mag.LoadChamber();

    }

    public bool Select(int maxChoice, int startPos, int interval, string text1, string text2, string text3, bool escKey)
    {
        _choice = 0;
        _confirmAction = false;
        Console.SetCursorPosition(1, startPos);
        Console.WriteLine(text1);
        Console.SetCursorPosition(1, startPos + interval);
        Console.WriteLine(text2);
        Console.SetCursorPosition(1, startPos + interval);
        Console.WriteLine(text3);
        while (!_confirmAction)
        {
            if (_choice >= 0 && _choice <= maxChoice)
            {
                Console.SetCursorPosition(0, startPos + _choice * interval);
                Console.WriteLine(">");
            }

            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.DownArrow && _choice < maxChoice)
            {
                _choice++;
                Console.SetCursorPosition(0, startPos + ((_choice - 1) * interval));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.UpArrow && _choice > 0)
            {
                _choice--;
                Console.SetCursorPosition(0, startPos + ((_choice + 1) * interval));
                Console.WriteLine(" ");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                _confirmAction = true;
            }
            else if (escKey && key.Key == ConsoleKey.Escape)
            {
                _escKeyPressed = true;
                _confirmAction = true;
            }
        }
        return true;
    }
}
