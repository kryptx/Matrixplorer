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

        private Matrix matrix;
        public Matrix Matrix {
            get {
                return matrix;
            }
            set {
                matrix = value;
                SetLabels();
            }
        }

        public MatrixDisplay() : base() {
            InitializeComponent();
        }

        public MatrixDisplay(Matrix source, EventHandler<MatrixChangedEventArgs> changedEvent) : this() {
            changedEvent += MatrixChanged;
            Matrix = source;
        }

        private void SetLabels() {

            label11.Text = matrix.M11.ToString(elementFormat);
            label12.Text = matrix.M12.ToString(elementFormat);
            label13.Text = matrix.M13.ToString(elementFormat);
            label14.Text = matrix.M14.ToString(elementFormat);

            label21.Text = matrix.M21.ToString(elementFormat);
            label22.Text = matrix.M22.ToString(elementFormat);
            label23.Text = matrix.M23.ToString(elementFormat);
            label24.Text = matrix.M24.ToString(elementFormat);

            label31.Text = matrix.M31.ToString(elementFormat);
            label32.Text = matrix.M32.ToString(elementFormat);
            label33.Text = matrix.M33.ToString(elementFormat);
            label34.Text = matrix.M34.ToString(elementFormat);

            label41.Text = matrix.M41.ToString(elementFormat);
            label42.Text = matrix.M42.ToString(elementFormat);
            label43.Text = matrix.M43.ToString(elementFormat);
            label44.Text = matrix.M44.ToString(elementFormat);

        }

        public void MatrixChanged(object sender, MatrixChangedEventArgs e) {
            Matrix = e.NewMatrix;
        }

    }

}
