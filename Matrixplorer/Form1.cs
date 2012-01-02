using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Matrixplorer.Controls;
using Microsoft.Xna.Framework;

namespace Matrixplorer {
    public partial class Form1 : Form {

        public Form1() {

            InitializeComponent();
            InitFormValues();

        }


        private void InitFormValues() {
            
            resultMatrixDisplay.Matrix = Matrix.Identity;

            yourDispositionComboBox.SelectedIndex = yourDispositionComboBox.Items.IndexOf("Transform");
            yourDestinationComboBox.SelectedIndex = yourDestinationComboBox.Items.IndexOf("Result");

            resultDispositionComboBox.SelectedIndex = resultDispositionComboBox.Items.IndexOf("Transform");
            resultDestinationComboBox.SelectedIndex = resultDestinationComboBox.Items.IndexOf("World");

            fovUnitsComboBox.SelectedIndex = fovUnitsComboBox.Items.IndexOf("Radians");
            angleUnitsComboBox.SelectedIndex = angleUnitsComboBox.Items.IndexOf("Radians");

            yAxisRadioButton.Checked = true;

        }

        private void modelDisplayControl1_Resize(object sender, EventArgs e) {
            modelDisplayControl1.UpdateCameraAspectRatio();

        }

        private void createOrthographicButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateOrthographic(
                    float.Parse(orthographicWidthTextBox.Text),
                    float.Parse(orthographicHeightTextBox.Text),
                    float.Parse(zNearPlaneTextBox.Text),
                    float.Parse(zFarPlaneTextBox.Text));
            } catch { 
                // TODO: show error messages when something fails
            }
        }

        private void createPerspectiveButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreatePerspectiveFieldOfView(
                    (fovUnitsComboBox.Text.ToLower() == "degrees") ? MathHelper.ToRadians(float.Parse(fovTextBox.Text)) : float.Parse(fovTextBox.Text),
                    float.Parse(aspectRatioTextBox.Text),
                    float.Parse(nearPlaneTextBox.Text),
                    float.Parse(farPlaneTextBox.Text)
                );
            } catch {
                // TODO: show error messages when something fails
            }

        }

        private void createViewButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateLookAt(
                    ParseVector(viewPositionTextBox.Text),
                    ParseVector(viewTargetTextBox.Text),
                    ParseVector(viewUpTextBox.Text)
                );
            } catch {
                // TODO: show error messages when something fails
            }

        }


        private Vector3 ParseVector(string vectorString) {

            string[] strings = vectorString.Split(',');
            float[] floats = 

                (from s in strings select float.Parse(s)).ToArray();
                strings.Select<string, float>(s => float.Parse(s)).ToArray();

            if (floats.Count() != 3) {
                throw new InvalidOperationException("Vector must be in the format X,Y,Z");
            }

            return new Vector3(floats[0], floats[1], floats[2]);

        }


        private void createScaleButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateScale(float.Parse(scalarTextBox.Text));
            } catch {
                // TODO: show error messages when something fails
            }
        }

        private void createRotationButton_Click(object sender, EventArgs e) {
            try {
                if (xAxisRadioButton.Checked) {
                    yourMatrixEditor.Matrix = Matrix.CreateRotationX(float.Parse(angleTextBox.Text));
                } else if (yAxisRadioButton.Checked) {
                    yourMatrixEditor.Matrix = Matrix.CreateRotationY(float.Parse(angleTextBox.Text));
                } else if (zAxisRadioButton.Checked) {
                    yourMatrixEditor.Matrix = Matrix.CreateRotationZ(float.Parse(angleTextBox.Text));
                }
            } catch {
                // TODO: show error messages when something fails
            }

        }

        private void createTranslationButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateTranslation(ParseVector(translationVectorTextBox.Text));
            } catch {
                // TODO: show error messages when something fails
            }
        }

        private void createWorldButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateWorld(
                    ParseVector(worldPositionTextBox.Text),
                    ParseVector(worldForwardTextBox.Text),
                    ParseVector(worldUpTextBox.Text)
                );
            } catch {
                // TODO: show error messages when something fails
            }
        }





        private void Form1_Load(object sender, EventArgs e) {

            SetMatrixDisplays();

            modelDisplayControl1.WorldChanged += worldMatrixDisplay.MatrixChanged;
            modelDisplayControl1.ViewChanged += viewMatrixDisplay.MatrixChanged;
            modelDisplayControl1.ProjectionChanged += projectionMatrixDisplay.MatrixChanged;
            modelDisplayControl1.ProjectionChanged += (_sender, _e) => {
                aspectRatioTextBox.Text = modelDisplayControl1.AspectRatio.ToString("G3");
            };

        }

        private void SetMatrixDisplays() {
            worldMatrixDisplay.Matrix = modelDisplayControl1.World;
            viewMatrixDisplay.Matrix = modelDisplayControl1.View;
            projectionMatrixDisplay.Matrix = modelDisplayControl1.Projection;
        }

        private void yourGoButton_Click(object sender, EventArgs e) {
            ProcessGoButton(
                yourDispositionComboBox.Text.ToLowerInvariant(), 
                yourDestinationComboBox.Text.ToLowerInvariant()
            );
        }

        private void resultGoButton_Click(object sender, EventArgs e) {
            ProcessGoButton(
                resultDispositionComboBox.Text.ToLowerInvariant(), 
                resultDestinationComboBox.Text.ToLowerInvariant()
            );
        }

        private void ProcessGoButton(string disposition, string destination) {

            if (disposition.Equals("assign to")) {
                SetMatrix(destination, (Matrix)yourMatrixEditor.Matrix);
            }

            if (disposition.Equals("transform")) {
                TransformMatrix(destination, (Matrix)yourMatrixEditor.Matrix);
            }

        }

        private void TransformMatrix(string whichMatrix, Matrix transformation) {

            switch (whichMatrix) {

                case "world":
                case "view":
                case "projection":
                    modelDisplayControl1.AnimateTransform(whichMatrix, transformation);
                    break;

                case "result":
                    // violation of SRP?
                    resultMatrixDisplay.Matrix = transformation * resultMatrixDisplay.Matrix;
                    break;

            }

        }

        private void SetMatrix(string whichMatrix, Matrix matrix) {

            switch (whichMatrix) {

                case "world":
                case "view":
                case "projection":
                    modelDisplayControl1.AnimateTo(whichMatrix, matrix);
                    break;

                case "result":
                    resultMatrixDisplay.Matrix = matrix;
                    break;

            }

        }
        
    }

}
