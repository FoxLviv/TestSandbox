using LearnBasics.Sandbox.Dependency_injection;
using LearnBasics.SandBox.BasicTypes;
using LearnBasics.SandBox.Collections;
using LearnBasics.SandBox.DelegatesAndEvents;
using LearnBasics.SandBox.Threads;
using LearnBasics.SandBox.WorkWithFiles;
using System;

namespace LearnBasics.SandBox
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

            //var threads = new ThreadsExample();
            //threads.Example();

            //var linqExample = new LinqExample();
            //linqExample.Example();

            //var xmlExam = new XMLExample();
            //xmlExam.Example();

            //var jsonExample = new JSONExample();
            //jsonExample.Example();

            //var file = new WorkWithFilesExample();
            //file.Example();

            var DIExample = new DIConfiguration();
            DIExample.Main();

            Console.ReadKey();
        }
    }
}
