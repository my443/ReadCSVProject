using ReadCSVProject;
using System.Data;
using System.Reflection.Metadata;


class GFG
{

    // Main Method 
    static public void Main(String[] args)
    {
        string pathToFile = """..\..\..\Book1.csv""";           // has to be like this so that it looks at the right levels.
        string pathToDB = """..\..\..\db.db3""";           // has to be like this so that it looks at the right levels.

        Console.WriteLine("Start Reading a csv to data table.");
               
        // Read the csv
        CSVAction csv = new CSVAction();
        DataTable csvData =  csv.readCSV(pathToFile);
        csv.printDataTable(csvData);

        csv.getColumns(csvData);

        // Create the table
        csvData.TableName = "csv";
        SQLiteAction sqlite = new SQLiteAction();
        sqlite.createTable(pathToDB, csvData);

        // Insert the data
        var database = new SQLiteDBContext(pathToDB);
        var dataToInsert = new { Name = "abc" };
        //database.csv.InsertOnSubmit(dataToInsert);
        database.SaveChanges();

        Console.WriteLine("CSV Read to Data Table!");
    }
}


