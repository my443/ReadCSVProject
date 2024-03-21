using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace ReadCSVProject
{
    public class CSVAction
    {

        /// <summary>
        /// Reads a csv, returns a table.
        /// </summary>
        /// <returns></returns>
        public DataTable readCSV(string pathToFile)
        {

            DataTable dt = new DataTable();

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

            // Needed to rename the id column so that we can add it as a primary key later.
            if (dt.Columns.Contains("Id"))
            {
                dt.Columns["Id"].ColumnName = "imported_Id";
            }

            return dt;
        }

        public void printDataTable(DataTable dt)
        {
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
        }

        /// <summary>
        /// Returns the column names of the csv just imported.
        /// </summary>
        /// <param name="dt">DataTable from the csv.</param>
        /// <returns>An IEnumerable of the columns of the csv.</returns>
        public IEnumerable<DataColumn> getColumns(DataTable dt)
        {
            foreach(DataColumn column in dt.Columns)
            {
                Console.WriteLine($"{column.ColumnName}");
            }
            IEnumerable <DataColumn> columns = dt.Columns.Cast<DataColumn>();

            return columns;
        }

    }
}
