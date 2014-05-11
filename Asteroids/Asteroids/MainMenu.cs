using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Asteroids
{
    public partial class MainMenu : Form
    {
        private Bitmap Background = Properties.Resources.menubg;
        private Point ShipPos = new Point(0, 0);
        private Point DebrisPos = new Point(600, 0);
        private Point LogoPos = new Point(-600, 0);
        private Point NewGamePos = new Point(160, 340);
        private Point InstructionsPos = new Point(139, 408);
        private Point ExitPos = new Point(216, 476);
        private int move = -1;
        public static SoundPlayer player = new SoundPlayer(Properties.Resources._178368__alaupas__space_7);
        public MainMenu()
        {
            InitializeComponent();
            timer1.Start();
            newGame.Location = NewGamePos;
            instructions.Location = InstructionsPos;
            exit.Location = ExitPos;
            player.PlayLooping();
        }

        private void MainMenu_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Background, 0, 0, 800, 600);
            e.Graphics.DrawImage(Properties.Resources.debris2_blue, DebrisPos.X, DebrisPos.Y, 640, 480);
            e.Graphics.DrawImage(Properties.Resources.shipMenu, ShipPos.X, ShipPos.Y, 800, 600);
            e.Graphics.DrawImage(Properties.Resources.logo, LogoPos.X, 0, 800, 600);
            animateBg();
            animateShip();
            animateLogo();
            ;
            
        }
        // Придвижување на различни елементи од менито, движење на вселенскиот брод горе-долу, движење на позадината и анимација на логото
        private void animateShip()
        {
            ShipPos.Y += move;
            if (ShipPos.Y == -50)
                move = 1;
            if (ShipPos.Y == 0)
                move = -1;
        }

        private void animateBg()
        {
            DebrisPos.X -= 1;
            if (DebrisPos.X == -640)
                DebrisPos.X = 600;

        }

        private void animateLogo()
        {
            if (LogoPos.X <= 0)
                LogoPos.X += 30;
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        // Прикажување на нова слика при придвижување на глушецот над секоја од опциите
        private void newGame_MouseHover(object sender, EventArgs e)
        {
            newGame.Image = Properties.Resources.newGameGlow;
        }

        private void instructions_MouseHover(object sender, EventArgs e)
        {
            instructions.Image = Properties.Resources.instructionsGlow;
        }

        private void newGame_MouseLeave(object sender, EventArgs e)
        {
            newGame.Image = Properties.Resources.newGame;
        }

        private void instructions_MouseLeave(object sender, EventArgs e)
        {
            instructions.Image = Properties.Resources.instructions;
        }

        private void exit_MouseHover(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.exitGlow;
        }

        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.Image = Properties.Resources.exit;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Дали сте сигурни дека сакате да ја напуштите играта?", "Излез", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            NewGame n = new NewGame();
            this.Hide();
            n.ShowDialog();
            this.Close();
            
        }

        private void instructions_Click(object sender, EventArgs e)
        {
            Instructions i = new Instructions();
            i.Show();
        }

    }
}
