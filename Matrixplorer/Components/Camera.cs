using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer.Components {

    class Camera : ICamera {

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

        public AnimatableMatrix Projection { get; set; }

        private AnimatableMatrix view;
        public AnimatableMatrix View {
            get { return view; }
            set {
                view = value;
                view.Changed += (sender, e) => {
                    Matrix inverseView = Matrix.Invert(value.Matrix);
                    position = inverseView.Translation;
                    target = inverseView.Forward;
                    up = inverseView.Up;
                };
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

            this.position = position;
            this.target = target;
            this.aspectRatio = aspectRatio;

            View = new AnimatableMatrix();
            Projection = new AnimatableMatrix();

            ComputeView();
            ComputeProjection();

        }


        public Camera() : this(Vector3.UnitZ, Vector3.Zero, 1) { }


        private void ComputeVectors() {
            strafe = -Vector3.Cross(Target - Position, Vector3.Up);
            up = Vector3.Cross(Target - Position, strafe);
        }


        // projection matrix computation uses fairly typical FOV and depth values
        private void ComputeProjection() {
            Projection.Set(
                Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, 0.1f, 100.0f)
            );
        }


        private void ComputeView() {

            ComputeVectors();
            View.Set(
                Matrix.CreateLookAt(Position, Target, up)
            );

        }


        public void Rotate(int ticks) {
            // ticks == degrees makes for a comfortable amount of rotation
            float angle = MathHelper.ToRadians(ticks);
            View.Set(Matrix.CreateRotationY(angle) * View.Matrix);
        }


        public void Zoom(float distance) {
            Position *= (1 + (distance / position.Length()));
        }

    }

}
