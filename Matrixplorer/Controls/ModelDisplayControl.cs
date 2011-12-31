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

using Matrixplorer.Components;

namespace Matrixplorer.Controls {

    public class ModelDisplayControl : GraphicsDeviceControl {

        private enum RotationType { None, Camera, Model };
        private RotationType rotationType;

        private System.Drawing.Point mouseWas;
        private Camera camera;
        private BasicEffect axisEffect;
        private VertexBuffer axesBuffer;

        private Object3D model;

        public Matrix World { get { return model.World; } }
        public Matrix View { get { return camera.View; } }
        public Matrix Projection { get { return camera.Projection; } }

        public float AspectRatio {
            get { return GraphicsDevice.Viewport.AspectRatio; }
        }

        public event EventHandler<MatrixChangedEventArgs> WorldChanged {
            add { model.WorldChanged += value; }
            remove { model.WorldChanged -= value; }
        }

        public event EventHandler<MatrixChangedEventArgs> ViewChanged {
            add { camera.ViewChanged += value; }
            remove { camera.ViewChanged -= value; }
        }

        public event EventHandler<MatrixChangedEventArgs> ProjectionChanged {
            add { camera.ProjectionChanged += value; }
            remove { camera.ProjectionChanged -= value; }
        }


        protected override void Initialize() {

            InitModel();
            InitCamera();
            InitAxes();

            Application.Idle += delegate { Invalidate(); };
            
        }


        private void InitModel() {
            model = new Object3D(Services);
        }


        private void InitCamera() {
            
            camera = new Camera(
                position: new Vector3(2.0f, 0.0f, 0.0f),
                target: Vector3.Zero,
                aspectRatio: GraphicsDevice.Viewport.AspectRatio
            );

        }


        private void InitAxes() {

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

        protected override void OnMouseEnter(EventArgs e) {
            base.OnMouseEnter(e);
            this.Focus();
        }


        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);
            
            camera.Zoom(-(float)e.Delta / 480);
        }


        protected override void OnMouseDown(MouseEventArgs e) {

            base.OnMouseDown(e);
            mouseWas = e.Location;

            switch(e.Button) {
                case System.Windows.Forms.MouseButtons.Left:
                    rotationType = RotationType.Model;
                    break;

                case System.Windows.Forms.MouseButtons.Right:
                    rotationType = RotationType.Camera;
                    break;

                default:
                    rotationType = RotationType.None;
                    break;

            }
            
        }


        protected override void OnMouseMove(MouseEventArgs e) {

            base.OnMouseMove(e);

            switch (rotationType) {
                case RotationType.Camera:
                    camera.Rotate(e.Location.X - mouseWas.X);
                    break;
                case RotationType.Model:
                    model.Rotate(e.Location.X - mouseWas.X);
                    break;

                default:
                    break;

            }

            mouseWas = e.Location;

        }


        protected override void OnMouseUp(MouseEventArgs e) {
            base.OnMouseUp(e);
            rotationType = RotationType.None;
        }


        protected override void Draw() {
            
            GraphicsDevice.Clear(Color.White);
            DrawAxes();
            model.Draw(camera);

        }


        private void DrawAxes() {

            axisEffect.View = camera.View;
            axisEffect.Projection = camera.Projection;
            axisEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.SetVertexBuffer(axesBuffer);
            GraphicsDevice.DrawPrimitives(PrimitiveType.LineList, 0, axesBuffer.VertexCount);

        }



        public void UpdateCameraAspectRatio() {
            camera.AspectRatio = GraphicsDevice.Viewport.AspectRatio;
        }

    }

}
