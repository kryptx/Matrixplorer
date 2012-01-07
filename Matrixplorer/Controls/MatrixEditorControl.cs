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
    public partial class MatrixEditorControl : UserControl {

        private const string elementFormat = "G4";

        public Matrix? Matrix {
            get {

                try {
                    return new Matrix(
                        float.Parse(textBox11.Text), float.Parse(textBox12.Text), float.Parse(textBox13.Text), float.Parse(textBox14.Text),
                        float.Parse(textBox21.Text), float.Parse(textBox22.Text), float.Parse(textBox23.Text), float.Parse(textBox24.Text),
                        float.Parse(textBox31.Text), float.Parse(textBox32.Text), float.Parse(textBox33.Text), float.Parse(textBox34.Text),
                        float.Parse(textBox41.Text), float.Parse(textBox42.Text), float.Parse(textBox43.Text), float.Parse(textBox44.Text)
                    );
                } catch {
                    return null;
                }
            }

            set {
                if(value.HasValue)
                    SetValues((Matrix)value);
            }

        }

        public MatrixEditorControl() : base() {
            InitializeComponent();
        }

        public MatrixEditorControl(Matrix source, EventHandler<MatrixChangedEventArgs> changedEvent)
            : this() {
            changedEvent += MatrixChanged;
            SetValues(source);
        }

        private void SetValues(Matrix source) {

            textBox11.Text = Math.Round((double)source.M11, 3).ToString();
            textBox12.Text = Math.Round((double)source.M12, 3).ToString();
            textBox13.Text = Math.Round((double)source.M13, 3).ToString();
            textBox14.Text = Math.Round((double)source.M14, 3).ToString();

            textBox21.Text = Math.Round((double)source.M21, 3).ToString();
            textBox22.Text = Math.Round((double)source.M22, 3).ToString();
            textBox23.Text = Math.Round((double)source.M23, 3).ToString();
            textBox24.Text = Math.Round((double)source.M24, 3).ToString();

            textBox31.Text = Math.Round((double)source.M31, 3).ToString();
            textBox32.Text = Math.Round((double)source.M32, 3).ToString();
            textBox33.Text = Math.Round((double)source.M33, 3).ToString();
            textBox34.Text = Math.Round((double)source.M34, 3).ToString();

            textBox41.Text = Math.Round((double)source.M41, 3).ToString();
            textBox42.Text = Math.Round((double)source.M42, 3).ToString();
            textBox43.Text = Math.Round((double)source.M43, 3).ToString();
            textBox44.Text = Math.Round((double)source.M44, 3).ToString();

        }

        public void MatrixChanged(object sender, MatrixChangedEventArgs e) {
            SetValues(e.NewMatrix);
        }

    }

}
