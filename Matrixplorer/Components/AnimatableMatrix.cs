using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {
    class AnimatableMatrix {

        private Matrix matrix;
        public Matrix Matrix {
            get { return matrix; }
            private set {
                matrix = value;
                Changed(this, new MatrixChangedEventArgs { NewMatrix = value });
            }
        }

        public void SetMatrix(Matrix matrix) {
            animation = null;
            Matrix = matrix;
        }

        private Animation<Matrix> animation;

        public event EventHandler<MatrixChangedEventArgs> Changed;

    }
}
