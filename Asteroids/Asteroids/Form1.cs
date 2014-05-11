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
    public partial class Form1 : Form
    {
        public static readonly int WIDTH = 800;
        public static readonly int HEIGHT = 600;
        public static int Time = 180;
        public static bool MultiPlayer;
        public static int LevelDifficulty;
        public static Bitmap DebrisImage = Properties.Resources.debris2_blue;
        public static Bitmap NebulaImage = Properties.Resources.nebula_blue;
        public static Bitmap PackageTime = Properties.Resources.gift;
        public static Bitmap PackageLife = Properties.Resources.gift2;
        public static ImageInfo MissileInfo = new ImageInfo(new int[] { 5, 5 }, new int[] { 10, 10 }, 5, 50);
        public static ImageInfo AsteroidInfo = new ImageInfo(new int[] { 45, 45 }, new int[] { 90, 90 }, 40);
        public static ImageInfo ShipInfo = new ImageInfo(new int[] { 45, 45 }, new int[] { 90, 90 }, 45);
        public static ImageInfo DebrisInfo = new ImageInfo(new int[] { 320, 240 }, new int[] { 640, 480 });
        public static ImageInfo NebulaInfo = new ImageInfo(new int[] { 400, 300 }, new int[] { 800, 600 });
        public static ImageInfo ExplosionInfo = new ImageInfo(new int[] {64, 64}, new int[] {128, 128}, 64, 24, true);
        public static ImageInfo PackageInfo = new ImageInfo(new int[] { 32, 32 }, new int[] { 64, 64 }, 30);
        public static Ship Ship1;
        public static Ship Ship2;
        public static Random random = new Random();
        public float debris1PosX = 100;
        public float debris2PosX = 700;
        public static Game TheGame;
        public int Aim;
        public SoundPlayer shootSound = new SoundPlayer(Properties.Resources._146725__fins__laser);
       

        public Form1(int diff, bool multi, string p1, string p2, Bitmap s1, Bitmap st1, Bitmap s2, Bitmap st2)
        {
            InitializeComponent();
            TimerPaint.Interval = 65;
            MultiPlayer = multi;
            LevelDifficulty = diff;
            Ship1 = new Ship(new float[] { WIDTH / 2 - 100, HEIGHT - 100 }, new float[] { 0, 0 }, -90, s1, st1, ShipInfo);
            Ship2 = new Ship(new float[] { WIDTH / 2 + 100, HEIGHT - 100 }, new float[] { 0, 0 }, -90, s2, st2, ShipInfo);
            if (MultiPlayer)
            {
                TimerPaint.Interval = 90;
            }
            PackageLife.Tag = "packageLife";
            PackageTime.Tag = "packageTime";
            TheGame = new Game(MultiPlayer, LevelDifficulty, PackageLife, PackageTime, Properties.Resources.shot2, Properties.Resources.shot1, MissileInfo, Properties.Resources.ship, Properties.Resources.ship_thrust, ShipInfo, Properties.Resources.asteroid_blue, AsteroidInfo, PackageInfo, Properties.Resources.explosion_alpha, ExplosionInfo, Ship1, Ship2, p1, p2);
            TimerRockSpawn.Start();
            TimerPaint.Start();
            TheGame.MissileImage1.Tag = "player1";
            TheGame.MissileImage2.Tag = "player2";
            lblTime.Text = "03:00";
            lblTime.BackColor = Color.Transparent;
            lblTime.ForeColor = Color.White;
            lblTime.Font = new Font(lblTime.Font, FontStyle.Bold);
            TheGame.Started = true;
            labelP1.Text = p1;
            labelP2.Text = p2;
            lblTime.Location = new Point(WIDTH / 2 - 20 , 5);
            shootSound.Load();
            
        }

        /* Метод за додавање нов астероид во листата RockGroup со случајна позиција и брзина која зависи
           од бројот на поени на првиот играчот */
        public static void RockSpawner()
        {
            float[] rockPos = new float[] { random.Next(0, WIDTH), random.Next(0, HEIGHT) };
            float[] rockVel = new float[] { (float)random.NextDouble() * 0.6f - 0.3f, (float)random.NextDouble() * 0.6f - 0.3f };
            rockVel[0] *= (1 +  TheGame.Score1 / TheGame.Difficulty);
            rockVel[1] *= (1 + TheGame.Score1 / TheGame.Difficulty);
            float rockAngVel = (float)random.NextDouble() * 0.2f - 0.1f;
            if (TheGame.RockGroup.Count < 12)
                if (!TheGame.Multiplayer && AdditionalFunctions.distance(new float[] { rockPos[0] + TheGame.AsteroidInfo.Radius, rockPos[1] + TheGame.AsteroidInfo.Radius }, new float[] { TheGame.Ship1.Position[0] + TheGame.Ship1.Radius, TheGame.Ship1.Radius + TheGame.Ship1.Position[1] }) > 50)
                {

                    TheGame.RockGroup.Add(new Sprite(rockPos, rockVel, 0, rockAngVel, TheGame.AsteroidImage, TheGame.AsteroidInfo));
                }
                else if (TheGame.Multiplayer && AdditionalFunctions.distance(new float[] { rockPos[0] + TheGame.AsteroidInfo.Radius, rockPos[1] + TheGame.AsteroidInfo.Radius }, new float[] { TheGame.Ship2.Position[0] + TheGame.Ship2.Radius, TheGame.Ship2.Radius + TheGame.Ship2.Position[1] }) > 50 && AdditionalFunctions.distance(new float[] { rockPos[0] + TheGame.AsteroidInfo.Radius, rockPos[1] + TheGame.AsteroidInfo.Radius }, new float[] { TheGame.Ship1.Position[0] + TheGame.Ship1.Radius, TheGame.Ship1.Radius + TheGame.Ship1.Position[1] }) > 50)
                {
                    TheGame.RockGroup.Add(new Sprite(rockPos, rockVel, 0, rockAngVel, TheGame.AsteroidImage, TheGame.AsteroidInfo));
                }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            /* Исцртување на позадинската слика и движење на слика со вселенски отпад во позадина*/
            e.Graphics.DrawImage(NebulaImage, 0, 0, NebulaInfo.Size[0], NebulaInfo.Size[1]); 
            e.Graphics.DrawImage(DebrisImage, debris1PosX, 0, DebrisInfo.Size[0], DebrisInfo.Size[1]);
            e.Graphics.DrawImage(DebrisImage, debris2PosX, 0, DebrisInfo.Size[0], DebrisInfo.Size[1]);
            debris1PosX -= 0.5f;
            debris2PosX -= 0.5f;
           
            if (debris1PosX == -600)
                debris1PosX = 615;
            if (debris2PosX == -600)
                debris2PosX = 615;

            
            if (!TheGame.Multiplayer)
            {
                lblLives2.Visible = false;
                lblPoints2.Visible = false;
                labelP2.Visible = false;
            }

            if (TheGame.Started)
            {
                
                ProcessSpriteGroup(e.Graphics, TheGame.RockGroup);
                ProcessSpriteGroup(e.Graphics, TheGame.ExplosionGroup);

                if (TheGame.Lifes1 >= 0)
                {
                    ProcessSpriteGroup(e.Graphics, TheGame.MissileGroup1);
                    TheGame.Ship1.Draw(e.Graphics);
                    TheGame.Ship1.Update();

                    /* Проверка на услови за завршуавње на играта и намалување на бројот на животи во случај на
                       судир меѓу леталото на првиот играч и астероид */
                    if (GroupCollide(TheGame.RockGroup, TheGame.Ship1) > 0)
                    {
                        TheGame.Lifes1 -= 1;
                        if (TheGame.Lifes1 == -1)
                        {
                            lblLives1.Text = "Животи: " + 0;
                            if (TheGame.Multiplayer && TheGame.Lifes2 == -1)
                            {
                                TheGame.Started = false;
                                TimerRockSpawn.Stop();
                                ChooseToRestartMulti(false);
                            }
                            else if (!TheGame.Multiplayer)
                            {
                                TheGame.Started = false;
                                TimerRockSpawn.Stop();
                                ChooseToRestartSingle(false, TheGame.Score1);
                            }
                        }
                        else
                            lblLives1.Text = "Животи: " + TheGame.Lifes1;
                    }
                    /* Појава на пакет по постигнувае одреден број поени */
                    if (TheGame.Score1 != 0 && TheGame.Score1 % TheGame.PackageFrequency == 0 && TheGame.PackageGroup.Count < 1)
                    {
                        TheGame.PackageFrequency += 10;
                        int rand = random.Next(0, 4);
                        if (rand == 0 || rand == 1)
                        {
                            TheGame.PackageGroup.Add(new Sprite(new float[] { (float)random.Next(0, WIDTH - 10), 0 }, new float[] { 0, 0 }, 0, 0, PackageTime, PackageInfo));
                        }
                        else if (rand == 2 || rand == 3)
                            TheGame.PackageGroup.Add(new Sprite(new float[] { (float)random.Next(0, WIDTH - 10), 0 }, new float[] { 0, 0 }, 0, 0, PackageLife, PackageInfo));
                    }
                    TheGame.Score1 += GroupGroupCollide(TheGame.MissileGroup1, TheGame.RockGroup);
                    lblPoints1.Text = "Поени: " + TheGame.Score1;
                   
                }
                /* Проверка на услови за завршуавње на играта и намалување на бројот на животи во случај на
                       судир меѓу леталото на вториот играч и астероид */
                if (TheGame.Multiplayer && TheGame.Lifes2 >= 0)
                {
                    ProcessSpriteGroup(e.Graphics, TheGame.MissileGroup2);
                    TheGame.Ship2.Draw(e.Graphics);
                    TheGame.Ship2.Update();
                    if (GroupCollide(TheGame.RockGroup, TheGame.Ship2) > 0)
                    {
                        TheGame.Lifes2 -= 1;
                        if (TheGame.Lifes2 == -1 && TheGame.Lifes1 == -1)
                        {
                            lblLives2.Text = "Животи: " + 0;
                            TheGame.Started = false;
                            TimerRockSpawn.Stop();
                            ChooseToRestartMulti(false);
                        }
                        else if (TheGame.Lifes2 == -1)
                            lblLives2.Text = "Животи: " + 0;
                        else
                            lblLives2.Text = "Животи: " + TheGame.Lifes2;

                    }
                    TheGame.Score2 += GroupGroupCollide(TheGame.MissileGroup2, TheGame.RockGroup);
                    lblPoints2.Text = "Поени: " + TheGame.Score2;
                    
                }

                /* Појава на пакет по постигнувае одреден број поени */
                if (TheGame.Score2 != 0 && TheGame.Score2 % TheGame.PackageFrequency == 0 && TheGame.PackageGroup.Count < 1)
                {
                    TheGame.PackageFrequency += 10;
                    int rand = random.Next(0, 5);
                    if (rand % 2 == 0)
                    {

                        TheGame.PackageGroup.Add(new Sprite(new float[] { (float)random.Next(0, WIDTH - 10), 0 }, new float[] { 0, 0 }, 0, 0, Properties.Resources.gift, PackageInfo));

                    }
                    else
                        TheGame.PackageGroup.Add(new Sprite(new float[] { (float)random.Next(0, WIDTH - 10), 0 }, new float[] { 0, 0 }, 0, 0, Properties.Resources.gift2, PackageInfo));
                }

                ProcessPackageGroup(e.Graphics, TheGame.PackageGroup);
                

            }
            
        }

        /* Ажурирање на секој од објектите во листата проследена како аргумент */
        public void ProcessSpriteGroup(Graphics g, List<Sprite> group)
        {

            for (int i = group.Count - 1; i >= 0; i--)
            {
                group.ElementAt(i).Draw(g);
                if (group.ElementAt(i).Update())
                    group.RemoveAt(i);
            }
        }

        /* Придвижување на пакет и проверка дали се судира со некое од леталата и соодветно ажурирање на времето или животите,
           во зависност од видот, или пак излегува надвор од границите на прозорецот */
        public void ProcessPackageGroup(Graphics g, List<Sprite> group)
        {

            for (int i = group.Count - 1; i >= 0; i--)
            {
                Sprite s = group.ElementAt(i);
                
                float y = s.Position[1] + 1;
                group.ElementAt(i).Position[1] = y;
                group.ElementAt(i).Draw(g);
                if (group.ElementAt(i).Collide(TheGame.Ship1))
                {
                    if (group.ElementAt(i).Image.Tag == "packageTime")
                        Time += 5;
                    else
                    {
                        TheGame.Lifes1 += 1;
                        lblLives1.Text = "Животи: " + TheGame.Lifes1;
                    }
                   
                    group.RemoveAt(i);
                }
                else if (TheGame.Multiplayer && group.ElementAt(i).Collide(Ship2))
                {
                    if (group.ElementAt(i).Image.Tag == "packageTime")
                        Time += 5;
                    else
                    {
                        TheGame.Lifes2 += 1;
                        lblLives2.Text = "Животи: " + TheGame.Lifes2;
                    }
                    group.RemoveAt(i);
                }
                else if (y >= 600)
                    group.RemoveAt(i);
                
            }
        }

        /* Контроли за управување со леталата */
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                TheGame.Ship1.Thrust = true;
            else if (e.KeyCode == Keys.Left)
                TheGame.Ship1.decrement_ang_vel();
            else if (e.KeyCode == Keys.Right)
                TheGame.Ship1.increment_ang_vel();
            if (e.KeyCode == Keys.Space)
            {
                TheGame.Ship1.Shoot(TheGame.MissileImage1);
                shootSound.Play();
            }

            if (MultiPlayer)
            {
                if (e.KeyCode == Keys.W)
                    TheGame.Ship2.Thrust = true;
                else if (e.KeyCode == Keys.D)
                    TheGame.Ship2.increment_ang_vel();
                else if (e.KeyCode == Keys.A)
                    TheGame.Ship2.decrement_ang_vel();
                if (e.KeyCode == Keys.F)
                {
                    TheGame.Ship2.Shoot(TheGame.MissileImage2);
                    shootSound.Play();
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                TheGame.Ship1.AngleVelocity = 0;
            else if (e.KeyCode == Keys.Right)
                TheGame.Ship1.AngleVelocity = 0;
            else if (e.KeyCode == Keys.Up)
                TheGame.Ship1.Thrust = false;

            if (TheGame.Multiplayer)
            {
                if (e.KeyCode == Keys.A)
                    TheGame.Ship2.AngleVelocity = 0;
                else if (e.KeyCode == Keys.D)
                    TheGame.Ship2.AngleVelocity = 0;
                else if (e.KeyCode == Keys.W)
                    TheGame.Ship2.Thrust = false;
            }
        }

        private void TimerPaint_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        /* Повик на методот за додавање астероиди во листата и проверка за истекување на времето. 
           Доколку времето истече се повикува функција која нуди можност за рестартирање на играта */
        private void TimerRockSpawn_Tick(object sender, EventArgs e)
        {
            RockSpawner();
            Time -= 1;
            int minutes = Time / 60;
            int seconds = Time % 60;
            if (seconds < 10)
                lblTime.Text = "0" + minutes + ":" + "0" + seconds;
            else
                lblTime.Text = "0" + minutes + ":" + seconds;
            if (Time == 0 && !MultiPlayer && TheGame.Score1 >= TheGame.GameAim())
            {
                TheGame.Started = false;
                TimerRockSpawn.Stop();
                ChooseToRestartSingle(true, TheGame.Score1);
            }
            else if (Time == 0 && !TheGame.Multiplayer && TheGame.Score1 < TheGame.GameAim())
            {
                TheGame.Started = false;
                TimerRockSpawn.Stop();
                ChooseToRestartSingle(false, TheGame.Score1);
            }
            else if (Time == 0 && TheGame.Multiplayer)
            {
                TheGame.Started = false;
                TimerRockSpawn.Stop();
                ChooseToRestartMulti(true);
            }
        }

        /* Проверка за судир меѓу секој од елементите од листата и соодветниот објект */
        private int GroupCollide(List<Sprite> group, object obj)
        {
            int total = 0;
            for(int i = group.Count - 1; i>=0; i--)
                if(group.ElementAt(i).Collide(obj))
                {
                    TheGame.ExplosionGroup.Add(new Sprite(group.ElementAt(i).Position, new float[] {0,0},0,0,TheGame.ExplosionImage,ExplosionInfo));
                    group.RemoveAt(i);
                    total += 1;
                }
            return total;

        }

        /* Проверка за судир меѓу елементите од двете листи */
        private int GroupGroupCollide(List<Sprite> group1, List<Sprite> group2)
        {
            int total = 0;
            int collided = 0;
            for (int i = group1.Count - 1; i >= 0; i--)
            {
                collided = GroupCollide(group2, group1.ElementAt(i));
                if (collided > 0)
                {
                    group1.RemoveAt(i);
                 
                    
                }
                total += collided;
            }
            return total;
        }

        /* Појава на прозорец со можност за рестарирање на играта и порака која зависи од постигнатиот резултат */
        private void ChooseToRestartSingle(bool Success, int Points)
        {
            DialogResult dr = DialogResult.None;
            if (Success)
                dr = MessageBox.Show("Честитки! Освоивте " + Points + " од минимум " + TheGame.GameAim() + " поени. Дали сакате да играте повторно?", "Играј повторно?", MessageBoxButtons.YesNo);
            
            else if (!Success && TheGame.Lifes1 == -1)
            {
                dr = MessageBox.Show("Играта заврши! За жал ги изгубивте сите животи. Дали сакате да се обидете повторно?", "Играј повторно?", MessageBoxButtons.YesNo);
            }
            else if (!Success)
                dr = MessageBox.Show("Играта заврши! За жал не го освоивте потребниот број поени. Освоивте " + Points + " од минимум " + TheGame.GameAim() + " поени. Дали сакате да се обидете повторно?", "Играј повторно?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                TheGame.RestartGame();
                TimerRockSpawn.Start();
                Time = 180;
                lblTime.Text = "03:00";
                lblLives1.Text = "Животи: " + TheGame.Lifes1;
                lblLives2.Text = "Животи: " + TheGame.Lifes2;
                lblPoints1.Text = "Поени: " + TheGame.Score1;
                lblPoints2.Text = "Поени: " + TheGame.Score2;

            }
            else if (dr == DialogResult.No)
                this.Close();
        }

        public void ChooseToRestartMulti(bool Success)
        {
            DialogResult dr = DialogResult.None;
            if (Success && TheGame.Score1 > TheGame.Score2)
            {
                dr = MessageBox.Show("Играта заврши! Победник е " + TheGame.Player1 + ". Дали сакате да играте повторно?", "Играј повторно?", MessageBoxButtons.YesNo);
            }
            else if (Success && TheGame.Score1 < TheGame.Score2)
            {
                dr = MessageBox.Show("Играта заврши! Победник е " + TheGame.Player2 + ". Дали сакате да играте повторно?", "Играј повторно?", MessageBoxButtons.YesNo);
            }
            else if (Success && TheGame.Score1 == TheGame.Score2)
            {
                dr = MessageBox.Show("Играта заврши нерешено! Дали саката да играте повторно?", "Играј повторно?", MessageBoxButtons.YesNo);
            }
            else if (!Success)
            {
                dr = MessageBox.Show("Играта заврши без победник! Дали сакате да играте повторно?", "Играј повторно?", MessageBoxButtons.YesNo);
            }
            if (dr == DialogResult.Yes)
            {
                TheGame.RestartGame();
                TimerRockSpawn.Start();
                Time = 180;
                lblTime.Text = "03:00";
                lblLives1.Text = "Животи: " + TheGame.Lifes1;
                lblLives2.Text = "Животи: " + TheGame.Lifes2;
                lblPoints1.Text = "Поени: " + TheGame.Score1;
                lblPoints2.Text = "Поени: " + TheGame.Score2;

            }
            else if (dr == DialogResult.No)
                this.Close();
        }

        
    }
}
