using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Matrixplorer.Components {

    public class Object3D {

        private Model model;
        private Matrix[] boneTransforms;

        public AnimatableMatrix World { get; set; }

        public Object3D(ContentManager content) {
            
            model = content.Load<Model>("SpaceShip");
            boneTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);
            World = new AnimatableMatrix();

        }

        public void Draw(ICamera camera) {
            foreach (ModelMesh mesh in model.Meshes) {
                foreach (BasicEffect effect in mesh.Effects) {
                    effect.World = boneTransforms[mesh.ParentBone.Index] * World.Matrix;
                    effect.View = camera.View.Matrix;
                    effect.Projection = camera.Projection.Matrix;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.SpecularPower = 16;
                }

                mesh.Draw();
            }
        }

        public void Rotate(float angle) {
            World.Set(
                Matrix.CreateRotationY(MathHelper.ToRadians(angle)) * World.Matrix);
        }

    }

}
