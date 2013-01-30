namespace ExtendedVisualizers.DataSetObject
{
    partial class DataTableViewer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvFilters = new System.Windows.Forms.DataGridView();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnCurrent = new System.Windows.Forms.Button();
            this.btnOriginal = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bsRowStateFilters = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsRowStateFilters)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFilters
            // 
            this.dgvFilters.AllowUserToAddRows = false;
            this.dgvFilters.AllowUserToDeleteRows = false;
            this.dgvFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilters.ColumnHeadersVisible = false;
            this.dgvFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFilters.Location = new System.Drawing.Point(0, 0);
            this.dgvFilters.Name = "dgvFilters";
            this.dgvFilters.ReadOnly = true;
            this.dgvFilters.RowHeadersVisible = false;
            this.dgvFilters.RowTemplate.Height = 24;
            this.dgvFilters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvFilters.Size = new System.Drawing.Size(631, 131);
            this.dgvFilters.TabIndex = 0;
            this.dgvFilters.VirtualMode = true;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(0, 0);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowTemplate.Height = 24;
            this.dgvMain.Size = new System.Drawing.Size(631, 251);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.TabStop = false;
            this.dgvMain.VirtualMode = true;
            // 
            // btnCurrent
            // 
            this.btnCurrent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCurrent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCurrent.Location = new System.Drawing.Point(17, 23);
            this.btnCurrent.Name = "btnCurrent";
            this.btnCurrent.Size = new System.Drawing.Size(76, 37);
            this.btnCurrent.TabIndex = 5;
            this.btnCurrent.Text = "&Current";
            this.btnCurrent.UseVisualStyleBackColor = false;
            // 
            // btnOriginal
            // 
            this.btnOriginal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOriginal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOriginal.Location = new System.Drawing.Point(17, 76);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.Size = new System.Drawing.Size(76, 36);
            this.btnOriginal.TabIndex = 4;
            this.btnOriginal.Text = "&Original";
            this.btnOriginal.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvFilters);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 131);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Controls.Add(this.btnCurrent);
            this.panel3.Controls.Add(this.btnOriginal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(520, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(111, 131);
            this.panel3.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(631, 251);
            this.panel1.TabIndex = 8;
            // 
            // DataTableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "DataTableViewer";
            this.Size = new System.Drawing.Size(631, 382);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsRowStateFilters)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFilters;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnCurrent;
        private System.Windows.Forms.Button btnOriginal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource bsRowStateFilters;
    }
}
