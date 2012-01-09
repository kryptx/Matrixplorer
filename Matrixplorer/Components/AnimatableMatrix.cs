using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {
    public class AnimatableMatrix : IMatrix {

        private Matrix matrix;
        public Matrix Matrix {
            get { return matrix; }
            private set {
                matrix = value;
                if(Changed != null)
                    Changed(this, new MatrixChangedEventArgs { NewMatrix = value });
            }
        }

        private Animation<Matrix> animation;

        public event EventHandler<MatrixChangedEventArgs> Changed;

        public AnimatableMatrix(Matrix mat) { matrix = mat; }
        public AnimatableMatrix() : this(Matrix.Identity) { }

        public void Set(Matrix matrix) {
            animation = null;
            Matrix = matrix;
        }

        public bool AnimateTo(Matrix newMatrix) {
            if (animation == null) {
                animation = new Animation<Matrix>(matrix, newMatrix);
                return true;
            }
            return false;
        }

        public void Update() {
            if (animation == null) return;
            if (animation.Ended) {
                Matrix = animation.CurrentValue;
                animation = null;
            } else {
                Matrix = animation.CurrentValue;
            }

        }

    }
}
