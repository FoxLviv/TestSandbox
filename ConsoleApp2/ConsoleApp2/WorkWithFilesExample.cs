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
            var path = Path.Combine( Directory.GetCurrentDirectory(), "test.txt");
            try
            {
                using (var sw = new StreamWriter(path, false, Encoding.Default))
                {
                    await sw.WriteLineAsync(path);
                }

                using (var sw = new StreamWriter(path, true, Encoding.Default))
                {
                    await sw.WriteLineAsync("Update");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            using (var sr = new StreamReader(path, Encoding.Default))
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
