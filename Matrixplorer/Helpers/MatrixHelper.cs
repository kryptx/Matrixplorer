using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Matrixplorer {
    class MatrixHelper {
        // TODO: figure out what to do with this...
        public static MatrixType StringToType(string typeString) {
            switch (typeString.ToLowerInvariant()) {

                case "view":
                    return MatrixType.View;

                case "projection":
                    return MatrixType.Projection;

                default:
                    return MatrixType.World;

            }
        }
    }
}
