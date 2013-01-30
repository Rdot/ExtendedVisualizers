using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ExtendedVisualizers.DataSetObject;
using System.Data;

namespace ExtendedVisualizers.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1";


            DataSet ds = new DataSet();
            AddTable(ds, "Associate");
            ds.AcceptChanges();

            DataRow dr = ds.Tables["Associate"].NewRow();
            dr["Col1"] = "Rob";
            dr["Col2"] = "Mc";
            ds.Tables["Associate"].Rows.Add(dr);

            AddTable(ds, "Child");
            ds.Tables["Associate"].Rows[0].Delete();

            ds.Tables["Child"].Rows[0].Delete();

            ExtendedDataSetVisualizer.TestShowVisualizer(ds);
        }

        static void AddTable(DataSet pDS, string psTableName)
        {
            DataTable dt = new DataTable(psTableName);
            dt.Columns.Add("Col1", typeof(string));
            dt.Columns.Add("Col2", typeof(string));

            dt.Rows.Add(new object[] {"abc", "def" + psTableName});
            dt.Rows.Add(new object[] {"ghi", "jkl" + psTableName});

            pDS.Tables.Add(dt);
        }
    }
}
