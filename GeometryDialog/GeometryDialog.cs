﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeometryDialog
{
    public partial class GeometryDialog : Form
    {
        public GeometryDialog()
        {
            InitializeComponent();
        }

        private void NeuButton_Click(object sender, EventArgs e)
        {
            var dialog = new NewGeometryDialog();
            dialog.ShowDialog();
        }
    }
}
