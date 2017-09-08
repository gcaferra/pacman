using System;
using System.IO;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            var pacman = new PacMan(3,5000);

            var input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), args[0]));
            
            var engine = new GameEngine(input, pacman);
            
            while(engine.CanContinue())
                engine.MovePacMan();
            
            Console.WriteLine($"PacMan Score {pacman.Score} - Lives {pacman.Lives} - HasAlive {pacman.HasLives()}");
            
        }

    }
}