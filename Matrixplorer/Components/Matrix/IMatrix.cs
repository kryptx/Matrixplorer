using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

    public interface IMatrix {

        Matrix Matrix { get; }
        void Set(Matrix matrix);
        bool Invert();
        event EventHandler<MatrixChangedEventArgs> Changed;

    }

}
