using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButtonEasy.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int difficulty;
            Bitmap ship1 = null;
            Bitmap ship2 = null;
            Bitmap ship1t = null;
            Bitmap ship2t = null;
            bool multi = !radioButton1.Checked;
            if (radioButtonEasy.Checked)
                difficulty = 3;
            else if (radioButtonMedium.Checked)
                difficulty = 2;
            else
                difficulty = 1;
            if (radioButtonShip1.Checked)
            {
                ship1 = Properties.Resources.ship;
                ship1t = Properties.Resources.ship_thrust;
            }
            else if (radioButtonShip2.Checked)
            {
                ship1 = Properties.Resources.ship2;
                ship1t = Properties.Resources.ship_thrust2;
            }
            if (radioButtonShip12.Checked)
            {
                ship2 = Properties.Resources.ship;
                ship2t = Properties.Resources.ship_thrust;
            }
            else if (radioButtonShip22.Checked)
            {
                ship2 = Properties.Resources.ship2;
                ship2t = Properties.Resources.ship_thrust2;
            }
            MainMenu.player.Stop();
            Form1 f = new Form1(difficulty, multi, textBox1.Text, textBox2.Text,ship1, ship1t,ship2,ship2t);
            this.Hide();
            f.ShowDialog();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                groupBox4.Visible = false;
            else
                groupBox4.Visible = true;
        }
    }
}
