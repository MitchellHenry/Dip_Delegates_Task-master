﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace FileParser {
    public delegate List<List<string>> Parser(List<List<string>> data);
    public class FileHandler {
       
        public FileHandler() { }
        /// <summary>
        /// Reads a file returning each line in a list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> ReadFile(string filePath) {
            int count = 0;
            List<string> lines = new List<string>();
            var st = File.ReadAllLines(filePath);
            while (count < st.Length)
            {
                lines.Add(st[count]);
                count++;
            }
            return lines; //-- return result here
        }

        
        /// <summary>
        /// Takes a list of a list of data.  Writes to file, using delimeter to seperate data.  Always overwrites.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimeter"></param>
        /// <param name="rows"></param>
        public void WriteFile(string filePath, char delimeter, List<List<string>> rows) {
            File.WriteAllText(filePath, "");
            var rowcount = 0;
            while (rowcount < rows.Count)
            {
                var columncount = 0;
                var DataLine = "";
                while (columncount < rows[rowcount].Count)
                {
                    if (columncount == rows[rowcount].Count - 1)
                    {
                        DataLine = DataLine + rows[rowcount][columncount];
                    }
                    else
                    {
                        DataLine = DataLine + rows[rowcount][columncount] + delimeter;
                    }
                    columncount++;
                }
                if(rowcount == 0)
                {
                    File.AppendAllText(filePath, DataLine);
                }
                else
                {
                    File.AppendAllText(filePath, Environment.NewLine);
                    File.AppendAllText(filePath, DataLine);
                }
                rowcount++;
            }
          
        }
        
        /// <summary>
        /// Takes a list of strings and seperates based on delimeter.  Returns list of list of strings seperated by delimeter.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public List<List<string>> ParseData(List<string> data, char delimiter) {
            List<List<string>> result = new List<List<string>>();
            var count = 0;
            while (count < data.Count)
            {
                List<string> row = data[count].Split(delimiter).ToList<string>();
                result.Add(row);
                count++;
            }
            return result; //-- return result here
        }
        
        /// <summary>
        /// Takes a list of strings and seperates on comma.  Returns list of list of strings seperated by comma.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> ParseCsv(List<string> data) {
            List<List<string>> result = new List<List<string>>();
            var count = 0;
            while (count < data.Count)
            {
                List<string> row = data[count].Split(',').ToList<string>();
                result.Add(row);
                count++;
            }
            return result; //-- return result here
        }
    }
}