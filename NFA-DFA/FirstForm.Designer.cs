namespace NFA_DFA
{
    partial class FirstForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FirstForm));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnAddAlphabet = new System.Windows.Forms.Button();
            this.btnDelAlphabet = new System.Windows.Forms.Button();
            this.msktxtNumberOfVertex = new System.Windows.Forms.MaskedTextBox();
            this.btnAddFinalVertex = new System.Windows.Forms.Button();
            this.btnDelVector = new System.Windows.Forms.Button();
            this.btnDelFinalVertex = new System.Windows.Forms.Button();
            this.btnAddVector = new System.Windows.Forms.Button();
            this.btnTypeLanda = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnShowGraph = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCleanUp = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.lblSigma = new System.Windows.Forms.Label();
            this.lblTextAlphabet = new System.Windows.Forms.Label();
            this.lblEndSigma = new System.Windows.Forms.Label();
            this.lblTextNumberOfVertex = new System.Windows.Forms.Label();
            this.lblTextFinalVertex = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTextVector = new System.Windows.Forms.Label();
            this.openFileDialogImport = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogExport = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnAddAlphabet
            // 
            this.btnAddAlphabet.AutoEllipsis = true;
            this.btnAddAlphabet.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnAddAlphabet.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddAlphabet, "btnAddAlphabet");
            this.btnAddAlphabet.Name = "btnAddAlphabet";
            this.toolTip.SetToolTip(this.btnAddAlphabet, resources.GetString("btnAddAlphabet.ToolTip"));
            this.btnAddAlphabet.UseVisualStyleBackColor = false;
            this.btnAddAlphabet.Click += new System.EventHandler(this.btnAddAlphabet_Click);
            // 
            // btnDelAlphabet
            // 
            this.btnDelAlphabet.AutoEllipsis = true;
            this.btnDelAlphabet.BackColor = System.Drawing.Color.NavajoWhite;
            this.btnDelAlphabet.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelAlphabet, "btnDelAlphabet");
            this.btnDelAlphabet.Name = "btnDelAlphabet";
            this.toolTip.SetToolTip(this.btnDelAlphabet, resources.GetString("btnDelAlphabet.ToolTip"));
            this.btnDelAlphabet.UseVisualStyleBackColor = false;
            this.btnDelAlphabet.Click += new System.EventHandler(this.btnDelAlphabet_Click);
            // 
            // msktxtNumberOfVertex
            // 
            this.msktxtNumberOfVertex.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.msktxtNumberOfVertex.BeepOnError = true;
            this.msktxtNumberOfVertex.Culture = new System.Globalization.CultureInfo("");
            this.msktxtNumberOfVertex.HidePromptOnLeave = true;
            resources.ApplyResources(this.msktxtNumberOfVertex, "msktxtNumberOfVertex");
            this.msktxtNumberOfVertex.Name = "msktxtNumberOfVertex";
            this.msktxtNumberOfVertex.RejectInputOnFirstFailure = true;
            this.toolTip.SetToolTip(this.msktxtNumberOfVertex, resources.GetString("msktxtNumberOfVertex.ToolTip"));
            this.msktxtNumberOfVertex.Leave += new System.EventHandler(this.msktxtNumberOfVertex_Leave);
            // 
            // btnAddFinalVertex
            // 
            this.btnAddFinalVertex.AutoEllipsis = true;
            this.btnAddFinalVertex.BackColor = System.Drawing.Color.Pink;
            this.btnAddFinalVertex.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddFinalVertex, "btnAddFinalVertex");
            this.btnAddFinalVertex.Name = "btnAddFinalVertex";
            this.toolTip.SetToolTip(this.btnAddFinalVertex, resources.GetString("btnAddFinalVertex.ToolTip"));
            this.btnAddFinalVertex.UseVisualStyleBackColor = false;
            this.btnAddFinalVertex.Click += new System.EventHandler(this.btnAddFinalVertex_Click);
            // 
            // btnDelVector
            // 
            this.btnDelVector.AutoEllipsis = true;
            this.btnDelVector.BackColor = System.Drawing.Color.PaleGreen;
            this.btnDelVector.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelVector, "btnDelVector");
            this.btnDelVector.Name = "btnDelVector";
            this.toolTip.SetToolTip(this.btnDelVector, resources.GetString("btnDelVector.ToolTip"));
            this.btnDelVector.UseVisualStyleBackColor = false;
            this.btnDelVector.Click += new System.EventHandler(this.btnDelVector_Click);
            // 
            // btnDelFinalVertex
            // 
            this.btnDelFinalVertex.AutoEllipsis = true;
            this.btnDelFinalVertex.BackColor = System.Drawing.Color.Pink;
            this.btnDelFinalVertex.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnDelFinalVertex, "btnDelFinalVertex");
            this.btnDelFinalVertex.Name = "btnDelFinalVertex";
            this.toolTip.SetToolTip(this.btnDelFinalVertex, resources.GetString("btnDelFinalVertex.ToolTip"));
            this.btnDelFinalVertex.UseVisualStyleBackColor = false;
            this.btnDelFinalVertex.Click += new System.EventHandler(this.btnDelFinalVertex_Click);
            // 
            // btnAddVector
            // 
            this.btnAddVector.AutoEllipsis = true;
            this.btnAddVector.BackColor = System.Drawing.Color.PaleGreen;
            this.btnAddVector.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnAddVector, "btnAddVector");
            this.btnAddVector.Name = "btnAddVector";
            this.toolTip.SetToolTip(this.btnAddVector, resources.GetString("btnAddVector.ToolTip"));
            this.btnAddVector.UseVisualStyleBackColor = false;
            this.btnAddVector.Click += new System.EventHandler(this.btnAddVector_Click);
            // 
            // btnTypeLanda
            // 
            this.btnTypeLanda.BackColor = System.Drawing.SystemColors.Control;
            this.btnTypeLanda.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnTypeLanda, "btnTypeLanda");
            this.btnTypeLanda.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnTypeLanda.Name = "btnTypeLanda";
            this.toolTip.SetToolTip(this.btnTypeLanda, resources.GetString("btnTypeLanda.ToolTip"));
            this.btnTypeLanda.UseVisualStyleBackColor = false;
            this.btnTypeLanda.Click += new System.EventHandler(this.btnTypeLanda_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.AutoEllipsis = true;
            this.btnAbout.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            resources.ApplyResources(this.btnAbout, "btnAbout");
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnAbout.Name = "btnAbout";
            this.toolTip.SetToolTip(this.btnAbout, resources.GetString("btnAbout.ToolTip"));
            this.btnAbout.UseCompatibleTextRendering = true;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnShowGraph
            // 
            this.btnShowGraph.AutoEllipsis = true;
            this.btnShowGraph.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShowGraph.BackgroundImage = global::NFA_DFA.Properties.Resources.graph;
            resources.ApplyResources(this.btnShowGraph, "btnShowGraph");
            this.btnShowGraph.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowGraph.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnShowGraph.Name = "btnShowGraph";
            this.toolTip.SetToolTip(this.btnShowGraph, resources.GetString("btnShowGraph.ToolTip"));
            this.btnShowGraph.UseCompatibleTextRendering = true;
            this.btnShowGraph.UseVisualStyleBackColor = false;
            this.btnShowGraph.Click += new System.EventHandler(this.btnShowGraph_Click);
            // 
            // btnExport
            // 
            this.btnExport.AutoEllipsis = true;
            this.btnExport.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnExport.BackgroundImage = global::NFA_DFA.Properties.Resources.Export;
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnExport.Name = "btnExport";
            this.toolTip.SetToolTip(this.btnExport, resources.GetString("btnExport.ToolTip"));
            this.btnExport.UseCompatibleTextRendering = true;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.AutoEllipsis = true;
            this.btnImport.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnImport.BackgroundImage = global::NFA_DFA.Properties.Resources.Import;
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnImport.Name = "btnImport";
            this.toolTip.SetToolTip(this.btnImport, resources.GetString("btnImport.ToolTip"));
            this.btnImport.UseCompatibleTextRendering = true;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCleanUp
            // 
            this.btnCleanUp.AutoEllipsis = true;
            this.btnCleanUp.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCleanUp.BackgroundImage = global::NFA_DFA.Properties.Resources.CleanUp;
            resources.ApplyResources(this.btnCleanUp, "btnCleanUp");
            this.btnCleanUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCleanUp.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnCleanUp.Name = "btnCleanUp";
            this.toolTip.SetToolTip(this.btnCleanUp, resources.GetString("btnCleanUp.ToolTip"));
            this.btnCleanUp.UseCompatibleTextRendering = true;
            this.btnCleanUp.UseVisualStyleBackColor = false;
            this.btnCleanUp.Click += new System.EventHandler(this.btnCleanUp_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.AutoEllipsis = true;
            this.btnSolve.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSolve.BackgroundImage = global::NFA_DFA.Properties.Resources.Solve;
            resources.ApplyResources(this.btnSolve, "btnSolve");
            this.btnSolve.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolve.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnSolve.Name = "btnSolve";
            this.toolTip.SetToolTip(this.btnSolve, resources.GetString("btnSolve.ToolTip"));
            this.btnSolve.UseCompatibleTextRendering = true;
            this.btnSolve.UseVisualStyleBackColor = false;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // groupBox
            // 
            resources.ApplyResources(this.groupBox, "groupBox");
            this.groupBox.Name = "groupBox";
            this.groupBox.TabStop = false;
            // 
            // lblSigma
            // 
            resources.ApplyResources(this.lblSigma, "lblSigma");
            this.lblSigma.Name = "lblSigma";
            // 
            // lblTextAlphabet
            // 
            resources.ApplyResources(this.lblTextAlphabet, "lblTextAlphabet");
            this.lblTextAlphabet.BackColor = System.Drawing.Color.NavajoWhite;
            this.lblTextAlphabet.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextAlphabet.Name = "lblTextAlphabet";
            // 
            // lblEndSigma
            // 
            resources.ApplyResources(this.lblEndSigma, "lblEndSigma");
            this.lblEndSigma.Name = "lblEndSigma";
            // 
            // lblTextNumberOfVertex
            // 
            resources.ApplyResources(this.lblTextNumberOfVertex, "lblTextNumberOfVertex");
            this.lblTextNumberOfVertex.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblTextNumberOfVertex.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextNumberOfVertex.Name = "lblTextNumberOfVertex";
            // 
            // lblTextFinalVertex
            // 
            resources.ApplyResources(this.lblTextFinalVertex, "lblTextFinalVertex");
            this.lblTextFinalVertex.BackColor = System.Drawing.Color.Pink;
            this.lblTextFinalVertex.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextFinalVertex.Name = "lblTextFinalVertex";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblTextVector
            // 
            resources.ApplyResources(this.lblTextVector, "lblTextVector");
            this.lblTextVector.BackColor = System.Drawing.Color.PaleGreen;
            this.lblTextVector.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblTextVector.Name = "lblTextVector";
            // 
            // openFileDialogImport
            // 
            this.openFileDialogImport.DefaultExt = "txt";
            resources.ApplyResources(this.openFileDialogImport, "openFileDialogImport");
            this.openFileDialogImport.RestoreDirectory = true;
            // 
            // saveFileDialogExport
            // 
            this.saveFileDialogExport.DefaultExt = "DFA.txt";
            this.saveFileDialogExport.FileName = "DFA.txt";
            resources.ApplyResources(this.saveFileDialogExport, "saveFileDialogExport");
            // 
            // FirstForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnTypeLanda);
            this.Controls.Add(this.btnAddVector);
            this.Controls.Add(this.btnDelVector);
            this.Controls.Add(this.btnDelFinalVertex);
            this.Controls.Add(this.btnAddFinalVertex);
            this.Controls.Add(this.msktxtNumberOfVertex);
            this.Controls.Add(this.lblEndSigma);
            this.Controls.Add(this.lblTextVector);
            this.Controls.Add(this.lblTextFinalVertex);
            this.Controls.Add(this.lblTextNumberOfVertex);
            this.Controls.Add(this.lblTextAlphabet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSigma);
            this.Controls.Add(this.btnDelAlphabet);
            this.Controls.Add(this.btnAddAlphabet);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnShowGraph);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCleanUp);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.groupBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FirstForm";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Load += new System.EventHandler(this.FirstForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnCleanUp;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnShowGraph;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btnAddAlphabet;
        private System.Windows.Forms.Button btnDelAlphabet;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.Label lblTextAlphabet;
        private System.Windows.Forms.Label lblEndSigma;
        private System.Windows.Forms.Label lblTextNumberOfVertex;
        private System.Windows.Forms.MaskedTextBox msktxtNumberOfVertex;
        private System.Windows.Forms.Label lblTextFinalVertex;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddFinalVertex;
        private System.Windows.Forms.Button btnDelFinalVertex;
        private System.Windows.Forms.Label lblTextVector;
        private System.Windows.Forms.Button btnDelVector;
        private System.Windows.Forms.Button btnAddVector;
        private System.Windows.Forms.Button btnTypeLanda;
        private System.Windows.Forms.OpenFileDialog openFileDialogImport;
        private System.Windows.Forms.SaveFileDialog saveFileDialogExport;
    }
}

