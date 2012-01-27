using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

    public class SimpleMatrix : IMatrix {

        protected Matrix matrix;
        public Matrix Matrix {
            get { return matrix; }
            protected set {
                matrix = value;
                if (Changed != null)
                    Changed(this, new MatrixChangedEventArgs { NewMatrix = value });
            }
        }


        public virtual void Set(Matrix matrix) {
            Matrix = matrix;
        }

        public virtual bool Invert() {

            if (Matrix.Determinant() == 0) 
                return false;

            Matrix = Matrix.Invert(Matrix);
            return true;

        }

        public event EventHandler<MatrixChangedEventArgs> Changed;

        public SimpleMatrix() {
            matrix = Matrix.Identity;
        }
    }

}
