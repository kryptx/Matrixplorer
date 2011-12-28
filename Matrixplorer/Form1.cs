using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Matrixplorer.Controls;

namespace Matrixplorer {
    public partial class Form1 : Form {

        public Form1() {

            InitializeComponent();

            modelDisplayControl1.WorldChanged += worldMatrixDisplay.MatrixChanged;
            modelDisplayControl1.ViewChanged += viewMatrixDisplay.MatrixChanged;
            modelDisplayControl1.ProjectionChanged += projectionMatrixDisplay.MatrixChanged;

        }

        private void modelDisplayControl1_Resize(object sender, EventArgs e) {
            modelDisplayControl1.UpdateAspectRatio();
        }

    }

}
