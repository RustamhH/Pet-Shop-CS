using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    internal abstract class Animal
    {
        string _gender;
        double _energy;
        double _price;
        int _mealQuantity;


        public string Name { get; set; }
        public Guid Id { get; init; }

        public string Gender
        {
            get { return _gender; }
            set {
                if (value == "Male" || value == "Female") _gender = value;
                else _gender = "Unknown";
            }
        }


        public double Energy
        {
            get { return _energy; }
            set {
                if (value > 100) _energy = 100;
                else if (value < 0) _energy = 0;
                else _energy = value;
            }
        }


        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0) _price = 0;
                else _price = value;
            }
        }


        public ushort Age { get; set; }


        public int MealQuantity {
            get { return _mealQuantity; } 
            set
            {
                if(value<0) _mealQuantity = 0;
                else _mealQuantity = value;
            } 
        }

        public Animal() { Id = Guid.NewGuid(); }

        public Animal(string name,string gender,double price,ushort age) :this()
        {
            Name = name;
            Gender= gender;
            Price= price;
            Age = age;
        }


        public Animal(string name, string gender, double price, ushort age,int mealQuantity,double energy) :this(name,gender, price,age)
        {
            MealQuantity = mealQuantity;
            Energy = energy;
        }


        public override string ToString()
        {
            return
                $@"
                                Animal Info
                
                Id: {Id}
                Name: {Name}
                Gender: {Gender}
                Price: {Price}
                Age: {Age}
                Meal Quantity: {MealQuantity}
                Energy: {Energy}
                ";
        }


        public void Eat(int mealQuantity)
        {
            if (mealQuantity < 0) throw new Exception("Invalid Parameter");
            Console.Clear();
            Console.WriteLine("Press ESC to stop");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                if (Energy == 100)
                {
                    Console.WriteLine($"{Name} is full");
                    Thread.Sleep(1000);
                    break;
                }
                Console.WriteLine($"Feeding {Name}\tEnergy {Energy}\n");
                Thread.Sleep(1000);
                Console.Clear();
                Energy += 10;
                Price += 10;
                MealQuantity = Convert.ToInt32(mealQuantity - _energy);
            }

        }
        public void Play()
        {
            Console.Clear();
            Console.WriteLine("Press ESC to stop");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                if (Energy == 0)
                {
                    Console.WriteLine($"{Name} is tired");
                    Thread.Sleep(1000);
                    break;
                }
                MakePlaySound();
                Console.WriteLine($"Energy {Energy}");
                Thread.Sleep(1000);
                Console.Clear();
                Energy -= 10;
            }

        }
        public void Sleep()
        {
            Console.Clear();
            Console.WriteLine("Press ESC to stop");
            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                if (Energy == 100)
                {
                    Console.WriteLine($"{Name} woke up with full energy");
                    Thread.Sleep(1000);
                    break;
                }
                if (MealQuantity == 0) break;
                Console.WriteLine($"{Name} is sleeping\tEnergy {Energy}\n");
                Thread.Sleep(1000);
                Console.Clear();
                Energy += 10;
                Price += 5;
            }
        }
        public abstract void MakePlaySound();
    }
    internal class Cat:Animal
    {

        public override void MakePlaySound()
        {
            Console.WriteLine("Miau Miau");
        }
        public Cat() : base() {}

        public Cat(string name, string gender, double price, ushort age) : this()
        {
            Name = name;
            Gender = gender;
            Price = price;
            Age = age;
        }


        public Cat(string name, string gender, double price, ushort age, int mealQuantity, double energy) : base(name, gender, price, age)
        {
            MealQuantity = mealQuantity;
            Energy = energy;
        }
    }
    internal class Dog:Animal
    {

        public override void MakePlaySound()
        {
            Console.WriteLine("Hav Hav");
        }
        public Dog() : base() {}

        public Dog(string name, string gender, double price, ushort age) : this()
        {
            Name = name;
            Gender = gender;
            Price = price;
            Age = age;
        }


        public Dog(string name, string gender, double price, ushort age, int mealQuantity, double energy) : base(name, gender, price, age)
        {
            MealQuantity = mealQuantity;
            Energy = energy;
        }
    }
    internal class Fish:Animal
    {

        public override void MakePlaySound()
        {
            Console.WriteLine("Glock Glock");
        }
        public Fish() : base() {}

        public Fish(string name, string gender, double price, ushort age) : this()
        {
            Name = name;
            Gender = gender;
            Price = price;
            Age = age;
        }


        public Fish(string name, string gender, double price, ushort age, int mealQuantity, double energy) : base(name, gender, price, age)
        {
            MealQuantity = mealQuantity;
            Energy = energy;
        }
    }
    internal class Bird:Animal
    {

        public override void MakePlaySound()
        {
            Console.WriteLine("Cik Cik");
        }
        public Bird() : base() {}

        public Bird(string name, string gender, double price, ushort age) : this()
        {
            Name = name;
            Gender = gender;
            Price = price;
            Age = age;
        }


        public Bird(string name, string gender, double price, ushort age, int mealQuantity, double energy) : base(name, gender, price, age)
        {
            MealQuantity = mealQuantity;
            Energy = energy;
        }
    }
}
