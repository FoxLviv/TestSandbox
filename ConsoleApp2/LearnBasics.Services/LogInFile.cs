using LearnBasics.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBasics.Services
{
    public class LogInFile : ILogger
    {
        public void Print(string data)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");
            using (var sw = new StreamWriter(path, true, Encoding.Default))
            {
                sw.WriteLine(data);
            }
        }
    }
}
