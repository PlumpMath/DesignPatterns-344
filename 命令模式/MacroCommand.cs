using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CommandPattern
{
    public class MacroCommand : ICommand
    {
        private ICommand[] commands;

        public MacroCommand(ICommand[] commmands)
        {
            this.commands = commmands;
        }
        public void execute()
        {
            foreach (ICommand command in commands)
            {
                command.execute();
            }
        }

        public void undo()
        {
            foreach (ICommand command in commands)
            {
                command.undo();
            }
        }
    }
}
