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
    public partial class MatrixEditor : UserControl {

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
                if(Matrix.HasValue)
                    SetValues((Matrix)value);
            }

        }

        public MatrixEditor() : base() {
            InitializeComponent();
        }

        public MatrixEditor(Matrix source, EventHandler<MatrixChangedEventArgs> changedEvent)
            : this() {
            changedEvent += MatrixChanged;
            SetValues(source);
        }

        public void SetValues(Matrix source) {

            textBox11.Text = source.M11.ToString(elementFormat);
            textBox12.Text = source.M12.ToString(elementFormat);
            textBox13.Text = source.M13.ToString(elementFormat);
            textBox14.Text = source.M14.ToString(elementFormat);

            textBox21.Text = source.M21.ToString(elementFormat);
            textBox22.Text = source.M22.ToString(elementFormat);
            textBox23.Text = source.M23.ToString(elementFormat);
            textBox24.Text = source.M24.ToString(elementFormat);

            textBox31.Text = source.M31.ToString(elementFormat);
            textBox32.Text = source.M32.ToString(elementFormat);
            textBox33.Text = source.M33.ToString(elementFormat);
            textBox34.Text = source.M34.ToString(elementFormat);

            textBox41.Text = source.M41.ToString(elementFormat);
            textBox42.Text = source.M42.ToString(elementFormat);
            textBox43.Text = source.M43.ToString(elementFormat);
            textBox44.Text = source.M44.ToString(elementFormat);

        }

        public void MatrixChanged(object sender, MatrixChangedEventArgs e) {
            SetValues(e.NewMatrix);
        }

    }

}
