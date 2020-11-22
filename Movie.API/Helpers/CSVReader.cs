using CsvHelper;
using System.Collections.Generic;
using System.IO;

namespace Movie.API.Helpers
{
    public class CSVReader<T> where T : class
    {
        public IEnumerable<T> GetData(string filePath)
        {
            TextReader reader = new StreamReader(filePath);
            var csvReader = new CsvReader(reader, new System.Globalization.CultureInfo("en-UK"));
            var records = csvReader.GetRecords<T>();

            return records;
        }
    }
}
