using System;

namespace DesignPatterns.StatePattern
{
    internal class SoldState : State
    {
        private GumballMachine gumballMachine;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
        }
        public void Dispense()
        {
            gumballMachine.releaseBall();
            if (gumballMachine.Count > 0)
            {
                gumballMachine.CurrentState = gumballMachine.NoQuarterState;
            }
            else
            {
                Console.WriteLine("Oops,out of gumballs");
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