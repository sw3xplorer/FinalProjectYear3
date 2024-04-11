using System.Security.Cryptography.X509Certificates;

namespace FinalProjectYear3;

public class Gun
{
    // Declare variables to be used.
    bool _confirmAction;
    bool _escKeyPressed;
    bool _hitTarget;
    int _choice;
    public Magasine Mag = new();
    Random _generator = new Random();
    Bullet _bulletInChamber = new();

    // Method which allows the user (host) to make selections via the arrow keys.
    // Consists of multiple other methods.
    public void UserControl()
    {
        _escKeyPressed = false;
        Select(1, 5, 3, "Load magasine", "Fire", "", false);
        if (_choice == 0)
        {
            ClearArea.Clear(0, 0, 40, 20);
            while (Mag.GetCapacity() < 10 && !_escKeyPressed)
            {
                if(Select(2, 5, 3, "9mm  ACC: 95%  DMG: 5  Size: 1", "45 ACP  ACC: 80%  DMG: 12  Size: 2", "50 caliber  ACC: 75%  DMG: 20  Size: 4", true) && !_escKeyPressed)
                {
                    Mag.LoadBullet(BulletCollection.Bullets[_choice]);
                }
                if(_escKeyPressed)
                {
                    ClearArea.Clear(0, 0, 40, 25);
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine("Load more?");
                    Select(1, 5, 3, "Yes", "No (Fire gun)", "", false);
                    if(_choice == 1)
                    {
                        break;
                    }
                    else
                    {
                        _escKeyPressed = false;
                    }
                }
            }
            Fire();
        }
        else
        {
            while (Mag.GetCapacity() == 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Maybe you should load some bullets.");
                UserControl();
            }
        }
    }
    
    // Method which fires the gun, ejects the spent bullet cartridge and loads the
    // next bullet from the magasine into the chamber.
    public void Fire()
    {
        ClearArea.Clear(0,0, 40, 25);
        // A while loop allowing the user to fire the gun as long as there are bullets.
        while (Mag.GetCapacity() != 0)
        {
            _hitTarget = false;
            // Gets the bullet at the top of the stack and sets it as the chambered one.
            _bulletInChamber = Mag.LoadChamber();
            Select(0, 5, 1, "Fire gun", "", "", false);

            // Determine if bullet hits.
            if (_bulletInChamber.Accuracy > _generator.Next(101)) _hitTarget = true;

            // Ping the other device with the data of the bullet (DMG) and if it hit.
            NetManager.Send(_hitTarget, _bulletInChamber.GetDamage());

            // Remove spent bullet from chamber.
            Mag.RemoveChamberedBullet();

            Console.SetCursorPosition(135, 0);
            Console.WriteLine($"Magasine: {Mag.GetCapacity()} / 10 ");
        }
    }
    // Return if the bullet has hit. 
    public bool GetHitTarget()
    {
        return _hitTarget;
    }
    // Method that gives the user the ability to select an option, similar to a menu.
    // The amount of choices, if the ESC key is available and the gap between texts can be
    // adjusted.
    public bool Select(int maxChoice, int startPos, int interval, string text1, string text2, string text3, bool escKey)
    {
        // Reset the choice and bool.
        _choice = 0;
        _confirmAction = false;

        // Write out the text for the options.
        Console.SetCursorPosition(1, startPos);
        Console.WriteLine(text1);
        Console.SetCursorPosition(1, startPos + interval);
        Console.WriteLine(text2);
        Console.SetCursorPosition(1, startPos + interval * 2);
        Console.WriteLine(text3);

        // A while loop for being able to select.
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
