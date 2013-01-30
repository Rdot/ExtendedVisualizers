#region Code Header
/*
 * 
 * Created January 2013 By Rob McElroy
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExtendedVisualizers.DataSetObject
{
    /// <summary>
    /// Used to view the contents of a datatable and see rows in various states.
    /// </summary>
    /// 
    /// TODO:  Click on row to set Filter
    public partial class DataTableViewer : UserControl
    {

        #region Fields 

        DataTable dt = null;
        DataView dv = null;
        List<RowStateInfo> listRowStateInfo = null; 

        #endregion

        #region Events

        public event System.UnhandledExceptionEventHandler HasError;

        #endregion

        #region Constructors

        public DataTableViewer()
        {
            InitializeComponent();
        }

        public DataTableViewer(DataTable pDT) : this()
        {
            try
            {
                this.dgvFilters.CellClick += new DataGridViewCellEventHandler(dgvFilters_CellClick);
                this.dgvFilters.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvFilters_DataBindingComplete);
                this.dgvMain.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dgvMain_DataBindingComplete);
                this.btnCurrent.Click += new EventHandler(btnCurrent_Click);
                this.btnOriginal.Click += new EventHandler(btnOriginal_Click);

                this.listRowStateInfo = ExtendedDataSetVisualizerSingleton.Instance.ListRowStateInfo;

                DataView dvTemp = new DataView(pDT);
                this.listRowStateInfo.ForEach(item => 
                {
                    dvTemp.RowStateFilter = item.DataViewRowState;
                    item.Count = dvTemp.Count;
                });

                this.dgvFilters.AutoGenerateColumns = false;
                this.dgvFilters.AutoSize = true;

                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "DataViewRowStateValue";
                column.Name = "ColumnEnumValue";
                column.Visible = false;
                this.dgvFilters.Columns.Add(column);

                column = new DataGridViewCheckBoxColumn();
                column.DataPropertyName = "Selected";
                column.Name = "ColumnSelected";
                column.Width = 50;
                this.dgvFilters.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "DataViewRowState";
                column.Name = "ColumnDescription";
                column.Width = 250;
                this.dgvFilters.Columns.Add(column);

                column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = "Count";
                column.Name = "ColumnCount";
                column.Width = 50;
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dgvFilters.Columns.Add(column);

                this.bsRowStateFilters.DataSource = this.listRowStateInfo;
                this.dgvFilters.DataSource = this.bsRowStateFilters;

                dt = pDT;
                dv = new DataView(pDT);
                this.dgvMain.DataSource = this.dv;
                this.PerformFilter(DataViewRowState.CurrentRows);
            }
            catch (System.Exception rExc)
            {
                this.ShowError(rExc);
            }
        }

        void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                this.dgvMain.ClearSelection();
                this.ColorRows();
            }
            catch (System.Exception rExc)
            {
                this.ShowError(rExc);
            }
        }

        void dgvFilters_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgvr in this.dgvFilters.Rows)
                {
                    RowStateInfo rowInfo = dgvr.DataBoundItem as RowStateInfo;
                    if (rowInfo != null)
                    {
                        dgvr.DefaultCellStyle.BackColor = rowInfo.RowColor;
                    }
                }
                this.dgvFilters.ClearSelection();
            }
            catch (System.Exception rExc)
            {
                this.ShowError(rExc);
            }
        }


        #endregion

        #region Event Handlers

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            try
            {
                this.PerformFilter(DataViewRowState.OriginalRows);
            }
            catch (System.Exception rExc)
            {
                this.ShowError(rExc);
            }
        }

        private void btnCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                this.PerformFilter(DataViewRowState.CurrentRows);
            }
            catch (System.Exception rExc)
            {
                this.ShowError(rExc);
            }
        }

        void dgvFilters_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool bChecked = (bool)this.dgvFilters[1, e.RowIndex].FormattedValue;
                RowStateInfo currentRow = this.dgvFilters.Rows[e.RowIndex].DataBoundItem as RowStateInfo;
                currentRow.Selected = !bChecked;

                List<RowStateInfo> listSelected = this.listRowStateInfo.Where(item => item.Selected).ToList();
                DataViewRowState nDataViewRowStateFilter = DataViewRowState.None;
                listSelected.ForEach(item =>
                {
                    nDataViewRowStateFilter |= item.DataViewRowState;                                            
                });

                if ((nDataViewRowStateFilter & DataViewRowState.ModifiedCurrent) > 0 &&
                     (nDataViewRowStateFilter & DataViewRowState.ModifiedOriginal) > 0)
                {
                    this.ShowError(new Exception("You cannot see ModifiedCurrent and ModifiedOriginal rows a the same time."));
                    currentRow.Selected = !currentRow.Selected;
                }
                else
                {
                    this.dv.RowStateFilter = nDataViewRowStateFilter;
                    this.ColorRows();
                }
                for (int nIndex = 0; nIndex < this.dgvFilters.RowCount; nIndex++)
                {
                    this.dgvFilters.UpdateCellValue(1, nIndex);
                }
                this.dgvFilters.Update();
            }
            catch (System.Exception rExc)
            {
                this.ShowError(rExc);
            }
        }

        #endregion

        #region Methods

        private void PerformFilter(DataViewRowState pnDataViewRowState)
        {
            this.listRowStateInfo.ForEach(item => { item.Selected = false; });

            if (pnDataViewRowState == DataViewRowState.OriginalRows)
            {
                this.listRowStateInfo.ForEach(item =>
                {
                    if (item.DataViewRowState == DataViewRowState.Unchanged ||
                        item.DataViewRowState == DataViewRowState.ModifiedOriginal ||
                        item.DataViewRowState == DataViewRowState.Deleted)
                    { item.Selected = true; }
                });
                this.dv.RowStateFilter = DataViewRowState.OriginalRows;
            }
            else
            {
                this.listRowStateInfo.ForEach(item =>
                {
                    if (item.DataViewRowState == DataViewRowState.Unchanged ||
                        item.DataViewRowState == DataViewRowState.ModifiedCurrent ||
                        item.DataViewRowState == DataViewRowState.Added)
                    { item.Selected = true; }
                });
                this.dv.RowStateFilter = DataViewRowState.CurrentRows;
            }
            this.ColorRows();
            for (int nIndex = 0; nIndex < this.dgvFilters.RowCount; nIndex++)
            {
                this.dgvFilters.UpdateCellValue(1, nIndex);
            }
            this.dgvFilters.Update();
        }

        private void ShowError(System.Exception pExc)
        {
            System.UnhandledExceptionEventArgs args = new UnhandledExceptionEventArgs(pExc,false);
            
            if (this.HasError != null)
            {
                this.HasError(this,args);
            }
        }

        private void ColorRows()
        {
            foreach (DataGridViewRow dr in this.dgvMain.Rows)
            {
                DataRowView drv = (DataRowView)dr.DataBoundItem;

                if (drv != null)
                {
                    RowStateInfo rowInfo = this.listRowStateInfo.FirstOrDefault(ri => ri.DataRowState == drv.Row.RowState);
                    if (rowInfo != null)
                    {
                        this.dgvMain.Rows[dr.Index].DefaultCellStyle.BackColor = rowInfo.RowColor;
                    }
                }
            }
            this.dgvMain.Update();
        }

        #endregion 
    }
}
