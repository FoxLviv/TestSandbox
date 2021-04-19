using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class WorkWithFilesExample
    {
        public async void Example()
        {
            string path = Directory.GetCurrentDirectory() + "test.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(path);
                }

                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync("Update");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }


    }
}
