using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    internal class Person
    {
        double _budget;

        public List<Animal> myAnimals { get; set; }
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public double Budget
        {
            get { return _budget; }
            set
            {
                if(value<0) _budget = 0;
                else _budget = value;
            }
        }

        public Person() { 
            Id = Guid.NewGuid();
            myAnimals = new List<Animal>();
        }
        public Person(string name,string surname,double budget) :this()
        {
            Name = name;
            Surname = surname;
            Budget = budget;
        }

        public void showPets() {foreach (var item in myAnimals) { Console.WriteLine(item);}}
        public void FeedAnimal(string name, int mealq) {
            foreach (var item in myAnimals)
            {
                if (item.Name == name)
                {
                    try
                    {
                        item.Eat(mealq);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return;
                }
            }
            throw new Exception($"{name} doesn't exist in this shop");
        }
        public void PlayAnimal(string name) { foreach (var item in myAnimals) { if (item.Name == name) item.Play();return; }
            throw new Exception($"{name} doesn't exist in this shop");
        }
        public void SleepAnimal(string name) { foreach (var item in myAnimals) { if (item.Name == name) item.Sleep(); return; }
            throw new Exception($"{name} doesn't exist in this shop");
        }
        

        public int GetTotalQuantities()
        {
            int total = 0;
            foreach (var item in myAnimals) total += item.MealQuantity;
            return total;
        }




    }
}
