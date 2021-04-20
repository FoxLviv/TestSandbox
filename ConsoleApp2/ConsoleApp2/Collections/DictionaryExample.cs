using System;
using System.Collections.Generic;

namespace LearnBasics.SandBox.Collections
{
    class DictionaryExample
    {
        public void Example()
        {
            var numberNames = new Dictionary<int, string>();
            numberNames.Add(1, "One"); //adding a key/value using the Add() method
            numberNames.Add(2, "Two");
            numberNames.Add(3, "Three");

            if (numberNames.ContainsKey(3))
            {
                numberNames.Remove(3);
            }

            string result;
            if (numberNames.TryGetValue(2, out result))
            {
                Console.WriteLine(result);
            }

            //numberNames.Clear();
            foreach (KeyValuePair<int, string> kvp in numberNames)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
            }

        }

    }
}
