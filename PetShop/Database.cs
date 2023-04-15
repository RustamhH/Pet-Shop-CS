using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace PetShop
{
    internal class Shop
    {
        public List<Dog> dogs { get; set; }
        public List<Fish> fishes { get; set; }
        public List<Bird> birds { get; set; }
        public List<Cat> cats { get; set; }

        public Shop()
        {
            dogs = new List<Dog>();
            cats = new List<Cat>();
            fishes = new List<Fish>();
            birds = new List<Bird>();
        }
        
        public void AddAnimal(Animal animal)
        {
            if (animal is Bird bird) {
                birds.Add(bird);
            } 
            else if (animal is Fish fish)
            {
                fishes.Add(fish);
            }
            else if (animal is Cat cat)
            {
                cats.Add(cat);
            }
            else if (animal is Dog dog) { 
                dogs.Add(dog); 
            } 
        }
        
        public int GetDogMealQuantities()
        {
            int total = 0;
            foreach (var item in dogs){total += item.MealQuantity;}
            return total;
        }
        public int GetCatMealQuantities()
        {
            int total = 0;
            foreach (var item in cats){total += item.MealQuantity;}
            return total;
        }
        public int GetBirdMealQuantities()
        {
            int total = 0;
            foreach (var item in birds) { total += item.MealQuantity; }
            return total;
        }
        public int GetFishesMealQuantities()
        {
            int total = 0;
            foreach (var item in birds){total += item.MealQuantity;}
            return total;
        }
        

        public double GetCatPrices()
        {
            double totalPrice =0;
            foreach (var item in cats){totalPrice += item.Price;}
            return totalPrice;
        }
        public double GetDogPrices()
        {
            double totalPrice =0;
            foreach (var item in dogs){totalPrice += item.Price;}
            return totalPrice;
        }
        public double GetBirdPrices()
        {
            double totalPrice =0;
            foreach (var item in birds){totalPrice += item.Price;}
            return totalPrice;
        }
        public double GetFishPrices()
        {
            double totalPrice =0;
            foreach (var item in fishes){totalPrice += item.Price;}
            return totalPrice;
        }



        public void RemoveByName(string name)
        {
            foreach (var item in fishes)
            {
                if(item.Name == name)
                {
                    fishes.Remove(item);
                    return;
                }
            }
            foreach (var item in dogs)
            {
                if(item.Name==name)
                {
                    dogs.Remove(item);
                    return;
                }
            }
            foreach (var item in cats)
            {
                if(item.Name==name)
                {
                    cats.Remove(item);
                    return;
                }
            }
            foreach (var item in birds)
            {
                if(item.Name==name)
                {
                    birds.Remove(item);
                    return;
                }
            }
            throw new Exception($"{name} doesn't exist in this shop");
        }
        public void RemoveByPrice(double price)
        {
            foreach (var item in fishes)
            {
                if (item.Price == price)
                {
                    fishes.Remove(item);
                    return;
                }
            }
            foreach (var item in dogs)
            {
                if (item.Price == price)
                {
                    dogs.Remove(item);
                    return;
                }
            }
            foreach (var item in cats)
            {
                if (item.Price == price)
                {
                    cats.Remove(item);
                    return;
                }
            }
            foreach (var item in birds)
            {
                if (item.Price == price)
                {
                    birds.Remove(item);
                    return;
                }
            }
            throw new Exception($"{price} doesn't exist in this shop");
        }
        public void RemoveByAge(ushort age)
        {
            foreach (var item in fishes)
            {
                if (item.Age == age)
                {
                    fishes.Remove(item);
                    return;
                }
            }
            foreach (var item in dogs)
            {
                if (item.Age == age)
                {
                    dogs.Remove(item);
                    return;
                }
            }
            foreach (var item in cats)
            {
                if (item.Age == age)
                {
                    cats.Remove(item);
                    return;
                }
            }
            foreach (var item in birds)
            {
                if (item.Age == age)
                {
                    birds.Remove(item);
                    return;
                }
            }
            throw new Exception($"{age} doesn't exist in this shop");
        }
        public void RemoveByMealQuantity(int mealq)
        {
            foreach (var item in fishes)
            {
                if (item.MealQuantity == mealq)
                {
                    fishes.Remove(item);
                    return;
                }
            }
            foreach (var item in dogs)
            {
                if (item.MealQuantity == mealq)
                {
                    dogs.Remove(item);
                    return;
                }
            }
            foreach (var item in cats)
            {
                if (item.MealQuantity == mealq)
                {
                    cats.Remove(item);
                    return;
                }
            }
            foreach (var item in birds)
            {
                if (item.MealQuantity == mealq)
                {
                    birds.Remove(item);
                    return;
                }
            }
            throw new Exception($"{mealq} doesn't exist in this shop");
        }

        public void BuyCat(string name,ref Person buyer)
        {
            foreach (var item in cats)
            {
                if(name==item.Name)
                {
                    if (item.Price > buyer.Budget) throw new Exception("Not Enough Budget");
                    buyer.Budget -= item.Price;
                    buyer.myAnimals.Add(item);
                    cats.Remove(item);
                    return;
                }
            }
            throw new Exception($"{name} doesn't exist in this shop");
        }
        public void BuyDog(string name,ref Person buyer)
        {
            foreach (var item in dogs)
            {
                if(name==item.Name)
                {
                    if (item.Price > buyer.Budget) throw new Exception("Not Enough Budget");
                    buyer.Budget -= item.Price;
                    buyer.myAnimals.Add(item);
                    dogs.Remove(item);
                    return;
                }
            }
            throw new Exception($"{name} doesn't exist in this shop");
        }
        public void BuyFish(string name,ref Person buyer)
        {
            foreach (var item in fishes)
            {
                if(name==item.Name)
                {
                    if (item.Price > buyer.Budget) throw new Exception("Not Enough Budget");
                    buyer.Budget -= item.Price;
                    buyer.myAnimals.Add(item);
                    fishes.Remove(item);
                    return;
                }
            }
            throw new Exception($"{name} doesn't exist in this shop");
        }
        public void BuyBird(string name,ref Person buyer)
        {
            foreach (var item in birds)
            {
                if(name==item.Name)
                {
                    if (item.Price > buyer.Budget) throw new Exception("Not Enough Budget");
                    buyer.Budget -= item.Price;
                    buyer.myAnimals.Add(item);
                    birds.Remove(item);
                    return;
                }
            }
            throw new Exception($"{name} doesn't exist in this shop");
        }

        public void ShowCats() {foreach (var item in cats) {Console.WriteLine(item);}}
        public void ShowDogs() {foreach (var item in dogs) {Console.WriteLine(item);}}
        public void ShowBirds() {foreach (var item in birds) {Console.WriteLine(item);}}
        public void ShowFishes() {foreach (var item in fishes) {Console.WriteLine(item);}}

        
        
    }
}
