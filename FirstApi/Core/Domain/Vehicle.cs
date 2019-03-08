using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Core.Domain
{
    public class Vehicle
    {
        public string Brand { get; protected set; }
        public string Name { get; protected set; }
        public int Seats { get; protected set; }

        protected Vehicle()
        {

        }

        protected Vehicle(string brand, string name, int seats)
        {
            SetBrand(brand);
            SetName(name);
            SetSeats(seats);
        }

        private void SetSeats(int seats)
        {
            if (seats < 0)
            {
                throw new Exception("Seats must be greater than 0");
            }
            if (seats > 9)
            {
                throw new Exception("You can not provide more than 9 seats");
            }
            if (Seats == seats)
            {
                return;
            }

            Seats = seats; 
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Name can not be empty");
            }
            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        private void SetBrand(string brand)
        {
            if (string.IsNullOrEmpty(brand))
            {
                throw new Exception("Brand can not be empty");
            }
            if (Brand == brand)
            {
                return;
            }

            Brand = brand;
        }

        private static Vehicle Create(string brand, string name, int seats)
            => new Vehicle(brand, name, seats);                    
    }
}
