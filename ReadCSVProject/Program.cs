// See https://aka.ms/new-console-template for more information
using CsvHelper;
using System;
using System.Data;
using System.Globalization;

class GFG
{

    // Main Method 
    static public void Main(String[] args)
    {
        Console.WriteLine("Start Reading a csv to data table.");


        DataTable dt = new DataTable();

        
        string pathToFile = """..\..\..\Book1.csv""";           // has to be like this so that it looks at the right levels. 

        // CSV DataReader
        // https://joshclose.github.io/CsvHelper/examples/csvdatareader/
        using (var reader = new StreamReader(pathToFile))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<dynamic>();
            using (var dr = new CsvDataReader(csv))
            {
                
                dt.Load(dr);
            }
        }

        // Print contents of DataTable.
        foreach (DataRow dataRow in dt.Rows)
        {
            string row = "";
            foreach (var item in dataRow.ItemArray)
            {
                row = row + item + " - ";
                
            }
            Console.WriteLine(row);
        }

        Console.WriteLine("CSV Read to Data Table!");
    }
}


