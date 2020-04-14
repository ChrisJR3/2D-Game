using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace _2D_Game
{
    public partial class gameScreen : UserControl
    {
        //Brushes
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush greenHeroBrush = new SolidBrush(Color.White);
        SolidBrush redHeroBrush = new SolidBrush(Color.Black);
        SolidBrush penBrush = new SolidBrush(Color.Blue);

        //Pens
        Font winnerFont = new Font("Old Standard TT", 16, FontStyle.Bold);

        //creating variables that apply to both players
        public static int playerSpeed = 5;
        int boxSize = 20;
        int p1X, p1Y, p2X, p2Y;
        int wallWidth = 3;
        int timer = 30000;
        int secondsLeft;
        string p1Direction = "up";
        string p2Direction = "down";
        string endGame;
        
        //Walls
        Rectangle wall1;
        Rectangle wall2;
        Rectangle wall3;
        Rectangle wall4;

        //Sounds
        SoundPlayer bikes = new SoundPlayer(Properties.Resources.Bike_Sound);
        SoundPlayer crash = new SoundPlayer(Properties.Resources.Crash);
        SoundPlayer tie = new SoundPlayer(Properties.Resources.Tie1);
        SoundPlayer start = new SoundPlayer(Properties.Resources.GameStart);

        //creating the characters in the movement class
        movement greenHero;
        movement redHero;

        public gameScreen()
        {
            InitializeComponent();
            onStart();
        }

        public void onStart()
        {
            //set intial values
            p1X = 20;
            p1Y = this.Height - 50;
            p2X = this.Width - 50;
            p2Y = 20;

            //creating the lists for each hero
            greenHero = new movement(p1X, p1Y, boxSize, playerSpeed);
            redHero = new movement(p2X, p2Y, boxSize, playerSpeed);

            //Making the walls
            wall1 = new Rectangle(0, 0, this.Width, wallWidth);
            wall2 = new Rectangle(this.Width, 0, -wallWidth, this.Height);
            wall3 = new Rectangle(0, this.Height, this.Width, -wallWidth);
            wall4 = new Rectangle(0, 0, wallWidth, this.Height);

            //Creates graphics
            Graphics e = this.CreateGraphics();

            Cursor.Hide(); //hides cursor            
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Green rider button presses (Player 1)
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (p1Direction != "down") { p1Direction = "up"; }
                    break;
                case Keys.A:
                    if (p1Direction != "right") { p1Direction = "left"; }
                    break;
                case Keys.S:
                    if (p1Direction != "up") { p1Direction = "down"; }
                    break;
                case Keys.D:
                    if (p1Direction != "left") { p1Direction = "right"; }
                    break;
            }

            //Red rider button presses (Player 2)
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (p2Direction != "down") { p2Direction = "up"; }
                    break;
                case Keys.Left:
                    if (p2Direction != "right") { p2Direction = "left"; }
                    break;
                case Keys.Down:
                    if (p2Direction != "up") { p2Direction = "down"; }
                    break;
                case Keys.Right:
                    if (p2Direction != "left") { p2Direction = "right"; }
                    break;
            }
        }

        private void gameScreen_KeyDown(object sender, KeyEventArgs e){}

        private void gameScreen_KeyUp(object sender, KeyEventArgs e){}

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //Decreases timer
            timer = timer - 31;
            secondsLeft = timer / 1000;
            
            //moving the Green rider (Player 1)
            greenHero.Move(p1Direction);

            //moving the Red rider (Player 2)
            redHero.Move(p2Direction);

            //Making the collision boxes
            Rectangle greenHeroRec = new Rectangle(greenHero.x, greenHero.y, greenHero.size, greenHero.size);
            Rectangle redHeroRec = new Rectangle(redHero.x, redHero.y, redHero.size, redHero.size);

            //Collision statement
            greenHero.Collision(greenHeroRec, redHeroRec, p1Direction, p2Direction, greenHero.x, greenHero.y, greenHero.size, greenHero.playerTrail, redHero.x, redHero.y, redHero.size, redHero.playerTrail, wall1, wall2, wall3, wall4, endGame);

            //if the game has ended:
            if (endGame == "")
            {
               
            }
            else
            {
               gameOver(endGame);
            }

            //if timer reaches 0
            if (timer <= 0)
            {
                gameOver("Tie");
                return;
            }

            //Playing bike sounds
            if (secondsLeft == 30 || secondsLeft == 12)
            {
                bikes.Play();
            }

            //Moving the image boxes
            greenHeroPictureBox.Location = new Point (greenHero.x, greenHero.y);
            redHeroPictureBox.Location = new Point(redHero.x, redHero.y);

            Refresh();
        }

        public void gameOver(string winner)
        {
            //Creates graphics
            Graphics e = this.CreateGraphics();

            //Stops the game loop
            gameLoop.Enabled = false;

            //if greenHero (P1) wins
            if (winner == "Green Rider")
            {
                e.DrawString("Green Rider Wins!", winnerFont, penBrush, this.Width/2 - 10, this.Height/2);
                crash.Play();
            }

            //if redHero (P2) wins
            else if (winner == "Red Rider")
            {
                e.DrawString("Red Rider Wins!", winnerFont, penBrush, this.Width / 2 - 10, this.Height / 2);
                crash.Play();
            }

            //if it is a tie
            else
            {
                e.DrawString("It's a tie!", winnerFont, penBrush, this.Width / 2 - 10, this.Height / 2);
                tie.Play();
            }

            Thread.Sleep(2000);

            //Close gameScreen and reopen Mainscreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            Mainscreen ms = new Mainscreen();
            f.Controls.Add(ms);
            ms.Focus();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            start.Play();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Green trail
            foreach (Point t in greenHero.playerTrail) {e.Graphics.FillRectangle(greenBrush, t.X, t.Y, greenHero.size/2, greenHero.size/2);}

            //Red trail
            foreach (Point t in redHero.playerTrail) {e.Graphics.FillRectangle(redBrush, t.X, t.Y, redHero.size/2, redHero.size/2);}

            //Green hero (p1)
            if (p1Direction == "up")
            {
                greenHeroPictureBox.Image = Properties.Resources.Green_Forward;
            }
            else if (p1Direction == "right")
            {
                greenHeroPictureBox.Image = Properties.Resources.Green_Right;
            }
            else if (p1Direction == "down")
            {
                greenHeroPictureBox.Image = Properties.Resources.Green_Down;
            }
            else if (p1Direction == "left")
            {
                greenHeroPictureBox.Image = Properties.Resources.Green_Left;
            }

            //Red hero (p2)
            //e.Graphics.FillRectangle(redHeroBrush, redHero.x, redHero.y, redHero.size, redHero.size);
            if (p2Direction == "up")
            {
                redHeroPictureBox.Image = Properties.Resources.Red_Forward;
            }
            else if (p2Direction == "right")
            {
                redHeroPictureBox.Image = Properties.Resources.Red_Right;
            }
            else if (p2Direction == "down")
            {
                redHeroPictureBox.Image = Properties.Resources.Red_Down;
            }
            else if (p2Direction == "left")
            {
                redHeroPictureBox.Image = Properties.Resources.Red_Left;
            }

            //Draws the walls
            e.Graphics.FillRectangle(penBrush, 0, 0, this.Width, wallWidth);
            e.Graphics.FillRectangle(penBrush, this.Width - wallWidth, 0, wallWidth, this.Height);
            e.Graphics.FillRectangle(penBrush, 0, this.Height - wallWidth, this.Width, wallWidth);
            e.Graphics.FillRectangle(penBrush, 0, 0, wallWidth, this.Height);

            //the timer
            e.Graphics.DrawString("Time: " + secondsLeft, winnerFont, penBrush, 0, 0);
        }
    }
}
