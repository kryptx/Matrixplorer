namespace Matrixplorer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.transformsTabControl = new System.Windows.Forms.TabControl();
            this.modelTabPage = new System.Windows.Forms.TabPage();
            this.cameraTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.goButton = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.worldGroupBox = new System.Windows.Forms.GroupBox();
            this.viewGroupBox = new System.Windows.Forms.GroupBox();
            this.projectionGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.matrixEditor1 = new Matrixplorer.Controls.MatrixEditor();
            this.matrixDisplay1 = new Matrixplorer.Controls.MatrixDisplay();
            this.modelDisplayControl1 = new Matrixplorer.Controls.ModelDisplayControl();
            this.worldMatrixDisplay = new Matrixplorer.Controls.MatrixDisplay();
            this.viewMatrixDisplay = new Matrixplorer.Controls.MatrixDisplay();
            this.projectionMatrixDisplay = new Matrixplorer.Controls.MatrixDisplay();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.transformsTabControl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.worldGroupBox.SuspendLayout();
            this.viewGroupBox.SuspendLayout();
            this.projectionGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(767, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modelDisplayControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(503, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 263);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(767, 415);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.transformsTabControl, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.matrixEditor1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.MinimumSize = new System.Drawing.Size(434, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(494, 263);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // transformsTabControl
            // 
            this.transformsTabControl.Controls.Add(this.modelTabPage);
            this.transformsTabControl.Controls.Add(this.cameraTabPage);
            this.transformsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transformsTabControl.Location = new System.Drawing.Point(3, 3);
            this.transformsTabControl.MinimumSize = new System.Drawing.Size(200, 0);
            this.transformsTabControl.Name = "transformsTabControl";
            this.tableLayoutPanel3.SetRowSpan(this.transformsTabControl, 3);
            this.transformsTabControl.SelectedIndex = 0;
            this.transformsTabControl.Size = new System.Drawing.Size(254, 257);
            this.transformsTabControl.TabIndex = 5;
            // 
            // modelTabPage
            // 
            this.modelTabPage.Location = new System.Drawing.Point(4, 22);
            this.modelTabPage.Name = "modelTabPage";
            this.modelTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.modelTabPage.Size = new System.Drawing.Size(246, 231);
            this.modelTabPage.TabIndex = 0;
            this.modelTabPage.Text = "Model";
            this.modelTabPage.UseVisualStyleBackColor = true;
            // 
            // cameraTabPage
            // 
            this.cameraTabPage.Location = new System.Drawing.Point(4, 22);
            this.cameraTabPage.Name = "cameraTabPage";
            this.cameraTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.cameraTabPage.Size = new System.Drawing.Size(246, 231);
            this.cameraTabPage.TabIndex = 1;
            this.cameraTabPage.Text = "Camera";
            this.cameraTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.goButton);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(263, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 27);
            this.panel1.TabIndex = 6;
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(174, 1);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(51, 23);
            this.goButton.TabIndex = 2;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "World",
            "View",
            "Projection"});
            this.comboBox2.Location = new System.Drawing.Point(89, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(79, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Assign to",
            "Transform"});
            this.comboBox1.Location = new System.Drawing.Point(3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(80, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel2.Controls.Add(this.worldGroupBox, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.viewGroupBox, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.projectionGroupBox, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 272);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(761, 140);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // worldGroupBox
            // 
            this.worldGroupBox.Controls.Add(this.worldMatrixDisplay);
            this.worldGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.worldGroupBox.Location = new System.Drawing.Point(3, 3);
            this.worldGroupBox.Name = "worldGroupBox";
            this.worldGroupBox.Size = new System.Drawing.Size(245, 134);
            this.worldGroupBox.TabIndex = 0;
            this.worldGroupBox.TabStop = false;
            this.worldGroupBox.Text = "World";
            // 
            // viewGroupBox
            // 
            this.viewGroupBox.Controls.Add(this.viewMatrixDisplay);
            this.viewGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewGroupBox.Location = new System.Drawing.Point(254, 3);
            this.viewGroupBox.Name = "viewGroupBox";
            this.viewGroupBox.Size = new System.Drawing.Size(245, 134);
            this.viewGroupBox.TabIndex = 1;
            this.viewGroupBox.TabStop = false;
            this.viewGroupBox.Text = "View";
            // 
            // projectionGroupBox
            // 
            this.projectionGroupBox.Controls.Add(this.projectionMatrixDisplay);
            this.projectionGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectionGroupBox.Location = new System.Drawing.Point(505, 3);
            this.projectionGroupBox.Name = "projectionGroupBox";
            this.projectionGroupBox.Size = new System.Drawing.Size(253, 134);
            this.projectionGroupBox.TabIndex = 2;
            this.projectionGroupBox.TabStop = false;
            this.projectionGroupBox.Text = "Projection";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.matrixDisplay1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(263, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 120);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result Preview";
            // 
            // matrixEditor1
            // 
            this.matrixEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrixEditor1.Location = new System.Drawing.Point(263, 3);
            this.matrixEditor1.Matrix = null;
            this.matrixEditor1.Name = "matrixEditor1";
            this.matrixEditor1.Size = new System.Drawing.Size(228, 94);
            this.matrixEditor1.TabIndex = 2;
            // 
            // matrixDisplay1
            // 
            this.matrixDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matrixDisplay1.Location = new System.Drawing.Point(3, 16);
            this.matrixDisplay1.Name = "matrixDisplay1";
            this.matrixDisplay1.Size = new System.Drawing.Size(222, 101);
            this.matrixDisplay1.TabIndex = 0;
            // 
            // modelDisplayControl1
            // 
            this.modelDisplayControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modelDisplayControl1.Location = new System.Drawing.Point(3, 16);
            this.modelDisplayControl1.Name = "modelDisplayControl1";
            this.modelDisplayControl1.Size = new System.Drawing.Size(255, 244);
            this.modelDisplayControl1.TabIndex = 0;
            this.modelDisplayControl1.Text = "modelDisplayControl1";
            this.modelDisplayControl1.World = new Microsoft.Xna.Framework.Matrix(0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F);
            this.modelDisplayControl1.Resize += new System.EventHandler(this.modelDisplayControl1_Resize);
            // 
            // worldMatrixDisplay
            // 
            this.worldMatrixDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worldMatrixDisplay.Location = new System.Drawing.Point(3, 22);
            this.worldMatrixDisplay.Name = "worldMatrixDisplay";
            this.worldMatrixDisplay.Size = new System.Drawing.Size(239, 109);
            this.worldMatrixDisplay.TabIndex = 0;
            // 
            // viewMatrixDisplay
            // 
            this.viewMatrixDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewMatrixDisplay.Location = new System.Drawing.Point(3, 22);
            this.viewMatrixDisplay.Name = "viewMatrixDisplay";
            this.viewMatrixDisplay.Size = new System.Drawing.Size(239, 109);
            this.viewMatrixDisplay.TabIndex = 0;
            // 
            // projectionMatrixDisplay
            // 
            this.projectionMatrixDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectionMatrixDisplay.Location = new System.Drawing.Point(3, 22);
            this.projectionMatrixDisplay.Name = "projectionMatrixDisplay";
            this.projectionMatrixDisplay.Size = new System.Drawing.Size(247, 109);
            this.projectionMatrixDisplay.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 439);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(783, 477);
            this.Name = "Form1";
            this.Text = "Matrixplorer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.transformsTabControl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.worldGroupBox.ResumeLayout(false);
            this.viewGroupBox.ResumeLayout(false);
            this.projectionGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private Controls.ModelDisplayControl modelDisplayControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox worldGroupBox;
        private System.Windows.Forms.GroupBox viewGroupBox;
        private System.Windows.Forms.GroupBox projectionGroupBox;
        private Controls.MatrixDisplay worldMatrixDisplay;
        private Controls.MatrixDisplay viewMatrixDisplay;
        private Controls.MatrixDisplay projectionMatrixDisplay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TabControl transformsTabControl;
        private System.Windows.Forms.TabPage modelTabPage;
        private System.Windows.Forms.TabPage cameraTabPage;
        private Controls.MatrixEditor matrixEditor1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.MatrixDisplay matrixDisplay1;
    }
}

