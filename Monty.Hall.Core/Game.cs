using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Monty.Hall.Core
{
    public class Game
    {
        public List<Prize> Doors = new List<Prize>();
        private readonly int _noOfDoors;
        private readonly Random _rnd = new Random(DateTime.Now.Millisecond);
        public Game(int noOfDoors)
        {
            _noOfDoors = noOfDoors;
            Init();
        }

        private void Init()
        {
            // fill the doors with goats
            for (int door = 0; door < _noOfDoors; door++)
            {
                Doors.Add(Prize.Goat);
            }
            // pick random door for the car
            Doors[_rnd.Next(0, _noOfDoors - 1)] = Prize.Car;
        }

        public bool Swap()
        {
            // Select a random door
            var selectedDoor = _rnd.Next(0, _noOfDoors - 1);

            // Of the non-selected door, identify the first one with a goat

            int goatDoor = -1;
            int swappedDoor = -1;

            for (int currentDoor = 0; currentDoor < _noOfDoors ; currentDoor++)
            {
                if (currentDoor == selectedDoor)
                    continue;

                if (Doors[currentDoor] == Prize.Goat)
                {
                    goatDoor = currentDoor;
                    break;
                }
            }

            for (int currentDoor = 0; currentDoor < _noOfDoors; currentDoor++)
            {
                if (currentDoor == selectedDoor || currentDoor == goatDoor)
                    continue;

                return Doors[currentDoor] == Prize.Car;

            }
            return true;
        }

        public bool Stay()
        {
            return Doors[_rnd.Next(0, _noOfDoors - 1)] == Prize.Car;
        }

    }

    public enum Prize
    {
        Goat = 0,
        Car = 1
    }
}
