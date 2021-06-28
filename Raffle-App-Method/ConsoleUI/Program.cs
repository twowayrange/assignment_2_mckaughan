using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static Dictionary<int, string> names = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random rdm = new Random();

        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userName = Console.ReadLine();
            return userName;
        }
        //Console.WriteLine

        static void GetUserInfo()
        {
            string otherGuest = "";
            do
            {
                string name = GetUserInput("Please enter your name ");
                while (String.IsNullOrEmpty(name))
                {
                     name = GetUserInput("Please enter your name ");
                }
                raffleNumber = GenerateRandomnNumber(min, max);
                while (names.ContainsKey(raffleNumber))
                {
                    raffleNumber = GenerateRandomnNumber(min, max);
                }
                AddGuestsInRaffle(raffleNumber, name);
                otherGuest = GetUserInput("do you want to add another name?").ToLower();

            }
            while (otherGuest == "yes");
        }


        static int GenerateRandomnNumber(int num1, int num2)

        {
            //for (_rdm = 0; _rdm <= 4; _rdm++)

            //_rdm(min, max)

            int num = rdm.Next(num1, num2);

            return num;
        }

        static void AddGuestsInRaffle(int raffleNumber, string name)
        {
            names.Add(raffleNumber, name);
        }

        static void PrintGuestsName()
        {
            foreach (KeyValuePair<int, string> name in names)
            {
                Console.WriteLine($"{name.Key}, {name.Value}");
            }
           
        }


        static int GetRaffleNumber(Dictionary<int, string> winner)
        {
            
           List<int> winnerSelection = winner.Keys.ToList();
           
           int chosenOne = rdm.Next(winnerSelection.Count);

            return winnerSelection[chosenOne];
            
        }

        static void PrintWinner()
        {
            string winnerName = names[GetRaffleNumber(names)];
            int winnerNumber = GetRaffleNumber(names);
            Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}");
        }

        //Start writing your code here






        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            PrintWinner();

            Console.ReadLine();
        }
    }
}
