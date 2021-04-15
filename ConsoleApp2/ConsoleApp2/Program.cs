using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var stringExercise = new StringsExample();
            stringExercise.Example();

            Console.ReadKey();
        }
    }
}
