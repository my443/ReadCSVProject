

// See https://aka.ms/new-console-template for more information
using ReadCSVProject;
using System.Data;

class GFG
{

    // Main Method 
    static public void Main(String[] args)
    {
        Console.WriteLine("Start Reading a csv to data table.");

        string pathToFile = """..\..\..\Book1.csv""";           // has to be like this so that it looks at the right levels.
        CSVAction csv = new CSVAction();
        DataTable csvData =  csv.readCSV(pathToFile);
        csv.printDataTable(csvData);


        Console.WriteLine("CSV Read to Data Table!");
    }
}


