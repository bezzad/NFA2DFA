namespace NFA_DFA
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.picSite = new System.Windows.Forms.PictureBox();
            this.picCopyright = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picSite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCopyright)).BeginInit();
            this.SuspendLayout();
            // 
            // picSite
            // 
            this.picSite.BackgroundImage = global::NFA_DFA.Properties.Resources.Web;
            this.picSite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picSite.ErrorImage = null;
            this.picSite.Location = new System.Drawing.Point(8, 11);
            this.picSite.Name = "picSite";
            this.picSite.Size = new System.Drawing.Size(458, 149);
            this.picSite.TabIndex = 0;
            this.picSite.TabStop = false;
            this.toolTip1.SetToolTip(this.picSite, "Goto site www.Azerbaycan.ir");
            this.picSite.Click += new System.EventHandler(this.picSite_Click);
            // 
            // picCopyright
            // 
            this.picCopyright.BackgroundImage = global::NFA_DFA.Properties.Resources.Copyright;
            this.picCopyright.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picCopyright.Location = new System.Drawing.Point(-1, 291);
            this.picCopyright.Name = "picCopyright";
            this.picCopyright.Size = new System.Drawing.Size(477, 164);
            this.picCopyright.TabIndex = 1;
            this.picCopyright.TabStop = false;
            this.toolTip1.SetToolTip(this.picCopyright, "Click to close window");
            this.picCopyright.Click += new System.EventHandler(this.picCopyright_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "V 2.0";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(474, 453);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCopyright);
            this.Controls.Add(this.picSite);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.toolTip1.SetToolTip(this, "Click to close window");
            this.TopMost = true;
            this.Click += new System.EventHandler(this.FormAbout_Click);
            ((System.ComponentModel.ISupportInitialize)(this.picSite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCopyright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSite;
        private System.Windows.Forms.PictureBox picCopyright;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;

    }
}