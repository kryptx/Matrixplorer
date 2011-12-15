using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer {

    class Camera {

        private event EventHandler<EventArgs> CameraMoved;
        private event EventHandler<EventArgs> AspectChanged;

        private Vector3 position;
        public Vector3 Position {
            get { return position; }
            set {
                position = value;
                CameraMoved.Invoke(this, new EventArgs());
            }
        }

        private Vector3 target;
        public Vector3 Target {
            get { return target; }
            set {
                target = value;
                CameraMoved.Invoke(this, new EventArgs());
            }
        }

        private Vector3 up;
        private Vector3 strafe;

        public Matrix Projection { get; protected set; }
        private Matrix view;

        private float aspectRatio;
        public float AspectRatio {
            get { return aspectRatio; }
            set {
                aspectRatio = value;
                AspectChanged.Invoke(this, new EventArgs());
            }
        }

        public Matrix View {
            get { return view; }
        }


        public Camera(Vector3 position, Vector3 target, float aspectRatio) {

            // set these while we still have no event handler, so that we don't compute the view matrix using null vectors
            Position = position;
            Target = target;

            CameraMoved += CameraMovedHandler;
            AspectChanged += AspectChangedHandler;

            // now compute the initial up/strafe vectors and view matrix
            ComputeVectors();
            ComputeView();

            // this will trigger the AspectChanged event, and set the projection matrix
            AspectRatio = aspectRatio;

        }


        private void CameraMovedHandler(object sender, EventArgs e) {
            ComputeVectors();
            ComputeView();
        }


        private void AspectChangedHandler(object sender, EventArgs e) {
            ComputeProjection();
        }


        public Camera() : this(Vector3.UnitZ, Vector3.Zero, 1) { }


        private void ComputeVectors() {
            strafe = Vector3.Cross(Target - Position, Vector3.Up);
            up = Vector3.Cross(Target - Position, strafe);
        }


        private void ComputeProjection() {
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, 1, 100);
        }


        private void ComputeView() {
            view = Matrix.CreateLookAt(Position, Target, up);
        }

    }

}
