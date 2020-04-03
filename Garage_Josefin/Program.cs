using System;

namespace Garage_Josefin
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "abc123";
            var type = input[0].GetType();
            
            string subString = input.Substring(3);
            Console.WriteLine(subString);

            UI ui = new UI();
            ui.Menu();

            

        }
    }
}
