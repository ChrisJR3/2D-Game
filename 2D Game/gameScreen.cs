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
        public static int playerSpeed = 5;
        int boxSize = 20;
        int p1X, p1Y, p2X, p2Y;
        string p1Direction = "up";
        string p2Direction = "down";
        Boolean endGame = false;

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

            //Cursor.Hide(); //hides cursor            
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Green rider button presses (Player 1)
            switch (e.KeyCode)
            {
                case Keys.W:
                    p1Direction = "up";
                    break;
                case Keys.A:
                    p1Direction = "left";
                    break;
                case Keys.S:
                    p1Direction = "down";
                    break;
                case Keys.D:
                    p1Direction = "right";
                    break;
            }

            //Red rider button presses (Player 2)
            switch (e.KeyCode)
            {
                case Keys.Up:
                    p2Direction = "up";
                    break;
                case Keys.Left:
                    p2Direction = "left";
                    break;
                case Keys.Down:
                    p2Direction = "down";
                    break;
                case Keys.Right:
                    p2Direction = "right";
                    break;
            }
        }

        private void gameScreen_KeyDown(object sender, KeyEventArgs e){}

        private void gameScreen_KeyUp(object sender, KeyEventArgs e){}

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //moving the Green rider (Player 1)
            greenHero.Move(p1Direction);

            //moving the Red rider (Player 2)
            redHero.Move(p2Direction);

            //Collisions
            Rectangle greenHeroRec = new Rectangle(greenHero.x, greenHero.y, greenHero.size, greenHero.size);
            Rectangle redHeroRec = new Rectangle(redHero.x, redHero.y, redHero.size, redHero.size);

            if (greenHeroRec.IntersectsWith(redHeroRec)){gameOver("Tie");}

            foreach (Point t in greenHero.playerTrail)
            {
                Rectangle greenTrail = new Rectangle(t.X, t.Y, greenHero.size/2, greenHero.size/2);

                //if (greenHeroRec.IntersectsWith(greenTrail) && ) {gameOver("Red Rider");}

                if (redHeroRec.IntersectsWith(greenTrail)) {gameOver("Green Rider");}
            }

            foreach (Point t in redHero.playerTrail)
            {
                Rectangle redTrail = new Rectangle(t.X, t.Y, redHero.size/2, redHero.size/2);

                //if (redHeroRec.IntersectsWith(redTrail) && ) {gameOver("Green Rider");}

                if (greenHeroRec.IntersectsWith(redTrail)) {gameOver("Red Rider");}
            }

            if (greenHero.x == 0 || greenHero.x == this.Width || greenHero.y == 0 || greenHero.y == this.Height) {gameOver("Red Rider");}

            if (redHero.x == 0 || redHero.x == this.Width || redHero.y == 0 || redHero.y == this.Height) {gameOver("Green Rider");}           
            
            //Check if the game has ended
            if (endGame == true)
            {
                Form f = this.FindForm();
                f.Controls.Remove(this);

                Mainscreen ms = new Mainscreen();
                f.Controls.Add(ms);
                ms.Focus();
            }

            Refresh();
        }

        public void gameOver(string winner)
        {
            //creates Graphics
            Graphics e = this.CreateGraphics();

            //if greenHero (P1) wins
            if (winner == "Green Rider") {e.DrawString("Green Rider Wins!", winnerFont, penBrush, this.Width/2, this.Height/2);}

            //if redHero (P2) wins
            else if (winner == "Red Rider") {e.DrawString("Red Rider Wins!", winnerFont, penBrush, this.Width / 2, this.Height / 2);}

            //if it is a tie
            else {e.DrawString("It's a tie!", winnerFont, penBrush, this.Width / 2, this.Height / 2);}

            Thread.Sleep(3000);

            //Close screen and reopen Mainscreen
            endGame = true;
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

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
        }
    }
}
