using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class StringsExample
    {
        public void Example()
        {
            var s1 = new String('a', 6);
            var s2 = new String(new char[] { 'w', 'o', 'r', 'l', 'd' });
            int index = s2.IndexOf('l');

            var sb1 = new StringBuilder("Heloo");
            sb1[3] = 'l';

            //Microsoft example
            string question = "hOW DOES mICROSOFT wORD DEAL WITH THE cAPS lOCK KEY?";
            System.Text.StringBuilder sb = new System.Text.StringBuilder(question);

            for (int j = 0; j < sb.Length; j++)
            {
                if (System.Char.IsLower(sb[j]) == true)
                {
                    sb[j] = System.Char.ToUpper(sb[j]);
                }                    
                else if (System.Char.IsUpper(sb[j]) == true)
                {
                    sb[j] = System.Char.ToLower(sb[j]);
                }                    
            }
            // Store the new string.
            string corrected = sb.ToString();
            System.Console.WriteLine(corrected);

            var joinedLine = MakeLine(0, 5, ",");

            var splitedLine = joinedLine.Split(',');
            
        }

        //Join Example
        string MakeLine(int initVal, int multVal, string sep)
        {
            string[] sArr = new string[10];

            for (int i = initVal; i < initVal + 10; i++)
            {
                sArr[i - initVal] = String.Format("{0,-3}", i * multVal);
            }
                

            return String.Join(sep, sArr);
        }
    }
}
