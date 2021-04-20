using System;
using System.Text;

namespace LearnBasics.SandBox.BasicTypes
{
    class StringsExample
    {
        public void Example()
        {
            var s1 = new string('a', 6);
            var s2 = new string(new char[] { 'w', 'o', 'r', 'l', 'd', 'l', 'l' });
            int index = s2.IndexOf('l');
            var multipleIndexes = s2.IndexOf('l', index + 1);
            Console.WriteLine(multipleIndexes);
            var sb1 = new StringBuilder("Heloo");
            s1 += 'l';

            //Microsoft example
            string question = "hOW DOES mICROSOFT wORD DEAL WITH THE cAPS lOCK KEY?";
            var sb = new StringBuilder(question);

            for (int j = 0; j < sb.Length; j++)
            {
                if (char.IsLower(sb[j]) == true)
                {
                    sb[j] = char.ToUpper(sb[j]);
                }
                else if (char.IsUpper(sb[j]) == true)
                {
                    sb[j] = char.ToLower(sb[j]);
                }
            }
            // Store the new string.
            var corrected = sb.ToString();
            Console.WriteLine(corrected);

            string joinedLine = MakeLine(0, 5, ",");

            string[] splitedLine = joinedLine.Split(',');
            splitedLine[2] = string.Empty;
            foreach (string str in splitedLine)
            {
                Console.WriteLine(str);
            }

            joinedLine = string.Join(",", splitedLine);

            Console.WriteLine(joinedLine);
        }

        //Join Example
        string MakeLine(int initVal, int multVal, string sep)
        {
            var sArr = new string[10];

            for (int i = initVal; i < initVal + 10; i++)
            {
                sArr[i - initVal] = string.Format("{0,-3}", i * multVal);
            }


            return string.Join(sep, sArr);
        }
    }
}
