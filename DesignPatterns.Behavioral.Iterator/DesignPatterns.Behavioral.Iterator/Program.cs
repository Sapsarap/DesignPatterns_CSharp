﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO-RealWorld

            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "Item A";
            a[1] = "Item B";
            a[2] = "Item C";
            a[3] = "Item D";

            // Create Iterator and provide aggregate
            Iterator i = a.CreateIterator();

            Console.WriteLine("Iterating over collection:");



        }
    }

    /// <summary>
    /// The 'Aggregate' abstract class
    /// </summary>
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();    
    }

    class ConcreteAggregate : Aggregate
    {
        private ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
        //Get Item Count
        public int Count
        {
            get
            {
                return _items.Count;
            }
        }

        //Indexer
        public object this[int index]
        {
            get
            {
                return _items[index];
            }
            set
            {
                _items.Insert(index, value);
            }
        }

    }

    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        //Consturctor 
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        //Get First Item
        public override object First()
        {
            return _aggregate[0];
        }

        //get the next item
        public override object Next()
        {
            object ret = null;
            if(_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }

        //Gets current iteration item
        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        //Gets whether iterations are complete
        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

    }


}
