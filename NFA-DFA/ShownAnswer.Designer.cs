namespace NFA_DFA
{
    partial class ShownAnswer
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
            this.rtxtShownExportFile = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // rtxtShownExportFile
            // 
            this.rtxtShownExportFile.AutoWordSelection = true;
            this.rtxtShownExportFile.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.rtxtShownExportFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtShownExportFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtxtShownExportFile.DetectUrls = false;
            this.rtxtShownExportFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtShownExportFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rtxtShownExportFile.Location = new System.Drawing.Point(0, 0);
            this.rtxtShownExportFile.Name = "rtxtShownExportFile";
            this.rtxtShownExportFile.ReadOnly = true;
            this.rtxtShownExportFile.ShortcutsEnabled = false;
            this.rtxtShownExportFile.Size = new System.Drawing.Size(398, 328);
            this.rtxtShownExportFile.TabIndex = 0;
            this.rtxtShownExportFile.Text = "";
            this.toolTip1.SetToolTip(this.rtxtShownExportFile, "Click Once To Close Window");
            this.rtxtShownExportFile.Click += new System.EventHandler(this.rtxtShownExportFile_Click);
            // 
            // ShownAnswer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(398, 328);
            this.ControlBox = false;
            this.Controls.Add(this.rtxtShownExportFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ShownAnswer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.ShownAnswer_Load);
            this.Click += new System.EventHandler(this.ShownAnswer_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtShownExportFile;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}