using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer {

    public enum MatrixType { World, View, Projection };

    public class MatrixHelper {

        public static Matrix Transform(Matrix input, Matrix transformation) {
            return transformation * input;
        }

        public static MatrixType StringToType(string typeString) {

            switch (typeString.ToLowerInvariant()) {

                case "view":
                    return MatrixType.View;

                case "projection":
                    return MatrixType.Projection;

                case "world":
                    return MatrixType.World;

                default:
                    throw new FormatException(String.Format("{0} is not a recognized matrix type.", typeString));

            }

        }


    }
}
