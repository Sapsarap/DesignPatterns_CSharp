using System;
using static DesignPatterns.Structural.Proxy.Math;

namespace DesignPatterns.Structural.Proxy
{

    /// <summary>
    /// Provide a surrogate or placeholder for another object to control access to it.
    /// This structural code demonstrates the Proxy pattern which provides a representative object (proxy) that controls access to another similar object.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            Math test = new Math();
            test.Add(4, 2);



            Console.ReadLine();

            //Create math proxy from RealWorld.cs
            MathProxy proxy2 = new MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = " + proxy2.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy2.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy2.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + proxy2.Div(4, 2));

            //Input for the next Proxy result
            Console.ReadLine();

            //Create Proxy and request a service
            Proxy proxy = new Proxy();
            proxy.Request();

            //Wait for user
            Console.ReadKey();
        }

        /// <summary>
        /// The 'Subject' abstract class
        /// </summary>
        abstract class Subject
        {
            public abstract void Request();
        }

        class RealSubject : Subject
        {
            public override void Request()
            {
                Console.WriteLine("Called RealSubject.Request()");
            }
        }

        /// <summary>
        /// The 'RealSubjet' class
        /// </summary>
        class Proxy : Subject
        {
            private RealSubject _realSubject;

            public override void Request()
            {
               //Use 'lazy initilization'
               if(_realSubject == null)
                {
                    _realSubject = new RealSubject();
                }

                _realSubject.Request();
            }
        }


    }
}
