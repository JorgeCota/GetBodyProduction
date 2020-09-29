using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class ResourcesDataTable
    {
       

        public static DataTable getNewRowDt_Month()
        {
            DataTable dt = new DataTable();
            DataColumn cLinea = new DataColumn("Linea", typeof(string));

            dt.Columns.Add(cLinea);

            int daysMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            string monthName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("MMM", CultureInfo.InvariantCulture);
            string NoDay = string.Empty;
            string DayName = string.Empty;

            for (int i = 1; i <= daysMonth; i++)
            {
                DayName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).ToString("ddd", CultureInfo.InvariantCulture);
                NoDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, i).ToString("dd", CultureInfo.InvariantCulture);

                DataColumn cDia = new DataColumn(NoDay + "-" + DayName, typeof(string));
                dt.Columns.Add(cDia);
            }

            return dt;
        }

        public static int GetIndex(DataTable dt, string col, string valueSearch)
        {
            int x = 0;
            DataRow row;
            try
            {
                row = dt.Select((col + "=\'" + (valueSearch + "\'")))[0];
                x = dt.Rows.IndexOf(row);
            }
            catch { }
            return x;
        }

        public static DataTable GetInformation_DataTable(DataTable dt, string col, string valueSearch)
        {
            IEnumerable<DataRow> query = from info in dt.AsEnumerable()
                                         where info.Field<string>(col) == valueSearch
                                         select info;
            return query.CopyToDataTable<DataRow>();
        }

        public static DataTable SortDataFloat(DataTable ds, string colOrdenar)
        {
            DataTable dtordenado = new DataTable();
            DataTable sortedTable = new DataTable();
            if (ds.Rows.Count > 0)
            {
                dtordenado = ds;
                sortedTable = dtordenado.AsEnumerable().OrderByDescending(r => r.Field<float>(colOrdenar)).CopyToDataTable();
            }


            return sortedTable;
        }

        public static void ConvertColumnType(this DataTable dt, string columnName, Type newType)
        {
            using (DataColumn dc = new DataColumn(columnName + "_new", newType))
            {
                // Add the new column which has the new type, and move it to the ordinal of the old column
                int ordinal = dt.Columns[columnName].Ordinal;
                dt.Columns.Add(dc);
                dc.SetOrdinal(ordinal);

                // Get and convert the values of the old column, and insert them into the new
                foreach (DataRow dr in dt.Rows)
                    dr[dc.ColumnName] = Convert.ChangeType(dr[columnName], newType);

                // Remove the old column
                dt.Columns.Remove(columnName);

                // Give the new column the old column's name
                dc.ColumnName = columnName;
            }
        }

        public static DataTable ConvertToAColumn(DataTable dt,string nameFirstColumn, string nameSecondColumn)
        {
            DataTable dtNew = new DataTable();
            dtNew.Columns.Add(nameFirstColumn, typeof(string));
            dtNew.Columns.Add(nameSecondColumn, typeof(float));
            DataRow newRow;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                newRow = dtNew.NewRow();

                if (i==0)
                {
                    newRow[nameFirstColumn] = dt.Columns[i].ColumnName;
                    newRow[nameSecondColumn] = float.Parse(dt.Rows[0][i].ToString()) / 60;
                }
                else
                {
                    newRow[nameFirstColumn] = dt.Columns[i].ColumnName;
                    newRow[nameSecondColumn] = (float.Parse(dt.Rows[0][i].ToString()) / 60)+ (float.Parse(dtNew.Rows[i-1][1].ToString()));
                }
                

                dtNew.Rows.Add(newRow);
            }

            return dtNew;
        }
    }
}
