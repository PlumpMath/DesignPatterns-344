using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class Light
    {
        public void On()
        {
            System.Console.WriteLine("The Light is on!");
        }

        public void Off()
        {
            System.Console.Write("The Light is off!");
        }
    }
}
