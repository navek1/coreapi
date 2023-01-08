using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Asyncprogram
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stopWatch = new Stopwatch();
            //stopWatch.Start();
            //Console.WriteLine("Main start");

            //List<CreditCard> cards = CreditCard.GenerateCreditCards(100000);
            //ProcessCreditCards(cards);
            //Console.WriteLine("Main end");
            //stopWatch.Stop();
            //Console.WriteLine($"Main Thread Execution Time {stopWatch.ElapsedMilliseconds / 1000.0} Seconds");
            Console.WriteLine("Main start");
            SomeMethod1();
            SomeMethod2();
            Console.WriteLine("Main end");
            Console.ReadLine();

        }
        public static async void ProcessCreditCards(List<CreditCard> cards)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var tasks = new List<Task<string>>();
            await Task.Run(() =>
            {
                foreach (CreditCard card in cards)
                {
                    var result = ProcesCreditCard(card);
                    tasks.Add(result);
                }
            });
            
            await Task.WhenAll(tasks);
            stopWatch.Stop();
            Console.WriteLine($"Cards processed for {cards.Count}");
            Console.WriteLine($"Credit Cards Done in {stopWatch.ElapsedMilliseconds / 1000.0} Seconds");
        }
        public static async Task<string> ProcesCreditCard(CreditCard card)
        {
            await Task.Delay(1000);
            string message = $"Credit Card Number:{card.CardNumber} processed";
           // Console.WriteLine($"Credit Card Number:{card.CardNumber} processed");
            return message;
        }
        public static Task SomeMethod1()
        {
            //Do Some Task
            Console.WriteLine("SomeMethod1 Executing, It does not return anything");
            //When your method returning Task in synchronous, return Task.CompletedTask
            return Task.CompletedTask;
        }
        //Synchronous Method returning Task<T>
        public static Task<string> SomeMethod2()
        {
            string someValue = "";
            someValue = "SomeMethod2 Returing a String";
            Console.WriteLine("SomeMethod2 Executing, It return a string");
            //When your synchronous method returning Task<T>, use Task.FromResult
            return Task.FromResult(someValue);
        }
    }
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public static List<CreditCard> GenerateCreditCards(int number)
        {
            List<CreditCard> creditCards = new List<CreditCard>();
            for (int i = 0; i < number; i++)
            {
                CreditCard card = new CreditCard()
                {
                    CardNumber = "10000000" + i,
                    Name = "CreditCard-" + i
                };
                creditCards.Add(card);
            }
            return creditCards;
        }
    }
}
