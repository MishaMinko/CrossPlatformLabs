using System;
using CrossPlatformLabs.Labs;

namespace CrossPlatformLabs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("If you want to leave enter lab number 0");
                Console.Write("Enter lab number: ");
                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1: new Lab1().Start(); break;

                    default: return;
                }
            }
        }
    }
}
