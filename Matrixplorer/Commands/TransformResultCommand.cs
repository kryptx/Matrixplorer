using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Matrixplorer.Controls;

namespace Matrixplorer.Commands {

    class TransformResultCommand : ResultDisplayMatrixCommand, ICommand {

        public TransformResultCommand(MatrixDisplayControl control, Matrix transformMatrix) {
            this.newMatrix = transformMatrix * control.Matrix;
            this.oldMatrix = control.Matrix;
        }

    }

}
