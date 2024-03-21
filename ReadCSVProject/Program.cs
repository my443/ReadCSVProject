using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReadCSVProject;
using System.Data;
using System.Data.Entity;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Linq;


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

        //IQueryable<object> csvobjects = database.Database.SqlQuery<object>($"Select * from csv;");
        //var firstCsvObject = csvobjects.FirstOrDefault();

        //using (var context = database)
        //{
        //    // Get the entity type for a specific table (assuming table name is known)
        //    //IEntityType entityType = context.Model.GetEntityTypes().FirstOrDefault(); // Change this as per your requirement
        //    var entityType = context.Model.GetEntityTypes()
        //                    .FirstOrDefault(abc => context.Model.FindEntityType(abc).GetTableName() == "csv");

        //    if (entityType != null)
        //    {
        //        // Get the column names
        //        var columnNames = entityType.GetProperties().Select(p => p.GetColumnName()).ToList();

        //        // Display column names
        //        Console.WriteLine("Column Names:");
        //        foreach (var columnName in columnNames)
        //        {
        //            Console.WriteLine(columnName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Entity type not found.");
        //    }
        //}



        //IQueryable<object> csvobjects = database.Database.SqlQuery<object>($"Select * from csv;");


        ////https://stackoverflow.com/questions/4144778/get-properties-and-values-from-unknown-object
        ////https://stackoverflow.com/questions/23153815/why-cant-i-get-the-first-element-of-a-populated-iqueryable
        //var firstCsvObject = csvobjects.FirstOrDefault();
        //Type myType = firstCsvObject.GetType();
        //IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
        //foreach (PropertyInfo prop in props)
        //{
        //    object propValue = prop.GetValue(firstCsvObject, null);
        //    Console.WriteLine(propValue);
        //    // Do something with propValue
        //}
        ////database.csv.InsertOnSubmit(dataToInsert);
        database.SaveChanges();

        Console.WriteLine("CSV Read to Data Table!");
    }
}


