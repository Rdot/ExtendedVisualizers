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
    public class RowStateInfo
    {
        #region Properties

        public int DataViewRowStateValue { get { return (int)this.DataViewRowState; } }
        public DataViewRowState DataViewRowState { get; set; }
        public DataRowState DataRowState { get; set; }
        public Color RowColor { get; set; }
        public int Count { get; set; }
        public bool Selected { get; set; }

        #endregion
    }
}
