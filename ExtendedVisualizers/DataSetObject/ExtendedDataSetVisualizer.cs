#region Code Header
/*
 * 
 * Created January 2013 By Rob McElroy
 */
#endregion

using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(ExtendedVisualizers.DataSetObject.ExtendedDataSetVisualizer),
    typeof(VisualizerObjectSource),
    Target = typeof(DataSet),
    Description = "Extended DataSet Visualizer")]
namespace ExtendedVisualizers.DataSetObject
{
    /// <summary>
    /// An updated DataSet visualizer that lets us see rows in various states.
    /// </summary>
    /// 
    /// TODO:  DataTable, DataRow.
    /// TODO:  Write a VisualizerObjectSource that allows us to make changes to the DataSet to be returned.
    public class ExtendedDataSetVisualizer : DialogDebuggerVisualizer
    {
        #region Methods 

        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            try
            {
                if (windowService == null)
                {
                    throw new ArgumentNullException("windowService");
                }
                if (objectProvider == null)
                {
                    throw new ArgumentNullException("objectProvider");
                }

                object data = (object)objectProvider.GetObject();
                System.Data.DataSet ds = data as System.Data.DataSet;
                if (ds == null)
                {
                    throw new ArgumentException("Only DataSets can be visualized with the ExtendedDataSetVisualizer");
                }

                using (ExtendedDataSetVisualizerWin win = new ExtendedDataSetVisualizerWin(ds))
                {
                    windowService.ShowDialog(win);
                }
            }
            catch (System.Exception rExc)
            {
                MessageBox.Show(rExc.Message);
            }
        }

        /// <summary>
        /// Tests the visualizer by hosting it outside of the debugger.
        /// </summary>
        /// <param name="objectToVisualize">The object to display in the visualizer.</param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(ExtendedDataSetVisualizer));
            visualizerHost.ShowVisualizer();
        }

        #endregion
    }
}
