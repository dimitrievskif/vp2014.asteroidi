namespace Asteroids
{
    partial class MainMenu
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.exit = new System.Windows.Forms.PictureBox();
            this.instructions = new System.Windows.Forms.PictureBox();
            this.newGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGame)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 33;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Image = global::Asteroids.Properties.Resources.exit;
            this.exit.Location = new System.Drawing.Point(216, 474);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(192, 57);
            this.exit.TabIndex = 2;
            this.exit.TabStop = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            this.exit.MouseLeave += new System.EventHandler(this.exit_MouseLeave);
            this.exit.MouseHover += new System.EventHandler(this.exit_MouseHover);
            // 
            // instructions
            // 
            this.instructions.BackColor = System.Drawing.Color.Transparent;
            this.instructions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.instructions.Image = global::Asteroids.Properties.Resources.instructions;
            this.instructions.Location = new System.Drawing.Point(139, 408);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(345, 60);
            this.instructions.TabIndex = 1;
            this.instructions.TabStop = false;
            this.instructions.Click += new System.EventHandler(this.instructions_Click);
            this.instructions.MouseLeave += new System.EventHandler(this.instructions_MouseLeave);
            this.instructions.MouseHover += new System.EventHandler(this.instructions_MouseHover);
            // 
            // newGame
            // 
            this.newGame.BackColor = System.Drawing.Color.Transparent;
            this.newGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newGame.Image = global::Asteroids.Properties.Resources.newGame;
            this.newGame.Location = new System.Drawing.Point(160, 340);
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(299, 62);
            this.newGame.TabIndex = 0;
            this.newGame.TabStop = false;
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            this.newGame.MouseLeave += new System.EventHandler(this.newGame_MouseLeave);
            this.newGame.MouseHover += new System.EventHandler(this.newGame_MouseHover);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 600);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.newGame);
            this.DoubleBuffered = true;
            this.Name = "MainMenu";
            this.Text = "Главно мени";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainMenu_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instructions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox newGame;
        private System.Windows.Forms.PictureBox instructions;
        private System.Windows.Forms.PictureBox exit;
    }
}