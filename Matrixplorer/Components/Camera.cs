using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

    class Camera : ICamera {

        public event EventHandler<MatrixChangedEventArgs> ViewChanged {
            add { projection.Changed += value; }
            remove { projection.Changed -= value; }
        }
        public event EventHandler<MatrixChangedEventArgs> ProjectionChanged;


        // position and view provide shortcut properties to generate a view matrix
        private Vector3 position;
        public Vector3 Position {
            get { return position; }
            set {
                position = value;
                ComputeView();
            }
        }

        private Vector3 target;
        public Vector3 Target {
            get { return target; }
            set {
                target = value;
                ComputeView();
            }
        }

        private Vector3 up;
        private Vector3 strafe;

        private AnimatableMatrix projection;
        public Matrix Projection {
            get { return projection.Matrix; }
            set { projection.SetMatrix(value); }
        }

        private AnimatableMatrix view;
        public Matrix View {

            get { return view.Matrix; }
            set {
                view.SetMatrix(value);

                Matrix inverseView = Matrix.Invert(value);
                position = inverseView.Translation;
                target = inverseView.Forward;
                up = inverseView.Up;
            }
        }

        private float aspectRatio;
        public float AspectRatio {
            get { return aspectRatio; }
            set {
                aspectRatio = value;
                ComputeProjection();
            }
        }


        public Camera(Vector3 position, Vector3 target, float aspectRatio) {

            Position = position;
            Target = target;
            AspectRatio = aspectRatio;

            ComputeView();

        }


        public Camera() : this(Vector3.UnitZ, Vector3.Zero, 1) { }


        private void ComputeVectors() {
            strafe = -Vector3.Cross(Target - Position, Vector3.Up);
            up = Vector3.Cross(Target - Position, strafe);
        }


        // projection matrix computation uses fairly typical FOV and depth values
        private void ComputeProjection() {
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, 0.1f, 50.0f);
        }


        private void ComputeView() {

            ComputeVectors();
            View = Matrix.CreateLookAt(Position, Target, up);

        }


        public void Rotate(int ticks) {
            // ticks == degrees makes for a comfortable amount of rotation
            float angle = MathHelper.ToRadians(ticks);
            View = Matrix.CreateRotationY(angle) * View;
        }


        public void Zoom(float distance) {
            Position *= (1 + (distance / position.Length()));
        }

    }

}
