using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Matrixplorer.Components;

namespace Matrixplorer.Commands {
    class ImmediateMatrixCommand : ChangeMatrixCommand {

        public ImmediateMatrixCommand(IMatrix matrix, Matrix newMatrix) {
            this.matrix = matrix;
            this.oldMatrix = matrix.Matrix;
            this.newMatrix = newMatrix;
        }

        public override bool Execute() {
            matrix.Set(newMatrix);
            return true;
        }

    }

}
