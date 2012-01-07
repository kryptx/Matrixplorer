using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Matrixplorer.Controls;

namespace Matrixplorer.Commands {

    abstract class ModelDisplayMatrixCommand : MatrixCommand, ICommand {

        protected ModelDisplayControl control;
        protected MatrixType type;

        public void Execute() {
            control.AnimateTo(type, newMatrix);
        }

        public void Undo() {
            control.SetTo(type, oldMatrix);
        }

    }

}
