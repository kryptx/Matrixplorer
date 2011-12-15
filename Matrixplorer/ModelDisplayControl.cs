using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Matrixplorer {

    public partial class ModelDisplayControl : GraphicsDeviceControl {

        Camera camera;
        ContentManager content;
        Model model;

        protected override void Initialize() {

            camera = new Camera(
                position: new Vector3(5, 5, 5),
                target: Vector3.Zero,
                aspectRatio: 1
            );

            content = new ContentManager(Services, "Content");
            model = content.Load<Model>("SpaceShip");

        }


        protected override void Draw() {
            throw new NotImplementedException();
        }

    }

}
