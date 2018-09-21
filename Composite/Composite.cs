using System;
using System.Collections.Generic;

namespace GangOfFour.Structural
{
    //Composite Pattern Example
    public abstract class ComponentAbstraction
    {
        public string name {get; private set;}

        public ComponentAbstraction(string name)
        {
            this.name = name;
        }
        public virtual void FetchChildren(int depth){}
        public virtual void Add(ComponentAbstraction c){}
        public virtual void Remove(ComponentAbstraction c){}
    }

    public class Leaf : ComponentAbstraction
    {
        public Leaf(string name)
          : base(name) 
        {
        }

        public override void Add(ComponentAbstraction c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }

        public override void Remove(ComponentAbstraction c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }

        public override void FetchChildren(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }

    public class Composite : ComponentAbstraction
    {
        private List<ComponentAbstraction> _children = new List<ComponentAbstraction>();

        public Composite(string name) 
          : base(name)
        {
        }
        
        public override void FetchChildren( int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            foreach (ComponentAbstraction c in _children)
            {
                c.FetchChildren(depth + 2);
            }
        }
        public override void Add(ComponentAbstraction c)
        {
            _children.Add(c);
        }
        public override void Remove(ComponentAbstraction c)
        {
            _children.Remove(c);
        }
    }

    class CompositePattern
    {
        static void Main()
        {

            //Top of the tree
            Composite root = new Composite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            //Branch
            Composite comp = new Composite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);

            Leaf leaf2 = new Leaf("Leaf Z");
            root.Add(leaf2);

            root.Remove(leaf);

            //Recursively display tree
            root.FetchChildren(1);

            Console.ReadKey();
        }
    }
}
