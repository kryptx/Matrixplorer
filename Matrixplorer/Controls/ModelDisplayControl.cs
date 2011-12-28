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

namespace Matrixplorer.Controls {

    public class ModelDisplayControl : GraphicsDeviceControl {

        private Camera camera;
        private ContentManager content;
        private Model model;
        private Matrix[] boneTransforms;

        private BasicEffect axisEffect;
        private VertexPositionColor[] axes;
        private VertexBuffer axesBuffer;

        private Matrix world;
        public Matrix World {
            get { return world; }
            set {
                world = value;
                if (WorldChanged != null) {
                    WorldChanged.Invoke(this,
                        new MatrixChangedEventArgs { NewMatrix = value });
                }
            }
        }

        public Matrix View {
            get { return camera.View; }
        }

        public Matrix Projection {
            get { return camera.Projection; }
        }

        public event EventHandler<MatrixChangedEventArgs> WorldChanged;
        public event EventHandler<MatrixChangedEventArgs> ViewChanged;
        public event EventHandler<MatrixChangedEventArgs> ProjectionChanged;


        protected override void Initialize() {

            camera = new Camera(
                position: new Vector3(1.2f, 1.0f, 0.8f),
                target: Vector3.Zero,
                aspectRatio: GraphicsDevice.Viewport.AspectRatio
            );

            axes = new VertexPositionColor[6] { 
                new VertexPositionColor(new Vector3(-50, 0, 0), Color.Red),
                new VertexPositionColor(new Vector3(50, 0, 0), Color.Red),
                new VertexPositionColor(new Vector3(0, -50, 0), Color.Blue),
                new VertexPositionColor(new Vector3(0, 50, 0), Color.Blue),
                new VertexPositionColor(new Vector3(0, 0, -50), Color.Green),
                new VertexPositionColor(new Vector3(0, 0, 50), Color.Green)
            };

            axesBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), axes.Count(), BufferUsage.None);
            axesBuffer.SetData(axes);

            axisEffect = new BasicEffect(GraphicsDevice);
            axisEffect.VertexColorEnabled = true;

            ViewChanged.Invoke(this,
                new MatrixChangedEventArgs { NewMatrix = camera.View });

            ProjectionChanged.Invoke(this,
                new MatrixChangedEventArgs { NewMatrix = camera.Projection });

            camera.ViewChanged += ViewChanged;
            camera.ProjectionChanged += ProjectionChanged;

            content = new ContentManager(Services, "Content");
            model = content.Load<Model>("SpaceShip");
            boneTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);

            World = Matrix.CreateWorld(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);

            Application.Idle += delegate { Invalidate(); };
            
        }


        protected override void Draw() {
            
            GraphicsDevice.Clear(Color.White);

            axisEffect.View = camera.View;
            axisEffect.Projection = camera.Projection;
            axisEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.SetVertexBuffer(axesBuffer);
            GraphicsDevice.DrawPrimitives(PrimitiveType.LineList, 0, 6);
            
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
