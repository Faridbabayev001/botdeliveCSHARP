using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botdelive
{
    class Program
    {
        static void Main(string[] args)
        {
            string appId = "B1QMo76F7";
            string secret = "oPsNmyIvO6QgDYlgSyOjrCLO3OU-Wa4YNgfZ4UFf";
            string accessCode = "SJI8oXaFm";
            string userId = "xPdDzngBRwm8CGkSj4I9Abi-2gYNXz6uO0jOYq43";

            Botdelive bt = new Botdelive(appId,secret);
            //Console.WriteLine(bt.Verify(accessCode));
            //Console.WriteLine(bt.Auth(userId));
            Console.WriteLine(bt.Push(userId,"So Cool :) "));
            Console.ReadLine();
        }
    }
}
