using System;

namespace DesignPatterns.StatePattern
{
    internal class HasQuarterState : State
    {
        private GumballMachine gumballMachine;
        Random random = new Random(((int)DateTime.Now.Ticks & 0x0000FFFF));

        public HasQuarterState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("No gumball dispensed");
        }

        public void EjectQuarter()
        {
            Console.WriteLine("Quarter returned");
            gumballMachine.CurrentState = gumballMachine.NoQuarterState;
        }

        public void InsertQuarter()
        {
            Console.WriteLine("You can't insert another quarter");
        }

        public void TurnCrank()
        {
            Console.WriteLine("You turned...");
            int winner = random.Next(10);
            if (winner == 0 && gumballMachine.Count > 1)
            {
                gumballMachine.CurrentState = gumballMachine.WinnerState;
            }
            else
            {
                gumballMachine.CurrentState = gumballMachine.SoldState;
            }
        }
    }
}