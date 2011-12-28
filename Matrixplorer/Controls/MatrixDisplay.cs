using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Controls {
    public partial class MatrixDisplay : UserControl {

        private const string elementFormat = "G2";

        public MatrixDisplay() : base() {
            InitializeComponent();
        }

        public MatrixDisplay(Matrix source, EventHandler<MatrixChangedEventArgs> changedEvent) : this() {
            changedEvent += MatrixChanged;
            SetValues(source);
        }

        public void SetValues(Matrix source) {

            label11.Text = source.M11.ToString(elementFormat);
            label12.Text = source.M12.ToString(elementFormat);
            label13.Text = source.M13.ToString(elementFormat);
            label14.Text = source.M14.ToString(elementFormat);

            label21.Text = source.M21.ToString(elementFormat);
            label22.Text = source.M22.ToString(elementFormat);
            label23.Text = source.M23.ToString(elementFormat);
            label24.Text = source.M24.ToString(elementFormat);

            label31.Text = source.M31.ToString(elementFormat);
            label32.Text = source.M32.ToString(elementFormat);
            label33.Text = source.M33.ToString(elementFormat);
            label34.Text = source.M34.ToString(elementFormat);

            label41.Text = source.M41.ToString(elementFormat);
            label42.Text = source.M42.ToString(elementFormat);
            label43.Text = source.M43.ToString(elementFormat);
            label44.Text = source.M44.ToString(elementFormat);

        }

        public void MatrixChanged(object sender, MatrixChangedEventArgs e) {
            SetValues(e.NewMatrix);
        }

    }

}
