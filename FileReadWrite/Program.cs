using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace FileReadWrite
{

    class Program
    {
        static string path = "table.txt";
        static FileInfo fi1 = new FileInfo(path);

        public static int CountLinesLINQ(FileInfo file)
            => File.ReadLines(file.FullName).Count();

        static void Main()
        {

            Console.OutputEncoding = Encoding.UTF8;
            int numberOfLines = CountLinesLINQ(fi1);

            int indexOfTieNumber = numberOfLines == 9 ? 4 : 5;

            var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            var sr = new StreamReader(fs, Encoding.Default);

            string[][] s = { };

            Array.Resize(ref s, numberOfLines);

            string line;
            char[] separators = new char[] { ' ', ':' };

            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                var parts = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                s[i] = parts;
                i++;
            }

            for(i = 0; i < numberOfLines; i++)
            {
                for(int j = 0; j < s[i].Length; j++)
                {
                    Console.Write(s[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }


            List<int> ties = new List<int>();

            for(i = 0; i < numberOfLines; i++)
            {
                int tie = int.Parse(s[i][indexOfTieNumber]);
                ties.Add(tie);
            }
            int maxValue = ties.Max();
            int maxIndex = ties.IndexOf(maxValue) + 1;
            Console.WriteLine($"Найбільше нічий має команда:{maxIndex}, кількість:{maxValue}");
        }
    }
}