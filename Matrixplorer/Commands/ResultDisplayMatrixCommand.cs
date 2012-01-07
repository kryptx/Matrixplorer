using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Matrixplorer.Controls;

namespace Matrixplorer.Commands {

    abstract class ResultDisplayMatrixCommand : MatrixCommand, ICommand {

        protected MatrixDisplayControl control;

        public void Execute() {
            control.Matrix = newMatrix;
        }

        public void Undo() {
            control.Matrix = oldMatrix;
        }

    }

}
