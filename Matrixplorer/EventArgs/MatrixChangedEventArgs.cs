using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer {
    public class MatrixChangedEventArgs : EventArgs {
        public Matrix NewMatrix { get; set; }
    }
}
