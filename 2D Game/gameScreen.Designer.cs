namespace _2D_Game
{
    partial class gameScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameLoop = new System.Windows.Forms.Timer(this.components);
            this.greenHeroPictureBox = new System.Windows.Forms.PictureBox();
            this.redHeroPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.greenHeroPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redHeroPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // gameLoop
            // 
            this.gameLoop.Enabled = true;
            this.gameLoop.Interval = 20;
            this.gameLoop.Tick += new System.EventHandler(this.gameLoop_Tick);
            // 
            // greenHeroPictureBox
            // 
            this.greenHeroPictureBox.Image = global::_2D_Game.Properties.Resources.Green_Forward;
            this.greenHeroPictureBox.Location = new System.Drawing.Point(3, 483);
            this.greenHeroPictureBox.MaximumSize = new System.Drawing.Size(20, 20);
            this.greenHeroPictureBox.MinimumSize = new System.Drawing.Size(20, 20);
            this.greenHeroPictureBox.Name = "greenHeroPictureBox";
            this.greenHeroPictureBox.Size = new System.Drawing.Size(20, 20);
            this.greenHeroPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenHeroPictureBox.TabIndex = 0;
            this.greenHeroPictureBox.TabStop = false;
            // 
            // redHeroPictureBox
            // 
            this.redHeroPictureBox.Location = new System.Drawing.Point(1137, 3);
            this.redHeroPictureBox.MaximumSize = new System.Drawing.Size(20, 20);
            this.redHeroPictureBox.MinimumSize = new System.Drawing.Size(20, 20);
            this.redHeroPictureBox.Name = "redHeroPictureBox";
            this.redHeroPictureBox.Size = new System.Drawing.Size(20, 20);
            this.redHeroPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redHeroPictureBox.TabIndex = 1;
            this.redHeroPictureBox.TabStop = false;
            // 
            // gameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.redHeroPictureBox);
            this.Controls.Add(this.greenHeroPictureBox);
            this.DoubleBuffered = true;
            this.Name = "gameScreen";
            this.Size = new System.Drawing.Size(1170, 506);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.greenHeroPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redHeroPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameLoop;
        private System.Windows.Forms.PictureBox greenHeroPictureBox;
        private System.Windows.Forms.PictureBox redHeroPictureBox;
    }
}
