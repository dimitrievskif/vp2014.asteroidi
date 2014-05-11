namespace Asteroids
{
    partial class Form1
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
            this.TimerPaint = new System.Windows.Forms.Timer(this.components);
            this.TimerRockSpawn = new System.Windows.Forms.Timer(this.components);
            this.lblLives1 = new System.Windows.Forms.Label();
            this.lblPoints1 = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblPoints2 = new System.Windows.Forms.Label();
            this.lblLives2 = new System.Windows.Forms.Label();
            this.labelP1 = new System.Windows.Forms.Label();
            this.labelP2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TimerPaint
            // 
            this.TimerPaint.Interval = 33;
            this.TimerPaint.Tick += new System.EventHandler(this.TimerPaint_Tick);
            // 
            // TimerRockSpawn
            // 
            this.TimerRockSpawn.Interval = 1000;
            this.TimerRockSpawn.Tick += new System.EventHandler(this.TimerRockSpawn_Tick);
            // 
            // lblLives1
            // 
            this.lblLives1.AutoSize = true;
            this.lblLives1.BackColor = System.Drawing.Color.Transparent;
            this.lblLives1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLives1.ForeColor = System.Drawing.Color.White;
            this.lblLives1.Location = new System.Drawing.Point(12, 30);
            this.lblLives1.Name = "lblLives1";
            this.lblLives1.Size = new System.Drawing.Size(68, 13);
            this.lblLives1.TabIndex = 0;
            this.lblLives1.Text = "Животи: 3";
            // 
            // lblPoints1
            // 
            this.lblPoints1.AutoSize = true;
            this.lblPoints1.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPoints1.ForeColor = System.Drawing.Color.White;
            this.lblPoints1.Location = new System.Drawing.Point(12, 45);
            this.lblPoints1.Name = "lblPoints1";
            this.lblPoints1.Size = new System.Drawing.Size(59, 13);
            this.lblPoints1.TabIndex = 1;
            this.lblPoints1.Text = "Поени: 0";
            
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(356, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 13);
            this.lblTime.TabIndex = 2;
            // 
            // lblPoints2
            // 
            this.lblPoints2.AutoSize = true;
            this.lblPoints2.BackColor = System.Drawing.Color.Transparent;
            this.lblPoints2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPoints2.ForeColor = System.Drawing.Color.White;
            this.lblPoints2.Location = new System.Drawing.Point(709, 45);
            this.lblPoints2.Name = "lblPoints2";
            this.lblPoints2.Size = new System.Drawing.Size(59, 13);
            this.lblPoints2.TabIndex = 4;
            this.lblPoints2.Text = "Поени: 0";
            // 
            // lblLives2
            // 
            this.lblLives2.AutoSize = true;
            this.lblLives2.BackColor = System.Drawing.Color.Transparent;
            this.lblLives2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLives2.ForeColor = System.Drawing.Color.White;
            this.lblLives2.Location = new System.Drawing.Point(709, 30);
            this.lblLives2.Name = "lblLives2";
            this.lblLives2.Size = new System.Drawing.Size(68, 13);
            this.lblLives2.TabIndex = 3;
            this.lblLives2.Text = "Животи: 3";
            // 
            // labelP1
            // 
            this.labelP1.AutoSize = true;
            this.labelP1.BackColor = System.Drawing.Color.Transparent;
            this.labelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelP1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelP1.Location = new System.Drawing.Point(12, 9);
            this.labelP1.Name = "labelP1";
            this.labelP1.Size = new System.Drawing.Size(41, 13);
            this.labelP1.TabIndex = 5;
            this.labelP1.Text = "label1";
            // 
            // labelP2
            // 
            this.labelP2.AutoSize = true;
            this.labelP2.BackColor = System.Drawing.Color.Transparent;
            this.labelP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelP2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelP2.Location = new System.Drawing.Point(709, 9);
            this.labelP2.Name = "labelP2";
            this.labelP2.Size = new System.Drawing.Size(41, 13);
            this.labelP2.TabIndex = 6;
            this.labelP2.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 600);
            this.Controls.Add(this.labelP2);
            this.Controls.Add(this.labelP1);
            this.Controls.Add(this.lblPoints2);
            this.Controls.Add(this.lblLives2);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblPoints1);
            this.Controls.Add(this.lblLives1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Астероиди";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimerPaint;
        private System.Windows.Forms.Label lblLives1;
        private System.Windows.Forms.Label lblPoints1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblPoints2;
        private System.Windows.Forms.Label lblLives2;
        private System.Windows.Forms.Timer TimerRockSpawn;
        private System.Windows.Forms.Label labelP1;
        private System.Windows.Forms.Label labelP2;
    }
}

