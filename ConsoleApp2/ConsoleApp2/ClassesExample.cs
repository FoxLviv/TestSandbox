using System;

namespace ConsoleApp2
{
    class ClassesExample
    {
        Plant tree = new Tree("IDK","Cherry");
    }
    //https://www.geeksforgeeks.org/difference-between-abstract-class-and-interface-in-c-sharp/

    public interface ILeaf
    {
        void Leaf();
    }

    public interface IBark
    {
        void Bark();
    }

    public abstract class Plant
    {
        public static int count;
        public string typeOfRoot;
        public Plant(string typeOfRoot)
        {
            this.typeOfRoot = typeOfRoot;
        }
        protected abstract void Root();
    }

    public class Tree : Plant, ILeaf, IBark
    {
        public string Name { get; private set; }
        public Tree(string typeOfRoot, string Name) : base(typeOfRoot)
        {
            this.Name = Name;
        }

        public void Bark()
        {
            throw new NotImplementedException();
        }

        public void Leaf()
        {
            throw new NotImplementedException();
        }

        protected override void Root()
        {
            throw new NotImplementedException();
        }
    }
}
