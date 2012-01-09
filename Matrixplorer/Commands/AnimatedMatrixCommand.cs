using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Matrixplorer.Components;

namespace Matrixplorer.Commands {
    class AnimatedMatrixCommand : ChangeMatrixCommand {
        
        public AnimatedMatrixCommand(AnimatableMatrix matrix, Matrix newMatrix) {
            this.matrix = matrix;
            this.oldMatrix = matrix.Matrix;
            this.newMatrix = newMatrix;
        }

        public override bool Execute() {
            return ((AnimatableMatrix)matrix).AnimateTo(newMatrix);
        }

    }
}
