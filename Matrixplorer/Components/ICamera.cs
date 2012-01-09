﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

    public interface ICamera {

        AnimatableMatrix View { get; set; }
        AnimatableMatrix Projection { get; set; }

    }

}
