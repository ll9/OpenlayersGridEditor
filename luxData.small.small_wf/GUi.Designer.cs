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
            this.GridHeaderMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddColumnToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteColumnToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridSplitContainer)).BeginInit();
            this.GridSplitContainer.Panel2.SuspendLayout();
            this.GridSplitContainer.SuspendLayout();
            this.GridHeaderMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
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
            // GridSplitContainer.Panel2
            // 
            this.GridSplitContainer.Panel2.Controls.Add(this.tabControl1);
            this.GridSplitContainer.Size = new System.Drawing.Size(800, 426);
            this.GridSplitContainer.SplitterDistance = 266;
            this.GridSplitContainer.TabIndex = 1;
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 156);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DataGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 130);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DataGrid
            // 
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGrid.Location = new System.Drawing.Point(3, 3);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.Size = new System.Drawing.Size(786, 124);
            this.DataGrid.TabIndex = 1;
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
            this.GridSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridSplitContainer)).EndInit();
            this.GridSplitContainer.ResumeLayout(false);
            this.GridHeaderMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.SplitContainer GridSplitContainer;
        private System.Windows.Forms.ContextMenuStrip GridHeaderMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddColumnToolStripItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteColumnToolStripItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

