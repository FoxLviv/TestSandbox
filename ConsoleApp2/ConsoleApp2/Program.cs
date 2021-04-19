using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var typesExercises = new TypesExercises();
            //int tmp = typesExercises.TestReferenceType();


            //typesExercises.Test2CloneReferenceType();
            //typesExercises.BoxingExample();

            //var listExercises = new ListExercises();
            //listExercises.Exercise();

            //var dictionaryExample = new DictionaryExample();
            //dictionaryExample.Example();

            //var stringExercise = new StringsExample();
            //stringExercise.Example();

            //var delAndEventExample = new DelegAndEventsExamples();
            //delAndEventExample.Example();

            var threads = new ThreadsExample();
            threads.Example();

            var linqExample = new LinqExample();
            linqExample.Example();

            var enumerable = new EnumerationExample();
            //enumerable.AllEx2();
            enumerable.Example();
            Console.ReadKey();
        }
    }
}
