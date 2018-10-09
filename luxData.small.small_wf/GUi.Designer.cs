namespace luxData.small.small_wf
{
    partial class GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GridSplitContainer = new System.Windows.Forms.SplitContainer();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.GridHeaderMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddColumnToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteColumnToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.FillButton = new System.Windows.Forms.Button();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSplitContainer)).BeginInit();
            this.GridSplitContainer.Panel1.SuspendLayout();
            this.GridSplitContainer.Panel2.SuspendLayout();
            this.GridSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.GridHeaderMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // GridSplitContainer
            // 
            this.GridSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.GridSplitContainer.Name = "GridSplitContainer";
            this.GridSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // GridSplitContainer.Panel1
            // 
            this.GridSplitContainer.Panel1.Controls.Add(this.AddRowButton);
            this.GridSplitContainer.Panel1.Controls.Add(this.FillButton);
            this.GridSplitContainer.Panel1.Controls.Add(this.UpdateButton);
            // 
            // GridSplitContainer.Panel2
            // 
            this.GridSplitContainer.Panel2.Controls.Add(this.DataGrid);
            this.GridSplitContainer.Size = new System.Drawing.Size(800, 426);
            this.GridSplitContainer.SplitterDistance = 266;
            this.GridSplitContainer.TabIndex = 1;
            // 
            // DataGrid
            // 
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.Location = new System.Drawing.Point(0, 0);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(800, 156);
            this.DataGrid.TabIndex = 0;
            this.DataGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGrid_ColumnHeaderMouseClick);
            this.DataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGrid_KeyDown);
            // 
            // GridHeaderMenuStrip
            // 
            this.GridHeaderMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddColumnToolStripItem,
            this.DeleteColumnToolStripItem});
            this.GridHeaderMenuStrip.Name = "GridHeaderMenuStrip";
            this.GridHeaderMenuStrip.Size = new System.Drawing.Size(157, 48);
            // 
            // AddColumnToolStripItem
            // 
            this.AddColumnToolStripItem.Name = "AddColumnToolStripItem";
            this.AddColumnToolStripItem.Size = new System.Drawing.Size(156, 22);
            this.AddColumnToolStripItem.Text = "Spalte einfügen";
            this.AddColumnToolStripItem.Click += new System.EventHandler(this.AddColumnToolStripItem_Click);
            // 
            // DeleteColumnToolStripItem
            // 
            this.DeleteColumnToolStripItem.Name = "DeleteColumnToolStripItem";
            this.DeleteColumnToolStripItem.Size = new System.Drawing.Size(156, 22);
            this.DeleteColumnToolStripItem.Text = "Spalte Löschen";
            this.DeleteColumnToolStripItem.Click += new System.EventHandler(this.DeleteColumnToolStripItem_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(645, 108);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateButton.TabIndex = 0;
            this.UpdateButton.Text = "Update Db";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // FillButton
            // 
            this.FillButton.Location = new System.Drawing.Point(645, 156);
            this.FillButton.Name = "FillButton";
            this.FillButton.Size = new System.Drawing.Size(75, 23);
            this.FillButton.TabIndex = 1;
            this.FillButton.Text = "Fill DataTable";
            this.FillButton.UseVisualStyleBackColor = true;
            this.FillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // AddRowButton
            // 
            this.AddRowButton.Location = new System.Drawing.Point(645, 201);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(75, 23);
            this.AddRowButton.TabIndex = 2;
            this.AddRowButton.Text = "Add Row";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GridSplitContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GridSplitContainer.Panel1.ResumeLayout(false);
            this.GridSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridSplitContainer)).EndInit();
            this.GridSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.GridHeaderMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.SplitContainer GridSplitContainer;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.ContextMenuStrip GridHeaderMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddColumnToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteColumnToolStripItem;
        private System.Windows.Forms.Button FillButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button AddRowButton;
    }
}

