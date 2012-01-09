using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Matrixplorer.Components;

namespace Matrixplorer.Commands {

    abstract class ChangeMatrixCommand : ICommand {

        protected Matrix newMatrix;
        protected Matrix oldMatrix;
        protected IMatrix matrix;

        public abstract bool Execute();

        public void Undo() {
            matrix.Set(oldMatrix);
        }

    }

}
