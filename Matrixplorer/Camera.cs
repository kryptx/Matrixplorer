using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Matrixplorer {

    class Camera {
        
        public event EventHandler<MatrixChangedEventArgs> ViewChanged;
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

        private Matrix projection;
        public Matrix Projection {

            get { return projection; }
            protected set {
                projection = value;
                if (ProjectionChanged != null) {
                    ProjectionChanged.Invoke(this, 
                        new MatrixChangedEventArgs { NewMatrix = value });
                }
            }

        }

        private Matrix view;
        public Matrix View {

            get { return view; }
            set {
                view = value;
                if (ViewChanged != null) {
                    ViewChanged.Invoke(this, 
                        new MatrixChangedEventArgs { NewMatrix = value });
                }
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
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, AspectRatio, 1, 100);
        }


        private void ComputeView() {

            ComputeVectors();
            View = Matrix.CreateLookAt(Position, Target, up);

        }

    }

}
