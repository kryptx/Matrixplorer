using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
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
        Matrix[] boneTransforms;

        protected override void Initialize() {

            camera = new Camera(
                position: new Vector3(0, 1, -2),
                target: Vector3.Zero,
                aspectRatio: GraphicsDevice.Viewport.AspectRatio
            );

            content = new ContentManager(Services, "Content");
            model = content.Load<Model>("SpaceShip");

            boneTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);

            Application.Idle += delegate { Invalidate(); };
            
        }


        protected override void Draw() {

            Matrix world = Matrix.CreateWorld(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GraphicsDevice.Clear(Color.White);

            if (model != null) {

                // Draw the model.
                foreach (ModelMesh mesh in model.Meshes) {
                    foreach (BasicEffect effect in mesh.Effects) {
                        effect.World = boneTransforms[mesh.ParentBone.Index] * world;
                        effect.View = camera.View;
                        effect.Projection = camera.Projection;

                        effect.EnableDefaultLighting();
                        effect.PreferPerPixelLighting = true;
                        effect.SpecularPower = 16;
                    }

                    mesh.Draw();
                }
            }

        }

        public void UpdateAspectRatio() {
            camera.AspectRatio = GraphicsDevice.Viewport.AspectRatio;
        }

    }

}
