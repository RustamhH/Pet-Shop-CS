using System;
using static System.Formats.Asn1.AsnWriter;
using System.Reflection;

namespace PetShop
{
    internal class Program
    {
        static public int Print(List<string> arr)
        {
            int index = 0;
            while(true)
            {
                Console.Clear();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (i == index) Console.ForegroundColor = ConsoleColor.DarkRed;
                    else Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(50, i + 10);
                    Console.WriteLine(arr[i]);
                }
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (index == 0) index = arr.Count-1;
                    else index--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (index == arr.Count - 1) index = 0;
                    else index++;
                }
                else if(key.Key==ConsoleKey.Enter)
                {
                    return index;
                }
            }
        }
        static void Main(string[] args)
        {

            Console.WriteLine("\n\n\t\tPet Shop");
            Console.Write("Enter Your Name: ");
            string ?name = Console.ReadLine();
            Console.Write("Enter Your Surname: ");
            string ?surname = Console.ReadLine();
            Console.Write("Enter Your Budget: ");
            double.TryParse(Console.ReadLine(), out double budget);
            Person p1 = new Person(name, surname, budget);

            Shop s1 = new Shop();
            s1.AddAnimal(new Cat("Mestan", "Male", 123, 32));
            while (true)
            {
                Console.Title=$"Your Budget: {p1.Budget}";
                int choice = Print(new List<string> { "Add", "Buy", "Remove", "Play", "Feed", "Sleep", "Get Total Meal Quantity", "Get Total Prices", "Show My Pets", "Exit" });
                if (choice == 0) // add
                {
                    string? _name, _gender;
                    ushort _age;
                    double _price;
                    Console.Write("Enter Pet Name: ");
                    _name = Console.ReadLine();
                    Console.Write("Enter Pet Gender: ");
                    _gender = Console.ReadLine();
                    Console.Write("Enter Pet Age: ");
                    _age = Convert.ToUInt16(Console.ReadLine());
                    Console.Write("Enter Pet Price: ");
                    _price = Convert.ToDouble(Console.ReadLine());
                    int animalchoice = Print(new List<string> { "Cat", "Dog", "Bird", "Fish" });
                    if (animalchoice == 0)
                    {
                        if (_name != null && _gender != null) s1.AddAnimal(new Cat(_name, _gender, _price, _age));
                    }
                    else if (animalchoice == 1)
                    {
                        if (_name != null && _gender != null) s1.AddAnimal(new Dog(_name, _gender, _price, _age));
                    }
                    else if (animalchoice == 2)
                    {
                        if (_name != null && _gender != null) s1.AddAnimal(new Bird(_name, _gender, _price, _age));
                    }
                    else if (animalchoice == 3)
                    {
                        if (_name != null && _gender != null) s1.AddAnimal(new Fish(_name, _gender, _price, _age));
                    }    
                            
                }
                else if (choice == 1) // buy
                {
                    int animalchoice = Print(new List<string> { "Cat", "Dog", "Bird", "Fish" });
                    Console.Clear();
                    if (animalchoice == 0) 
                    {
                        s1.ShowCats();
                        Console.Write("Enter Cat Name: ");
                        string? wantingAnimal = Console.ReadLine();
                        try{if (wantingAnimal != null) s1.BuyCat(wantingAnimal, ref p1);}
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                    else if (animalchoice == 1)
                    {
                        s1.ShowDogs();
                        Console.Write("Enter Dog Name: ");
                        string? wantingAnimal = Console.ReadLine();
                        try { if (wantingAnimal != null) s1.BuyDog(wantingAnimal, ref p1); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                    else if (animalchoice == 2)
                    {
                        s1.ShowBirds();
                        Console.Write("Enter Bird Name: ");
                        string? wantingAnimal = Console.ReadLine();
                        try { if (wantingAnimal != null) s1.BuyBird(wantingAnimal, ref p1); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                    else
                    {
                        s1.ShowFishes();
                        Console.Write("Enter Fish Name: ");
                        string? wantingAnimal = Console.ReadLine();
                        try { if (wantingAnimal != null) s1.BuyFish(wantingAnimal, ref p1); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                }
                else if (choice == 2) // remove
                {
                    int removechoice = Print(new List<string> { "By Name", "By Price", "By Meal Quantity", "By Age" });
                    Console.Clear();
                    if (removechoice == 0)
                    {
                        Console.Write("Enter Name: ");
                        string? removename = Console.ReadLine();
                        try { if (removename != null) s1.RemoveByName(removename); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                    else if (removechoice == 1)
                    {
                        Console.Write("Enter Price: ");
                        string? removeprice = Console.ReadLine();
                        try { if (removeprice != null) s1.RemoveByPrice(Convert.ToDouble(removeprice)); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                    else if (removechoice == 2)
                    {
                        Console.Write("Enter Meal Quantity: ");
                        string? removemeal = Console.ReadLine();
                        try { if (removemeal != null) s1.RemoveByMealQuantity(Convert.ToInt32(removemeal)); }
                        catch(Exception ex) { Console.WriteLine(ex.Message); }
                    }
                    else
                    {
                        Console.Write("Enter Age: ");
                        string? removeage = Console.ReadLine();
                        try { if (removeage != null) s1.RemoveByMealQuantity(Convert.ToUInt16(removeage)); }
                        catch(Exception ex) { Console.WriteLine(ex.Message); }
                    }
                }
                else if(choice==3) // play
                {
                    Console.Clear();
                    p1.showPets();
                    Console.Write("Enter pet name you want to play with: ");
                    string?playingAnimal=Console.ReadLine();
                    if(playingAnimal != null)
                    {
                        try {p1.PlayAnimal(playingAnimal);}
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                }
                else if(choice==4) // feed
                {
                    Console.Clear();
                    p1.showPets();
                    Console.Write("Enter pet name you want to feed: ");
                    string? feedingAnimal = Console.ReadLine();
                    Console.Write("Enter meal quantity: ");
                    int mealq=Convert.ToInt32(Console.ReadLine());

                    if (feedingAnimal != null)
                    {
                        try { p1.FeedAnimal(feedingAnimal, mealq); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                }
                else if(choice==5) // sleep
                {
                    Console.Clear();
                    p1.showPets();
                    Console.Write("Enter pet name you want to put to sleep: ");
                    string? sleepingAnimal = Console.ReadLine();
                    if (sleepingAnimal != null)
                    {
                        try { p1.SleepAnimal(sleepingAnimal); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }
                }
                else if(choice==6) // total meal
                {
                    Console.Clear();
                    Console.WriteLine($"Total Quantities: {p1.GetTotalQuantities()}");
                    Console.ReadKey();
                }
                else if(choice==7)
                {
                    int animalChoice = Print(new List<string> { "Cat", "Dog", "Bird", "Fish" });
                    if (animalChoice == 0)
                    {
                        Console.WriteLine($"Total Cat Price: {s1.GetCatPrices()}");
                        Console.ReadKey();
                    }
                    else if (animalChoice == 1)
                    {
                        Console.WriteLine($"Total Dog Price: {s1.GetDogPrices()}");
                        Console.ReadKey();
                    }
                    else if (animalChoice == 2)
                    {
                        Console.WriteLine($"Total Bird Price: {s1.GetBirdPrices()}");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Total Fish Price: {s1.GetFishPrices()}");
                        Console.ReadKey();
                    }
                }
                else if (choice == 8) // show pets
                {
                    Console.Clear();
                    p1.showPets();
                    Console.ReadKey(); // system(pause)
                }
                else break;
            }
        }
    }
}