using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conAppSpinGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your Luckynumber from 1 to 10: ");
            int luckyNumber = int.Parse(Console.ReadLine());
            Game game = new Game(name, luckyNumber);

            SpinEventhandler spinDelegate = (energyLevelChange, winningProbabilityChange) =>
            {
                game.EnergyLevel += energyLevelChange;
                game.WinningProbability += winningProbabilityChange;
            };
            game.SpinEvent += spinDelegate;
            game.Spin();

            if (game.EnergyLevel >= 4 && game.WinningProbability > 60)
            {
                Console.WriteLine($"Winner: {game.Name}");
            }
            else if (game.EnergyLevel >= 1 && game.WinningProbability > 50)
            {
                Console.WriteLine($"Runner up: {game.Name}");
            }
            else
            {
                Console.WriteLine($"Looser: {game.Name}");
            }
            Console.ReadKey();
        }
    }
}
