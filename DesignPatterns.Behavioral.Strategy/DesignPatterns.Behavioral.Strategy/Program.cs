using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    /// <summary>
    /// Define a family of algorithms, encapsulate each one, and make them interchangeable. Strategy lets the algorithm vary independently from clients that use it.
    /// 
    /// This structural code demonstrates the Strategy pattern which encapsulates functionality in the form of an object. 
    /// This allows clients to dynamically change algorithmic strategies.
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {


            // Two contexts following different strategies

            SortedList studentRecords = new SortedList();

            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Vivek");
            studentRecords.Add("Anna");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ShellSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            // Wait for user

            Console.ReadKey();



            Console.ReadLine();


            Context context;

            //Three context following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();

            //Wait for user
            Console.ReadKey();
        }

        /// <summary>
        /// A 'Strategy' abstract class
        /// </summary>
        abstract class Strategy
        {
            public abstract void AlgorithmInterface();
        }
        
        /// <summary>
        /// A 'ConcreteStrategy' class 
        /// </summary>
        class ConcreteStrategyA : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
            }
        }


        /// <summary>
        /// A 'ConcreteStrategy' class 
        /// </summary>
        class ConcreteStrategyB : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
            }
        }


        /// <summary>
        /// A 'ConcreteStrategy' class 
        /// </summary>
        class ConcreteStrategyC : Strategy
        {
            public override void AlgorithmInterface()
            {
                Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
            }
        }

        class Context
        {
            private Strategy _stategy;

            //Constructor
            public Context(Strategy strategy)
            {
                this._stategy = strategy;
            }

            public void ContextInterface()
            {
                _stategy.AlgorithmInterface();
            }
        }
    }
}
