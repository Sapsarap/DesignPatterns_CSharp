using System;

namespace DesignPatterns.Creational.AbstractFactory
{

    /// <summary>
    /// Provide an interface for creating families of related or dependent objects without specifying their concrete classes
    /// </summary>

    class Program
    {
        public static void Main(string[] args)
        {
            //Abstract factory #1
            AbstractFactory factory1 = new ConcreteFactory1();
            Client client1 = new Client(factory1);
            client1.Run();

            //Abstract factory #2
            AbstractFactory factory2 = new ConcreteFactory2();
            Client client2 = new Client(factory2);
            client2.Run();


            //Wait for UserInput
            Console.ReadKey();
        }


        /// <summary>
        /// The 'AbstractFactory' abstract class
        /// </summary>
        abstract class AbstractFactory
        {
            public abstract AbstractProductA CreateProductA();
            public abstract AbstractProductB CreateProductB();
        }


        /// <summary>
        /// The 'ConcreteFactory1' class
        /// </summary>
        class ConcreteFactory1 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new PrductA1();
            }
            public override AbstractProductB CreateProductB()
            {
                return new ProductB1();
            }
        }


        /// <summary>
        /// The 'ConcreteFactory2' class
        /// </summary>
        class ConcreteFactory2 : AbstractFactory
        {
            public override AbstractProductA CreateProductA()
            {
                return new ProductA2();
            }
            public override AbstractProductB CreateProductB()
            {
                return new ProductB2();
            }
        }

        /// <summary>
        /// The 'AbstractProdcutA' abstract class
        /// </summary>
        abstract class AbstractProductA
        {

        }

        abstract class AbstractProductB
        {
            public abstract void Interact(AbstractProductA a);
        }
        /// <summary>
        /// The 'ProductA1' class
        /// </summary>
        class PrductA1 : AbstractProductA
        {

        }
        /// <summary>
        /// The 'ProductB1' class
        /// </summary>
        class ProductB1 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine(this.GetType().Name +
                    " interacts with " + a.GetType().Name);
            }
        }


        /// <summary>
        /// The 'ProductA2' class
        /// </summary>
        class ProductA2 : AbstractProductA
        {

        }

        /// <summary>
        /// The 'ProductB2' class
        /// </summary>
        class ProductB2 : AbstractProductB
        {
            public override void Interact(AbstractProductA a)
            {
                Console.WriteLine(this.GetType().Name +
                    " interacts with " + a.GetType().Name);
            }
        }

        /// <summary>
        /// The 'Client' class. Interaction environment for the prducts
        /// </summary>
        class Client
        {
            private AbstractProductA _abstractProductA;
            private AbstractProductB _abstractProductB;

            //Constructor
            public Client(AbstractFactory factory)
            {
                _abstractProductB = factory.CreateProductB();
                _abstractProductA = factory.CreateProductA();
            }

            public void Run()
            {
                _abstractProductB.Interact(_abstractProductA);
            }

        }         

    }
}
