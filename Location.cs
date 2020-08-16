using System;
using System.Collections.Generic;
using static MarsRover.EnumTypes;

namespace MarsRover
{ 
    public class Location : InterfaceLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        public Location()
        {
            X = Y = 0;
            Direction = Directions.N; //kurala göre default 0,0,N olmalı
        }

        private void Rot90Left()
        {
            switch (Direction)
            {   
                //sola döndüğü zaman pusulaya göre soldan sağa doğru gidecek
                case Directions.N:
                    Direction = Directions.W;
                    break;
                case Directions.S:
                    Direction = Directions.E;
                    break;
                case Directions.E:
                    Direction = Directions.N;
                    break;
                case Directions.W:
                    Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void Rot90Right()
        {
            switch (Direction)
            {
                //sağa döndüğü zaman pusulaya göre sağdan sola doğru gidecek
                case Directions.N:
                    Direction = Directions.E;
                    break;
                case Directions.S:
                    Direction = Directions.W;
                    break;
                case Directions.E:
                    Direction = Directions.S;
                    break;
                case Directions.W:
                    Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        private void MoveInSameDirection()
        {
            switch (Direction)
            {
                // (x, y + 1 kuralına göre)
                case Directions.N:
                    Y += 1;
                    break;
                case Directions.S:
                    Y -= 1;
                    break;
                case Directions.E:
                    X += 1;
                    break;
                case Directions.W:
                    X -= 1;
                    break;
                default:
                    break;
            }
        }

        public void Start(List<int> maxPoints, string moves)
        {
            foreach (var t in moves)
            {
                switch (t)
                {
                    case 'L':
                        Rot90Left();
                        break;
                    case 'R':
                        Rot90Right();
                        break;
                    case 'M':
                        MoveInSameDirection();
                        break;                   
                    default:
                        Console.WriteLine($"Lütfen bilinen karakter giriniz {t}");
                        break;
                }

                if (X < 0 || X > maxPoints[0] || Y < 0 || Y > maxPoints[1])
                {
                    throw new Exception($"Pozisyonun sınırları aştı!  : ({maxPoints[0]} , {maxPoints[1]})");
                }
            }
        }
    }
}
