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
        public static int playerSpeed = 7;
        int boxSize = 20;
        int p1X, p1Y, p2X, p2Y;
        int wallWidth = 3;
        int timer = 30000;
        int secondsLeft;
        string p1Direction = "up";
        string p2Direction = "down";

        Rectangle greenSafteyRectangle;
        Rectangle redSafteyRectangle;

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

            greenHero = new movement(p1X, p1Y, boxSize, playerSpeed);
            redHero = new movement(p2X, p2Y, boxSize, playerSpeed);

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

            //Walls
            Rectangle wall1 = new Rectangle(0, 0, this.Width, wallWidth);
            Rectangle wall2 = new Rectangle(this.Width, 0, -wallWidth, this.Height);
            Rectangle wall3 = new Rectangle(0, this.Height, this.Width, -wallWidth);
            Rectangle wall4 = new Rectangle(0, 0, wallWidth, this.Height);

            //If the players hit head on 
            if (greenHeroRec.IntersectsWith(redHeroRec))
            {
                gameOver("Tie");
                return;
            }  
            //If player runs into another player's or their own trail
            else
            {
                //Creating the saftey rectangles for Green Rider trail (p1) 
                if (p1Direction == "up")
                {
                    greenSafteyRectangle = new Rectangle(greenHero.x, greenHero.y + (greenHero.size / 4), greenHero.size, greenHero.size);
                }
                else if (p1Direction == "down")
                {
                    greenSafteyRectangle = new Rectangle(greenHero.x, greenHero.y - (greenHero.size / 4), greenHero.size, greenHero.size);
                }
                else if (p1Direction == "right")
                {
                    greenSafteyRectangle = new Rectangle(greenHero.x - (greenHero.size / 4), greenHero.y, greenHero.size, greenHero.size);
                }
                else
                {
                    greenSafteyRectangle = new Rectangle(greenHero.x + (greenHero.size / 4), greenHero.y, greenHero.size, greenHero.size);
                }

                // check for collisons with green trail
                foreach (Point t in greenHero.playerTrail)
                {
                    Rectangle greenTrail = new Rectangle(t.X, t.Y, greenHero.size / 2, greenHero.size / 2);

                    if (greenTrail.IntersectsWith(greenHeroRec) && !greenTrail.IntersectsWith(greenSafteyRectangle))
                    {
                        gameOver("Red Rider");
                        return;
                    }

                    if (greenTrail.IntersectsWith(redHeroRec))
                    {
                        gameOver("Green Rider");
                        return;
                    }
                }

                //Creating the saftey rectangles for Red Rider trail (p2)
                if (p2Direction == "up")
                {
                     redSafteyRectangle = new Rectangle(redHero.x, redHero.y + (redHero.size / 4), redHero.size, redHero.size);
                }
                else if (p2Direction == "down")
                {
                     redSafteyRectangle = new Rectangle(redHero.x, redHero.y - (redHero.size / 4), redHero.size, redHero.size);
                }
                else if (p2Direction == "right")
                {
                     redSafteyRectangle = new Rectangle(redHero.x - (redHero.size / 4), redHero.y, redHero.size, redHero.size);
                }
                else
                {
                     redSafteyRectangle = new Rectangle(redHero.x + (redHero.size / 4), redHero.y, redHero.size, redHero.size);
                }

                // check for collisons with red trail
                foreach (Point t in redHero.playerTrail)
                {
                    Rectangle redTrail = new Rectangle(t.X, t.Y, redHero.size / 2, redHero.size / 2);

                    //If red rider hits it's own trail
                    if (redTrail.IntersectsWith(redHeroRec) && !redTrail.IntersectsWith(redSafteyRectangle))
                    {
                        gameOver("Green Rider");
                        return;
                    }

                    //If green rider hits red rider's trail
                    if (redTrail.IntersectsWith(greenHeroRec))
                    {
                        gameOver("Red Rider");
                        return;
                    }
                }

            }
            
            //if either rider hits the walls
            if (greenHeroRec.IntersectsWith(wall1)||greenHeroRec.IntersectsWith(wall2)||greenHeroRec.IntersectsWith(wall3)||greenHeroRec.IntersectsWith(wall4)){gameOver("Red Rider");}
            if(redHeroRec.IntersectsWith(wall1)||redHeroRec.IntersectsWith(wall2)||redHeroRec.IntersectsWith(wall3)||redHeroRec.IntersectsWith(wall4)){gameOver("Green Rider");}

            //if timer reaces 30 seconds
            if (timer == 0)
            {
                gameOver("Tie");
                return;
            }

            Refresh();
        }

        public void gameOver(string winner)
        {
            //creates Graphics
            Graphics e = this.CreateGraphics();
            gameLoop.Enabled = false;


            //if greenHero (P1) wins
            if (winner == "Green Rider") {e.DrawString("Green Rider Wins!", winnerFont, penBrush, this.Width/2 - 10, this.Height/2);}

            //if redHero (P2) wins
            else if (winner == "Red Rider") {e.DrawString("Red Rider Wins!", winnerFont, penBrush, this.Width / 2 - 10, this.Height / 2);}

            //if it is a tie
            else {e.DrawString("It's a tie!", winnerFont, penBrush, this.Width / 2 - 10, this.Height / 2);}

            Thread.Sleep(2000);

            //Close gameScreen and reopen Mainscreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            Mainscreen ms = new Mainscreen();
            f.Controls.Add(ms);
            ms.Focus();
        }

        private void GameScreen_Load(object sender, EventArgs e){}

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Green trail
            foreach (Point t in greenHero.playerTrail) {e.Graphics.FillRectangle(greenBrush, t.X, t.Y, greenHero.size/2, greenHero.size/2);}

            //Red trail
            foreach (Point t in redHero.playerTrail) {e.Graphics.FillRectangle(redBrush, t.X, t.Y, redHero.size/2, redHero.size/2);}

            //Green hero (p1)
            e.Graphics.FillRectangle(greenHeroBrush, greenHero.x, greenHero.y, greenHero.size, greenHero.size);

            //Red hero (p2)
            e.Graphics.FillRectangle(redHeroBrush, redHero.x, redHero.y, redHero.size, redHero.size);

            //Makes the walls
            e.Graphics.FillRectangle(penBrush, 0, 0, this.Width, wallWidth);
            e.Graphics.FillRectangle(penBrush, this.Width-wallWidth, 0, wallWidth, this.Height);
            e.Graphics.FillRectangle(penBrush, 0, this.Height-wallWidth, this.Width, wallWidth);
            e.Graphics.FillRectangle(penBrush, 0, 0, wallWidth, this.Height);

            //the timer
            e.Graphics.DrawString("Time: " + secondsLeft, winnerFont, penBrush, 0, 0);
        }
    }
}
