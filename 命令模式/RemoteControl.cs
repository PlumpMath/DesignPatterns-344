using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class RemoteControl
    {
        private ICommand[] onCommands;
        private ICommand[] offCommands;
        private ICommand undoCommand;

        public RemoteControl()
        {
            onCommands = new ICommand[7];
            offCommands = new ICommand[7];
            NoCommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
            undoCommand = noCommand;
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot)
        {
            //由于使用NoCommand，所以无法判断onCommands[slot]!=null
            onCommands[slot].execute();
            undoCommand = onCommands[slot];
        }
        public void OffButtonWasPushed(int slot)
        {
            offCommands[slot].execute();
            undoCommand = offCommands[slot];
        }

        public void UndoButtonWasPushed()
        {
            undoCommand.undo();
        }
        public new string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("-----------------remote control----------------------");
            for (int i = 0; i < onCommands.Length; i++)
            {
                sb.AppendLine("[slot" + i + "] " + onCommands[i].GetType().ToString() + "   " +
                              offCommands[i].ToString().ToString());
            }
            return sb.ToString();
        }
    }
}
