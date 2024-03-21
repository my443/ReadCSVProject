using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace ReadCSVProject
{
    public class SQLiteAction
    {
        public void createTable(string pathToDB, DataTable dataTable)
        {
            string connectionString = $"Data Source={pathToDB};Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create SQLite table command
                string createTableQuery = $"CREATE TABLE IF NOT EXISTS {dataTable.TableName} (" +
                                            GetColumnDefinitions(dataTable.Columns) +
                                          ");";

                Console.WriteLine(createTableQuery);

                // Execute the create table command
                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // Helper method to convert .NET data types to SQLite data types
        static string GetSQLiteType(Type type)
        {
            if (type == typeof(int))
                return "INTEGER";
            else if (type == typeof(string))
                return "TEXT";
            else if (type == typeof(double))
                return "REAL";
            else if (type == typeof(bool))
                return "BOOLEAN";
            else if (type == typeof(DateTime))
                return "DATETIME";
            else
                throw new ArgumentException($"Unsupported data type: {type}");
        }

        // Helper method to generate column definitions
        static string GetColumnDefinitions(DataColumnCollection columns)
        {
            //string primaryKeyDefinition = $"{primaryKeyColumn.ColumnName} {GetSQLiteType(primaryKeyColumn.DataType)} PRIMARY KEY";
            string query_string = string.Join(", ",
                columns.Cast<DataColumn>().Select(c => $"{c.ColumnName} {GetSQLiteType(c.DataType)}")
            );

            query_string = "Id INTEGER PRIMARY KEY, " + query_string;
            return query_string;
        }


    }
}
        
