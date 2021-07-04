using System;
using System.Globalization;
using System.IO;
using System.Threading;

namespace coffee_machine
{
    class Program
    {
        static void Main(string[] args)
        {

            bool notsure = false;
            int coffeepowder_state = 500;
            int water_state = 500;
            int milk_state = 500;

            do
            {
                PrintLogo();
                Date_Time();
                Greeting();
                State_all(coffeepowder_state, water_state, milk_state);
                Query_Menu();   //display of the selection menu
                ConsoleKeyInfo UserInput = Console.ReadKey();

                switch (UserInput.Key)
                {
                    case ConsoleKey.D1: //coffee
                    case ConsoleKey.NumPad1:
                        if (coffeepowder_state >= 15 && water_state >= 10 && milk_state >= 10)  //Abfrage die pr
                        {
                            coffeepowder_state -= 10;
                            water_state -= 15;
                            milk_state -= 5;
                            Drink_ready();
                        }
                        else
                        {
                            Container_State(coffeepowder_state, water_state, milk_state); //Error message,if the container state is too low
                        }
                        break;

                    case ConsoleKey.D2: //espresso
                    case ConsoleKey.NumPad2:
                        if (coffeepowder_state >= 15 && water_state >= 10)
                        {
                            coffeepowder_state -= 20;
                            water_state -= 10;
                            Drink_ready();
                        }
                        else
                        {
                            Container_State(coffeepowder_state, water_state, milk_state);
                        }
                        break;

                    case ConsoleKey.D3: //cappuccino
                    case ConsoleKey.NumPad3:
                        if (coffeepowder_state >= 15 && water_state >= 10 && milk_state >= 10)
                        {
                            coffeepowder_state -= 15;
                            water_state -= 10;
                            milk_state -= 10;
                            Drink_ready();
                        }
                        else
                        {
                            Container_State(coffeepowder_state, water_state, milk_state);
                        }
                        break;

                    case ConsoleKey.D4: //milkcoffee
                    case ConsoleKey.NumPad4:
                        if (coffeepowder_state >= 15 && water_state >= 10 && milk_state >= 10)
                        {
                            coffeepowder_state -= 10;
                            water_state -= 5;
                            milk_state -= 15;
                            Drink_ready();
                        }
                        else
                        {
                            Container_State(coffeepowder_state, water_state, milk_state);
                        }
                        break;

                    case ConsoleKey.D5: //cleaning
                    case ConsoleKey.NumPad5:
                        Console.WriteLine("\nCleaning is carried out.Please do not switch of the device.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        notsure = false;
                        break;

                    case ConsoleKey.D6: //exit
                    case ConsoleKey.NumPad6:
                        Console.WriteLine("\nGoodbye");
                        return;

                    default:        //
                        notsure = false;
                        Console.WriteLine("Please chose the righz Number from the Menu!");
                        break;
                }
            } while (notsure == false);     //
        }

        private static void PrintLogo()
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;
            string[] fileLogo = File.ReadAllLines("Logo.txt");
            for (int counter = 0; counter < fileLogo.Length; counter++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - fileLogo[counter].Length / 2, counter);
                Console.WriteLine(fileLogo[counter]);
            }
            Console.ResetColor();    
        }

        private static void Date_Time()
        {
            DateTime LocalDate = DateTime.Now.Date;
            DateTime LocalTime = DateTime.Now;
            var Time = LocalTime.ToString("HH:mm");
            var Date = LocalDate.Date.ToString("dd-MM-yyyy");
            Console.WriteLine("Date: {0}",Date);
            Console.WriteLine("Time: "+Time);
        }

        private static void State_all(int coffeepowder_state, int water_state, int milk_state)
        {
            Console.WriteLine("\nCoffeepowder: " + coffeepowder_state);
            Console.WriteLine("Water: " + water_state);
            Console.WriteLine("Milk: " + milk_state);
        }

        private static void Container_State(int coffeepowder_state, int water_state, int milk_state)
        {
            Console.WriteLine("\nError: Please check the container state Coffee: " + coffeepowder_state);
            Console.WriteLine("Error: Please check the container state Coffee: " + water_state);
            Console.WriteLine("Error: Please check the container state Coffee: " + milk_state);
            Thread.Sleep(1000);
        }

        private static void Drink_ready()
        {
            Console.WriteLine("\nYour drink is ready.Attention hot!!");
            Thread.Sleep(1000);
            Console.Clear();
        }

        private static void Query_Menu()
        {
            Console.WriteLine("\nPlease choose from the menu:");
            Console.WriteLine("1 - coffee");
            Console.WriteLine("2 - espresso");
            Console.WriteLine("3 - cappuccino");
            Console.WriteLine("4 - milkcoffee");
            Console.WriteLine("5 - cleaning");
            Console.WriteLine("6 - exit");
        }

        private static void Greeting()
        {
            Console.WriteLine("\nWelcome!");
        }
    }
}

/*  to-do-list:
 *  1.Recipe list
 *  2.state as percentage bar
*/
