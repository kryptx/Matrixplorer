using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Matrixplorer.Commands;
using Matrixplorer.Controls;
using Matrixplorer.Components;
using Microsoft.Xna.Framework;

namespace Matrixplorer {
    public partial class Form1 : Form {

        Stack<ICommand> undoStack;
        Stack<ICommand> redoStack;

        public Form1() {

            InitializeComponent();
            InitFormValues();

            undoStack = new Stack<ICommand>(100);
            redoStack = new Stack<ICommand>(100);

        }


        private void Form1_Load(object sender, EventArgs e) {

            worldMatrixDisplay.Matrix = modelDisplayControl1.World;
            viewMatrixDisplay.Matrix = modelDisplayControl1.View;
            projectionMatrixDisplay.Matrix = modelDisplayControl1.Projection;

        }


        private void InitFormValues() {

            yourDispositionComboBox.SelectedIndex = yourDispositionComboBox.Items.IndexOf("Transform");
            yourDestinationComboBox.SelectedIndex = yourDestinationComboBox.Items.IndexOf("Result");

            resultDispositionComboBox.SelectedIndex = resultDispositionComboBox.Items.IndexOf("Transform");
            resultDestinationComboBox.SelectedIndex = resultDestinationComboBox.Items.IndexOf("World");

            fovUnitsComboBox.SelectedIndex = fovUnitsComboBox.Items.IndexOf("Radians");
            angleUnitsComboBox.SelectedIndex = angleUnitsComboBox.Items.IndexOf("Radians");

            viewPositionTextBox.Text = "2,0,0";
            viewTargetTextBox.Text = "0,0,0";
            viewUpTextBox.Text = "0,1,0";

            worldPositionTextBox.Text = "0,0,0";
            worldForwardTextBox.Text = "0,0,-1";
            worldUpTextBox.Text = "0,1,0";

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
            } catch (FormatException) {
                MessageBox.Show("Width, height, near plane and far plane must all be numeric.");
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
            } catch (FormatException) {
                MessageBox.Show("Field of view, aspect ratio, near plane and far plane must all be numeric.");
            }

        }


        private void createViewButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateLookAt(
                    ParseVector(viewPositionTextBox.Text),
                    ParseVector(viewTargetTextBox.Text),
                    ParseVector(viewUpTextBox.Text)
                );
            } catch (FormatException) {
                MessageBox.Show("Position, target, and up vectors must all be in the format X,Y,Z where X, Y, and Z are numbers.");
            }

        }


        private Vector3 ParseVector(string vectorString) {

            string[] strings = vectorString.Split(',');
            float[] floats = 

                (from s in strings select float.Parse(s)).ToArray();
                strings.Select<string, float>(s => float.Parse(s)).ToArray();

            if (floats.Count() != 3) {
                throw new FormatException("Vector must be in the format X,Y,Z.");
            }

            return new Vector3(floats[0], floats[1], floats[2]);

        }


        private void createScaleButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateScale(float.Parse(scalarTextBox.Text));
            } catch (FormatException) {
                MessageBox.Show("Scalar value must be a number.");
            }
        }


        private void createRotationButton_Click(object sender, EventArgs e) {
            try {

                if (xAxisRadioButton.Checked) {

                    yourMatrixEditor.Matrix = Matrix.CreateRotationX(
                        (angleUnitsComboBox.Text == "Radians")?
                        float.Parse(angleTextBox.Text) :
                        MathHelper.ToRadians(float.Parse(angleTextBox.Text))
                    );

                } else if (yAxisRadioButton.Checked) {

                    yourMatrixEditor.Matrix = Matrix.CreateRotationY(
                        (angleUnitsComboBox.Text == "Radians") ?
                        float.Parse(angleTextBox.Text) :
                        MathHelper.ToRadians(float.Parse(angleTextBox.Text))
                    );

                } else if (zAxisRadioButton.Checked) {

                    yourMatrixEditor.Matrix = Matrix.CreateRotationZ(
                        (angleUnitsComboBox.Text == "Radians") ?
                        float.Parse(angleTextBox.Text) :
                        MathHelper.ToRadians(float.Parse(angleTextBox.Text))
                    );

                }

            } catch (FormatException) {
                MessageBox.Show("Angle must be a number.");
            }

        }


        private void createTranslationButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateTranslation(ParseVector(translationVectorTextBox.Text));
            } catch {
                MessageBox.Show("Your translation vector is not of the form X,Y,Z where X, Y, and Z are numbers.");
            }
        }

        private void createWorldButton_Click(object sender, EventArgs e) {
            try {
                yourMatrixEditor.Matrix = Matrix.CreateWorld(
                    ParseVector(worldPositionTextBox.Text),
                    ParseVector(worldForwardTextBox.Text),
                    ParseVector(worldUpTextBox.Text)
                );
            } catch (FormatException) {
                MessageBox.Show("One or more vectors is not of the form X,Y,Z where X, Y, and Z are numbers.");
            }
        }


        private void yourGoButton_Click(object sender, EventArgs e) {
            try {
                ProcessGoButton(
                    yourDispositionComboBox.Text.ToLowerInvariant(),
                    yourDestinationComboBox.Text.ToLowerInvariant(),
                    (Matrix)yourMatrixEditor.Matrix
                );
            } catch (InvalidOperationException) {

                MessageBox.Show("Your matrix could not be read.  One or more elements is not numeric.");
            }
        }

        private void resultGoButton_Click(object sender, EventArgs e) {
            try {
                ProcessGoButton(
                    resultDispositionComboBox.Text.ToLowerInvariant(), 
                    resultDestinationComboBox.Text.ToLowerInvariant(),
                    resultMatrixDisplay.MatrixValue
                );
            } catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message);
            }

        }

        private void ProcessGoButton(string disposition, string destination, Matrix matrix) {

            if (disposition.Equals("assign to")) {
                SetMatrix(destination, matrix);
            }

            if (disposition.Equals("transform")) {
                TransformMatrix(destination, matrix);
            }

        }

        private void TransformMatrix(string whichMatrix, Matrix transformation) {

            switch (whichMatrix) {

                case "result":
                    // violation of SRP?
                    resultMatrixDisplay.Matrix.Set(transformation * resultMatrixDisplay.MatrixValue);
                    break;

                default:
                    modelDisplayControl1.AnimateTransform(MatrixHelper.StringToType(whichMatrix), transformation);
                    break;

            }

        }


        private void SetMatrix(string whichMatrix, Matrix matrix) {

            ICommand command;

            switch (whichMatrix) {

                case "result":
                    command = new ImmediateMatrixCommand(resultMatrixDisplay.Matrix, matrix);
                    DoCommand(command);
                    // resultMatrixDisplay.Matrix.Set(matrix);
                    break;

                default:
                    MatrixType type = MatrixHelper.StringToType(whichMatrix);
                    AnimatableMatrix target = modelDisplayControl1.GetMatrix(type);
                    command = new AnimatedMatrixCommand(target, matrix);
                    DoCommand(command);

                    // modelDisplayControl1.AnimateTo(MatrixHelper.StringToType(whichMatrix), matrix);
                    break;

            }

        }


        private void DoCommand(ICommand command) {
            if (command.Execute()) {
                undoStack.Push(command);
                redoStack.Clear();
            }
        }


        private void Undo() {
            ICommand command = undoStack.Peek();
            if (command.Execute())
                redoStack.Push(undoStack.Pop());
        }


        private void Redo() {
            ICommand command = redoStack.Peek();
            if (command.Execute())
                undoStack.Push(redoStack.Pop());
        }
        
    }

}
