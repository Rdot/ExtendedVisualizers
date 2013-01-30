#region Code Header
/*
 * 
 * Created January 2013 By Rob McElroy
 */
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing;

namespace ExtendedVisualizers.DataSetObject
{
    /// <summary>
    /// Credit for pattern goes here: http://csharpindepth.com/Articles/General/Singleton.aspx
    /// </summary>
    public class ExtendedDataSetVisualizerSingleton
    {
        #region Methods

        private static readonly Lazy<ExtendedDataSetVisualizerSingleton> lazy = new Lazy<ExtendedDataSetVisualizerSingleton>(() => new ExtendedDataSetVisualizerSingleton());

        public static ExtendedDataSetVisualizerSingleton Instance { get { return lazy.Value; } }

        #endregion

        #region Constructors

        private ExtendedDataSetVisualizerSingleton()
        {
        }

        #endregion

        #region Properties

        public DataSet LoadedDataSet {get; set;}

        /// <summary>
        /// We always return a new list because the consumers of this list need it to be unique.
        /// </summary>
        public List<RowStateInfo> ListRowStateInfo 
        {
            get
            {
                List<RowStateInfo> listRowStateInfo = new List<RowStateInfo>();
                listRowStateInfo.Add(new RowStateInfo() { DataViewRowState = DataViewRowState.Added, DataRowState = System.Data.DataRowState.Added, RowColor = Color.LightGreen });
                listRowStateInfo.Add(new RowStateInfo() { DataViewRowState = DataViewRowState.Unchanged, DataRowState = System.Data.DataRowState.Unchanged, RowColor = Color.White });
                listRowStateInfo.Add(new RowStateInfo() { DataViewRowState = DataViewRowState.Deleted, DataRowState = System.Data.DataRowState.Deleted, RowColor = Color.Red });
                listRowStateInfo.Add(new RowStateInfo() { DataViewRowState = DataViewRowState.ModifiedCurrent, DataRowState = System.Data.DataRowState.Modified, RowColor = Color.Yellow });
                listRowStateInfo.Add(new RowStateInfo() { DataViewRowState = DataViewRowState.ModifiedOriginal, DataRowState = System.Data.DataRowState.Modified, RowColor = Color.Yellow });
                return listRowStateInfo;
            }
        }

        #endregion

    }
}
