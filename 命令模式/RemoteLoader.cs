using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class RemoteLoader
    {
        static void Main(string[] args)
        {
            RemoteControl control=new RemoteControl();
            Light light = new Light();
            LightOnCommand onCommand = new LightOnCommand(light);
            LightOffCommand offCommand=new LightOffCommand(light);
            control.SetCommand(0,onCommand,offCommand);
            System.Console.WriteLine(control.ToString());
            control.OnButtonWasPushed(0);
            control.UndoButtonWasPushed();
            //control.OffButtonWasPushed(0);
            System.Console.ReadKey();
        }
    }
}
