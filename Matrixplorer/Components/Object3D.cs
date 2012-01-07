using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Matrixplorer.Components {

    public class Object3D {

        public event EventHandler<MatrixChangedEventArgs> WorldChanged {
            add { world.Changed += value; }
            remove { world.Changed -= value; }
        }

        private Model model;
        private Matrix[] boneTransforms;

        private AnimatableMatrix world;
        public Matrix World {
            get { return world.Matrix; }
            set { world.SetMatrix(value); }
        }

        public Object3D(ContentManager content) {
            
            model = content.Load<Model>("SpaceShip");
            boneTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);
            world = new AnimatableMatrix();

        }

        public void Draw(ICamera camera) {
            foreach (ModelMesh mesh in model.Meshes) {
                foreach (BasicEffect effect in mesh.Effects) {
                    effect.World = boneTransforms[mesh.ParentBone.Index] * World;
                    effect.View = camera.View;
                    effect.Projection = camera.Projection;

                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.SpecularPower = 16;
                }

                mesh.Draw();
            }
        }

        public void Rotate(float angle) {
            World *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
        }

    }

}
