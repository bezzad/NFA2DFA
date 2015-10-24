namespace NFA_DFA
{
    partial class DrawGraph
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawGraph));
            this.lblTextWord = new System.Windows.Forms.Label();
            this.lineShapeBetween = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.SuspendLayout();
            // 
            // lblTextWord
            // 
            this.lblTextWord.AutoSize = true;
            this.lblTextWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTextWord.Location = new System.Drawing.Point(3, 11);
            this.lblTextWord.Name = "lblTextWord";
            this.lblTextWord.Size = new System.Drawing.Size(114, 16);
            this.lblTextWord.TabIndex = 5;
            this.lblTextWord.Text = "Alphabet Words : ";
            // 
            // lineShapeBetween
            // 
            this.lineShapeBetween.Enabled = false;
            this.lineShapeBetween.Name = "lineShapeBetween";
            this.lineShapeBetween.X1 = 1;
            this.lineShapeBetween.X2 = 3000;
            this.lineShapeBetween.Y1 = 39;
            this.lineShapeBetween.Y2 = 39;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShapeBetween});
            this.shapeContainer1.Size = new System.Drawing.Size(3000, 3000);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // DrawGraph
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Graphic;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(3000, 3000);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.lblTextWord);
            this.Controls.Add(this.shapeContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DrawGraph";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DFA Graph";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DrawGraph_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTextWord;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShapeBetween;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;


    }
}