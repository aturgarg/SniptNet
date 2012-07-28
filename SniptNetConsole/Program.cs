using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SniptNetLib;

namespace SniptNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler handler = new Handler();
            handler.AuthenticateUser();

            Console.ReadLine();
        }
    }
}
