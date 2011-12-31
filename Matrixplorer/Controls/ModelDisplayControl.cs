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
using Microsoft.Xna.Framework.Input;

namespace Matrixplorer.Controls {

    public class ModelDisplayControl : GraphicsDeviceControl {

        private bool rotating;
        private System.Drawing.Point mouseWas;

        private Camera camera;
        private ContentManager content;
        private Model model;
        private Matrix[] boneTransforms;

        private BasicEffect axisEffect;
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

        public float AspectRatio {
            get { return GraphicsDevice.Viewport.AspectRatio; }
        }

        public event EventHandler<MatrixChangedEventArgs> WorldChanged;
        public event EventHandler<MatrixChangedEventArgs> ViewChanged;
        public event EventHandler<MatrixChangedEventArgs> ProjectionChanged;


        protected override void Initialize() {

            content = new ContentManager(Services, "Content");

            InitAxes();
            InitCamera();
            InitModel();

            Application.Idle += delegate { Invalidate(); };
            
        }


        private void InitModel() {
            model = content.Load<Model>("SpaceShip");
            boneTransforms = new Matrix[model.Bones.Count];
            model.CopyAbsoluteBoneTransformsTo(boneTransforms);
            World = Matrix.Identity;
        }


        private void InitCamera() {
            
            camera = new Camera(
                position: new Vector3(1.2f, 1.0f, 0.8f),
                target: Vector3.Zero,
                aspectRatio: GraphicsDevice.Viewport.AspectRatio
            );

            ViewChanged.Invoke(this,
                new MatrixChangedEventArgs { NewMatrix = camera.View });

            ProjectionChanged.Invoke(this,
                new MatrixChangedEventArgs { NewMatrix = camera.Projection });

            camera.ViewChanged += ViewChanged;
            camera.ProjectionChanged += ProjectionChanged;

        }


        private void InitAxes() {
            // 606 vertices:
            // 2 for each of 3 axes
            // 2 for each of 300 'tick marks'
            List<VertexPositionColor> axes = new List<VertexPositionColor>();

            axes.Add(new VertexPositionColor(new Vector3(-50, 0, 0), Color.Red));
            axes.Add(new VertexPositionColor(new Vector3(50, 0, 0), Color.Red));
            axes.Add(new VertexPositionColor(new Vector3(0, -50, 0), Color.Blue));
            axes.Add(new VertexPositionColor(new Vector3(0, 50, 0), Color.Blue));
            axes.Add(new VertexPositionColor(new Vector3(0, 0, -50), Color.Green));
            axes.Add(new VertexPositionColor(new Vector3(0, 0, 50), Color.Green));

            for (int i = -50; i <= 50; i++) {
                if (i % 5 == 0) {
                    axes.Add(new VertexPositionColor(new Vector3(i, 0, -0.1f), Color.Red));
                    axes.Add(new VertexPositionColor(new Vector3(i, 0, 0.1f), Color.Red));
                    axes.Add(new VertexPositionColor(new Vector3(-0.1f, 0, i), Color.Green));
                    axes.Add(new VertexPositionColor(new Vector3(0.1f, 0, i), Color.Green));
                    axes.Add(new VertexPositionColor(new Vector3(-0.1f, i, 0), Color.Green));
                    axes.Add(new VertexPositionColor(new Vector3(0.1f, i, 0), Color.Green));
                } else {
                    axes.Add(new VertexPositionColor(new Vector3(i, 0, -0.05f), Color.Red));
                    axes.Add(new VertexPositionColor(new Vector3(i, 0, 0.05f), Color.Red));
                    axes.Add(new VertexPositionColor(new Vector3(-0.05f, 0, i), Color.Green));
                    axes.Add(new VertexPositionColor(new Vector3(0.05f, 0, i), Color.Green));
                    axes.Add(new VertexPositionColor(new Vector3(-0.05f, i, 0), Color.Blue));
                    axes.Add(new VertexPositionColor(new Vector3(0.05f, i, 0), Color.Blue));
                }
            }

            axesBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), axes.Count(), BufferUsage.None);
            axesBuffer.SetData(axes.ToArray());

            axisEffect = new BasicEffect(GraphicsDevice);
            axisEffect.VertexColorEnabled = true;
        }



        protected override void OnMouseDown(MouseEventArgs e) {

            base.OnMouseDown(e);
            mouseWas = e.Location;
            rotating = true;
            
            
        }


        protected override void OnMouseMove(MouseEventArgs e) {

            base.OnMouseMove(e);

            if (rotating) {
                camera.Rotate(e.Location.X - mouseWas.X);
                mouseWas = e.Location;
            }

        }


        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            rotating = false;
        }


        protected override void Draw() {
            
            GraphicsDevice.Clear(Color.White);
            DrawAxes();
            DrawModel();

        }


        private void DrawAxes() {

            axisEffect.View = camera.View;
            axisEffect.Projection = camera.Projection;
            axisEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.SetVertexBuffer(axesBuffer);
            GraphicsDevice.DrawPrimitives(PrimitiveType.LineList, 0, axesBuffer.VertexCount);

        }


        private void DrawModel() {
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


        public void UpdateCameraAspectRatio() {
            camera.AspectRatio = GraphicsDevice.Viewport.AspectRatio;
        }

    }

}
