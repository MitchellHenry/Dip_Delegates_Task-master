using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParser;

namespace Delegate_Exercise {
    
    
    public class CsvHandler {
        
        /// <summary>
        /// Reads a csv file (readfile) and applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        /// 

        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler) {
            FileHandler fh = new FileHandler();
            List<string> readData = fh.ReadFile(readFile);
            List<List<string>> ParsedData = fh.ParseData(readData, ',');
            List<List<string>> processedData = dataHandler.Invoke(ParsedData);
            fh.WriteFile(writeFile, ',', processedData);
        }
       public void ProcessCsvAndCapitalize(string readFile, string writeFile, Parser dataHandler)
        {
            FileHandler fh = new FileHandler();
            List<string> readData = fh.ReadFile(readFile);
            List<List<string>> ParsedData = fh.ParseData(readData, ',');
            List<List<string>> processedData = dataHandler.Invoke(ParsedData);
            fh.WriteFile(writeFile, ',', processedData);
        }
    }
}