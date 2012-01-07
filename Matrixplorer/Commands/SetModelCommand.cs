using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Matrixplorer.Controls;

namespace Matrixplorer.Commands {
    class SetModelCommand : ModelDisplayMatrixCommand, ICommand {

        public SetModelCommand(MatrixDisplayControl control, MatrixType type, Matrix transformMatrix) {
            this.type = type;
            this.newMatrix = transformMatrix * control.Matrix;
            this.oldMatrix = control.Matrix;
        }

    }
}
