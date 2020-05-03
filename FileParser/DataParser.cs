using System.Collections.Generic;

namespace FileParser {
    public class DataParser {

        /// <summary>
        /// Strips any whitespace before and after a data value.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripWhiteSpace(List<List<string>> data) {
            var rowcount = 0;
            while (rowcount < data.Count)
            {
                var columncount = 0;
                while (columncount < data[rowcount].Count)
                {
                    data[rowcount][columncount] = data[rowcount][columncount].Replace(" ", "");
                    columncount++;
                }
                rowcount++;
            }

            return data; //-- return result here
        }

        /// <summary>
        /// Strips quotes from beginning and end of each data value
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public List<List<string>> StripQuotes(List<List<string>> data) {
            var rowcount = 0;
            while (rowcount < data.Count)
            {
                var columncount = 0;
                while (columncount < data[rowcount].Count)
                {
                    data[rowcount][columncount] = data[rowcount][columncount].Replace("\"", "");
                    columncount++;
                }
                rowcount++;
            }
            return data; //-- return result here
        }
        public  List<List<string>> CapitalizeAll(List<List<string>> data)
        {
            var rowcount = 0;
            while (rowcount < data.Count)
            {
                var columncount = 0;
                while (columncount < data[rowcount].Count)
                {
                    data[rowcount][columncount] = data[rowcount][columncount].ToUpper();
                    columncount++;
                }
                rowcount++;
            }
            return data;
        }

    }
}