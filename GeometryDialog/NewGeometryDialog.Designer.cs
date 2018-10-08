namespace GeometryDialog
{
    partial class NewGeometryDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FlowPane = new System.Windows.Forms.FlowLayoutPanel();
            this.AddButton = new System.Windows.Forms.Button();
            this.PropertiesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.FlowPane.SuspendLayout();
            this.PropertiesFlowPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // FlowPane
            // 
            this.FlowPane.AutoSize = true;
            this.FlowPane.Controls.Add(this.PropertiesFlowPanel);
            this.FlowPane.Controls.Add(this.AddButton);
            this.FlowPane.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.FlowPane.Location = new System.Drawing.Point(99, 25);
            this.FlowPane.Name = "FlowPane";
            this.FlowPane.Size = new System.Drawing.Size(116, 65);
            this.FlowPane.TabIndex = 2;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Location = new System.Drawing.Point(73, 35);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(36, 23);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "+";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PropertiesFlowPanel
            // 
            this.PropertiesFlowPanel.AutoSize = true;
            this.PropertiesFlowPanel.Controls.Add(this.textBox1);
            this.PropertiesFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.PropertiesFlowPanel.Location = new System.Drawing.Point(3, 3);
            this.PropertiesFlowPanel.Name = "PropertiesFlowPanel";
            this.PropertiesFlowPanel.Size = new System.Drawing.Size(106, 26);
            this.PropertiesFlowPanel.TabIndex = 6;
            // 
            // NewGeometryDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 302);
            this.Controls.Add(this.FlowPane);
            this.Controls.Add(this.label1);
            this.Name = "NewGeometryDialog";
            this.Text = "NewGeometryDialog";
            this.FlowPane.ResumeLayout(false);
            this.FlowPane.PerformLayout();
            this.PropertiesFlowPanel.ResumeLayout(false);
            this.PropertiesFlowPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel FlowPane;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.FlowLayoutPanel PropertiesFlowPanel;
    }
}