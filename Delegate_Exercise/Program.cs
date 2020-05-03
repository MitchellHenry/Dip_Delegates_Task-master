using System;
using System.Collections.Generic;
using FileParser;

namespace Delegate_Exercise
{
    class Delegate_Exercise
    {
        static void Main(string[] args)
        {
            DataParser _dp = new DataParser();
            CsvHandler _ch = new CsvHandler();
            Parser _Parser = new Parser(_dp.StripWhiteSpace);
            string _csvPath = Environment.GetEnvironmentVariable("HOME") + "/Users/Mitchell/Desktop/Dip_Delegates_Task-master/Dip_Delegates_Task-master/Data/data.csv";
            string _writeFile = Environment.GetEnvironmentVariable("HOME") + "/Users/Mitchell/Desktop/Dip_Delegates_Task-master/Dip_Delegates_Task-master/Data/processed_data.csv";
            string _writeFile2 = Environment.GetEnvironmentVariable("HOME") + "/Users/Mitchell/Desktop/Dip_Delegates_Task-master/Dip_Delegates_Task-master/Data/processed_data2.csv";
            
       Func<List<List<string>>, List<List<string>>> datacleaner = new Func<List<List<string>>, List<List<string>>>(_dp.StripWhiteSpace);
            datacleaner += _dp.StripQuotes;
            datacleaner += RemoveHashes;
            //This is the optional task implemented in the program.cs
            _ch.ProcessCsv(_csvPath, _writeFile,datacleaner);
            _Parser += _dp.StripQuotes;
            _Parser += RemoveHashes;
            _Parser += _dp.CapitalizeAll;
            _ch.ProcessCsvAndCapitalize(_csvPath, _writeFile2, _Parser);
            Console.ReadKey(true);
        }

        public static List<List<string>> RemoveHashes(List<List<string>> data) {
            foreach(var row in data) {
                for (var index = 0; index < row.Count; index++) {
                    if(row[index][0] == '#')
                        row[index] = row[index].Remove(0,1);
                }
            }
            return data;
            
        }
    }
}
