#region Code Header
/*
 * 
 * Created January 2013 By Rob McElroy
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtendedVisualizers.DataSetObject
{
    /// <summary>
    /// Displays a DataSet letting users see rows in various states.  Helps troubleshooting
    /// issues with DataSets.
    /// </summary>
    /// 
    /// <remarks>
    /// This class contains a tab control,  for each table that exists in the
    /// DataSet we are visualizing a new tap page is created.
    /// This new tab contains a new instance of the <see cref="DataTableViewer"/> class.
    /// </remarks>
    public partial class ExtendedDataSetVisualizerWin : Form
    {
        #region Fields

        #endregion

        #region Constructors

        public ExtendedDataSetVisualizerWin()
        {
            InitializeComponent();
        }

        public ExtendedDataSetVisualizerWin(DataSet pDS)
            : this()
        {
            ExtendedDataSetVisualizerSingleton.Instance.LoadedDataSet = pDS;
            this.Init();
        }
  
        #endregion

        #region Methods 

        private void ShowException(System.Exception pExc)
        {
            toolStripStatusLabel.Text = pExc.Message;
        }

        private void Init()
        {
            try
            {
                if (ExtendedDataSetVisualizerSingleton.Instance.LoadedDataSet.Tables.Count == 0)
                {
                    this.ShowException(new Exception("No Tables exist in the dataset."));
                    return;
                }

                List<RowStateInfo> list = ExtendedDataSetVisualizerSingleton.Instance.ListRowStateInfo;
                foreach (DataTable dt in ExtendedDataSetVisualizerSingleton.Instance.LoadedDataSet.Tables)
                {
                    int nTotalRows = 0;

                    list.ForEach(item =>
                    {
                        DataView dvTemp = new DataView(dt);
                        dvTemp.RowStateFilter = item.DataViewRowState;
                        nTotalRows += dvTemp.Count;
                    });

                    string sText = dt.TableName + " (" + nTotalRows.ToString() + ")"; 
                    TabPage tp = new TabPage(sText);
                    tp.Text = sText;
                    tp.ToolTipText = sText;
                    this.tcMain.TabPages.Add(tp);

                    DataTableViewer dtv = new DataTableViewer(dt);
                    dtv.HasError += new UnhandledExceptionEventHandler(dtv_HasError);
                    tp.Controls.Add(dtv);
                    dtv.Dock = DockStyle.Fill;
                }
            }
            catch (System.Exception rExc)
            {
                this.ShowException(rExc);
            }
        }

        void dtv_HasError(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                this.ShowException(e.ExceptionObject as Exception);
            }
            catch (System.Exception rExc)
            {
                this.ShowException(rExc);
            }
        }


        #endregion
    }
}
