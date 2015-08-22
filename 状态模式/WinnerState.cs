using System;

namespace DesignPatterns.StatePattern
{
    internal class WinnerState : State
    {
        private GumballMachine gumballMachine;

        public WinnerState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }

        public void Dispense()
        {
            Console.WriteLine("You're a winner! you get two gumballs for your quarter");
            gumballMachine.releaseBall();
            if (gumballMachine.Count > 0)
            {
                gumballMachine.releaseBall();
                if (gumballMachine.Count > 0)
                    gumballMachine.CurrentState = gumballMachine.NoQuarterState;
                else
                {
                    Console.WriteLine("Oops,out of gumballs");
                    gumballMachine.CurrentState = gumballMachine.SoldOutState;
                }
            }
            else
            {
                gumballMachine.CurrentState = gumballMachine.SoldOutState;
            }
        }
        public void EjectQuarter()
        {
            Console.WriteLine("sorry,you already turned the crank");
        }

        public void InsertQuarter()
        {
            Console.WriteLine("Please wait,we're already giving you a gumball");
        }

        public void TurnCrank()
        {
            Console.WriteLine("Turning twice doesn't get you another gumball!");
        }
    }
}