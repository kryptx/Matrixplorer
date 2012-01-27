using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {
    public class AnimatableMatrix : SimpleMatrix {

        private Animation<Matrix> animation;
        public AnimatableMatrix(Matrix mat) { matrix = mat; }
        public AnimatableMatrix() : this(Matrix.Identity) { }
        
        public bool AnimateTo(Matrix newMatrix) {
            if (animation == null) {
                animation = new Animation<Matrix>(matrix, newMatrix);
                return true;
            }
            return false;
        }

        public override bool Invert() {
            if (Matrix.Determinant() == 0)
                return false;
            else return AnimateTo(Matrix.Invert(Matrix));
        }

        public override void Set(Matrix matrix) {
            base.Set(matrix);
            animation = null;
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
