using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.StatePattern
{
    public class GumballMachine
    {
        private State soldOutState;
        private State noQuarterState;
        private State hasQuarterState;
        private State soldState;
        private State winnerState;

        private State currentState;
        int count = 0;

        public GumballMachine(int numberGumballs)
        {
            soldOutState = new SoldOutState(this);
            noQuarterState = new NoQuarterState(this);
            hasQuarterState = new HasQuarterState(this);
            soldState = new SoldState(this);
            winnerState = new WinnerState(this);
            this.count = numberGumballs;
            if (numberGumballs>0)
            {
                currentState = noQuarterState;
            }
        }
        public void InsertQuarter()
        {
            currentState.InsertQuarter();
        }
        public void EjectQuarter()
        {
            currentState.EjectQuarter();
        }
        public void TurnCrank()
        {
            currentState.TurnCrank();
            currentState.Dispense();
        }
        public State CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
            }
        }
        public void releaseBall()
        {
            System.Console.WriteLine("A gumball comes rolling out the slot....");
            if (count!=0)
            {
                count -= 1;
            }
        }

        public State NoQuarterState
        {
            get
            {
                return noQuarterState;
            }
        }
        public State SoldOutState
        {
            get
            {
                return soldOutState;
            }
        }
        public State SoldState
        {
            get
            {
                return soldState;
            }
        }
        public State HasQuarterState
        {
            get
            {
                return hasQuarterState;
            }
        }
        public State WinnerState
        {
            get
            {
                return winnerState;
            }
        }
        public int Count
        {
            get
            {
                return count;
            }
        }
        public override string ToString()
        {
            string typeName = this.GetType().Name;
            string returnStr = typeName + ".Count=" + count;
            returnStr += "\n" + typeName + ".CurrentState=" + CurrentState.GetType().Name;

            return returnStr;

        }
    }
}
