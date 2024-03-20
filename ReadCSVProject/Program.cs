

// See https://aka.ms/new-console-template for more information
using ReadCSVProject;
using System.Data;

class GFG
{

    // Main Method 
    static public void Main(String[] args)
    {
        string pathToFile = """..\..\..\Book1.csv""";           // has to be like this so that it looks at the right levels.
        string pathToDB = """..\..\..\db.db3""";           // has to be like this so that it looks at the right levels.

        Console.WriteLine("Start Reading a csv to data table.");
               
        
        CSVAction csv = new CSVAction();
        DataTable csvData =  csv.readCSV(pathToFile);
        csv.printDataTable(csvData);

        csv.getColumns(csvData);

        // Create the table
        csvData.TableName = "csv";
        SQLiteAction sqlite = new SQLiteAction();
        sqlite.createTable(pathToDB, csvData);

        Console.WriteLine("CSV Read to Data Table!");
    }
}


