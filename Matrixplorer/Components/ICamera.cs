using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

    public interface ICamera {

        Matrix View { get; set; }
        Matrix Projection { get; set; }

        event EventHandler<MatrixChangedEventArgs> ViewChanged;
        event EventHandler<MatrixChangedEventArgs> ProjectionChanged;

    }

}
