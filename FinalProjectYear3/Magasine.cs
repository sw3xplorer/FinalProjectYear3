using System.ComponentModel;

namespace FinalProjectYear3;

public class Magasine
{
    // Create a stack to serve as a magasine.
    Stack<Bullet> _magasine;
    // Declare capacity and current capacity variable.
    int _maxCapacity = 10;
    int _currentCapacity;
    // Constructor that makes a new magasine stack, resets the current capacity to 0
    // and writes magasine information.
    public Magasine()
    {
        _magasine = new();
        _currentCapacity = 0;
        Console.SetCursorPosition(135, 0);
        Console.WriteLine($"Magasine: {_currentCapacity} / {_maxCapacity}");
    }
    // Method that loads a bullet into the magasine (stack).
    public void LoadBullet(Bullet bullet)
    {
        // Check if bullet can fit.
        if (_currentCapacity + bullet.Size > _maxCapacity)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("This bullet can't fit.");
            Task.Delay(2000).Wait();
        }
        else
        {
            _currentCapacity += bullet.Size;
            _magasine.Push(Bullet.CreateBullet(bullet));
            Console.SetCursorPosition(135, 0);
            Console.WriteLine($"Magasine: {_currentCapacity} / {_maxCapacity}");
        }
    }
    // Return the current magasine capacity.
    public int GetCapacity()
    {
        return _currentCapacity;
    }
    // A method that returns a bullet to be loaded into the gun chamber. Removes the instance
    // at the top of the stack when loaded.
    public Bullet LoadChamber()
    {
        Bullet _chamberedBullet = _magasine.Peek();
        _magasine.Pop();
        _currentCapacity -= _chamberedBullet.Size;
        return _chamberedBullet;
    }
    // Removes (ejects) the bullet from the chamber after the gun is fired.
    public Bullet RemoveChamberedBullet()
    {
        Bullet _chamberedBullet = new();
        return _chamberedBullet;
    }
}
