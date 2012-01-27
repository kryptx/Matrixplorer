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
        private AnimatableCamera camera;
        private BasicEffect axisEffect;
        private VertexBuffer axesBuffer;

        private AnimatableModel model;

        public AnimatableMatrix World { 
            get { return model.World; }
            set { model.World = value; }
        }

        public AnimatableMatrix View {
            get { return (AnimatableMatrix)camera.View; }
            set { camera.View = value; }
        }

        public AnimatableMatrix Projection {
            get { return (AnimatableMatrix)camera.Projection; }
            set { camera.Projection = value; }
        }

        public float AspectRatio {
            get { return GraphicsDevice.Viewport.AspectRatio; }
        }


        protected override void Initialize() {
            InitModel();
            InitCamera();
            InitAxes();
            Application.Idle += delegate { Invalidate(); };
            
        }


        internal AnimatableMatrix GetMatrix(MatrixType whichMatrix) {
            switch (whichMatrix) {
                case MatrixType.World:
                    return World;

                case MatrixType.View:
                    return View;

                case MatrixType.Projection:
                    return Projection;

            }

            throw new InvalidOperationException(String.Format("Unrecognized matrix type: {0}", whichMatrix));

        }


        public bool AnimateTo(MatrixType whichMatrix, Matrix end) {
            return GetMatrix(whichMatrix).AnimateTo(end);
        }


        public bool AnimateTransform(MatrixType whichMatrix, Matrix transform) {
            AnimatableMatrix aniMatrix = GetMatrix(whichMatrix);
            return GetMatrix(whichMatrix).AnimateTo(transform * aniMatrix.Matrix);
        }


        private void InitModel() {
            
            ContentManager content = new ContentManager(Services, "Content");
            model = new AnimatableModel(content);

        }


        private void InitCamera() {
            
            camera = new AnimatableCamera(
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

            UpdateAnimations();
            GraphicsDevice.Clear(Color.White);
            DrawAxes();
            model.Draw(camera);

        }


        private void UpdateAnimations() {
            World.Update();
            View.Update();
            Projection.Update();
        }


        private void DrawAxes() {

            axisEffect.View = View.Matrix;
            axisEffect.Projection = Projection.Matrix;
            axisEffect.CurrentTechnique.Passes[0].Apply();
            GraphicsDevice.SetVertexBuffer(axesBuffer);
            GraphicsDevice.DrawPrimitives(PrimitiveType.LineList, 0, axesBuffer.VertexCount);

        }


        public void UpdateCameraAspectRatio() {
            camera.AspectRatio = GraphicsDevice.Viewport.AspectRatio;
        }


        internal void SetNow(MatrixType type, Matrix newMatrix) {
            GetMatrix(type).Set(newMatrix);
        }
    }
}
