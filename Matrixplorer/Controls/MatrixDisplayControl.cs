using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Matrixplorer.Components;

namespace Matrixplorer.Controls {
    public partial class MatrixDisplayControl : UserControl {

        private const string elementFormat = "G2";

        private IMatrix matrix;
        public IMatrix Matrix {
            get { return matrix; }
            set {
                matrix = value;
                SetLabels();
                matrix.Changed += (sender, e) => { SetLabels(); };
            }
        }

        public Matrix MatrixValue { get { return Matrix.Matrix; } }


        public MatrixDisplayControl() {
            InitializeComponent();
            Matrix = new SimpleMatrix();
            Matrix.Set(Microsoft.Xna.Framework.Matrix.Identity);
        }


        private void SetLabels() {

            label11.Text = MatrixValue.M11.ToString(elementFormat);
            label12.Text = MatrixValue.M12.ToString(elementFormat);
            label13.Text = MatrixValue.M13.ToString(elementFormat);
            label14.Text = MatrixValue.M14.ToString(elementFormat);

            label21.Text = MatrixValue.M21.ToString(elementFormat);
            label22.Text = MatrixValue.M22.ToString(elementFormat);
            label23.Text = MatrixValue.M23.ToString(elementFormat);
            label24.Text = MatrixValue.M24.ToString(elementFormat);

            label31.Text = MatrixValue.M31.ToString(elementFormat);
            label32.Text = MatrixValue.M32.ToString(elementFormat);
            label33.Text = MatrixValue.M33.ToString(elementFormat);
            label34.Text = MatrixValue.M34.ToString(elementFormat);

            label41.Text = MatrixValue.M41.ToString(elementFormat);
            label42.Text = MatrixValue.M42.ToString(elementFormat);
            label43.Text = MatrixValue.M43.ToString(elementFormat);
            label44.Text = MatrixValue.M44.ToString(elementFormat);

        }

    }

}
