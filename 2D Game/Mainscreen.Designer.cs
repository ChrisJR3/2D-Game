namespace _2D_Game
{
    partial class Mainscreen
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
            this.startGameButton_1 = new System.Windows.Forms.Button();
            this.titleLabel_3 = new System.Windows.Forms.Label();
            this.titleLabel_2 = new System.Windows.Forms.Label();
            this.titleLabel_1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startGameButton_1
            // 
            this.startGameButton_1.BackColor = System.Drawing.Color.Transparent;
            this.startGameButton_1.Font = new System.Drawing.Font("Millenium BdEx BT", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton_1.ForeColor = System.Drawing.Color.Olive;
            this.startGameButton_1.Location = new System.Drawing.Point(494, 272);
            this.startGameButton_1.Name = "startGameButton_1";
            this.startGameButton_1.Size = new System.Drawing.Size(329, 49);
            this.startGameButton_1.TabIndex = 7;
            this.startGameButton_1.Text = "START GAME?";
            this.startGameButton_1.UseVisualStyleBackColor = false;
            this.startGameButton_1.Click += new System.EventHandler(this.StartGameButton_1_Click);
            // 
            // titleLabel_3
            // 
            this.titleLabel_3.AutoSize = true;
            this.titleLabel_3.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel_3.Font = new System.Drawing.Font("Millenium BdEx BT", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel_3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.titleLabel_3.Location = new System.Drawing.Point(781, 100);
            this.titleLabel_3.Name = "titleLabel_3";
            this.titleLabel_3.Size = new System.Drawing.Size(155, 124);
            this.titleLabel_3.TabIndex = 6;
            this.titleLabel_3.Text = "N";
            // 
            // titleLabel_2
            // 
            this.titleLabel_2.AutoSize = true;
            this.titleLabel_2.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel_2.Font = new System.Drawing.Font("Millenium BdEx BT", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel_2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.titleLabel_2.Location = new System.Drawing.Point(507, 100);
            this.titleLabel_2.Name = "titleLabel_2";
            this.titleLabel_2.Size = new System.Drawing.Size(145, 124);
            this.titleLabel_2.TabIndex = 5;
            this.titleLabel_2.Text = "O";
            // 
            // titleLabel_1
            // 
            this.titleLabel_1.AutoSize = true;
            this.titleLabel_1.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel_1.Font = new System.Drawing.Font("Millenium BdEx BT", 72F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel_1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.titleLabel_1.Location = new System.Drawing.Point(376, 100);
            this.titleLabel_1.Name = "titleLabel_1";
            this.titleLabel_1.Size = new System.Drawing.Size(421, 124);
            this.titleLabel_1.TabIndex = 4;
            this.titleLabel_1.Text = "T    R";
            // 
            // Mainscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls.Add(this.startGameButton_1);
            this.Controls.Add(this.titleLabel_3);
            this.Controls.Add(this.titleLabel_2);
            this.Controls.Add(this.titleLabel_1);
            this.Name = "Mainscreen";
            this.Size = new System.Drawing.Size(1185, 546);
            this.Load += new System.EventHandler(this.Mainscreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGameButton_1;
        private System.Windows.Forms.Label titleLabel_3;
        private System.Windows.Forms.Label titleLabel_2;
        private System.Windows.Forms.Label titleLabel_1;
    }
}
