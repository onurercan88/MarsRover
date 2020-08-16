using System;
using System.Linq;
using static MarsRover.EnumTypes;

namespace MarsRover
{
    public class Program
    {
        static void Main(string[] args)
        {
            var maxP = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            var startP = Console.ReadLine().Trim().Split(' ');
            Location position = new Location();

            if (startP.Count() == 3)
            {
                position.X = Convert.ToInt32(startP[0]);
                position.Y = Convert.ToInt32(startP[1]);
                position.Direction = (Directions)Enum.Parse(typeof(Directions), startP[2]);
            }

            var moves = Console.ReadLine().ToUpper();

            try
            {
                position.Start(maxP, moves);
                Console.WriteLine($"{position.X} {position.Y} {position.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
