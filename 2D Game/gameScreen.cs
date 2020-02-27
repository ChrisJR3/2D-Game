using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2D_Game
{
    public partial class gameScreen : UserControl
    {
        //For keeping track of the trails
        List<int> greenTrail = new List<int>();
        List<int> redTrail = new List<int>();

        //Brushes
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        //player 1 (green) control keys
        Boolean wKeyDown, aKeyDown, sKeyDown, dKeyDown;

        //player 2 (red) control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown;

        //creating variables that apply to both players
        public static int playerSpeed = 5;
        int boxSize = 10;
        //string p1Direction;
        //string p2Direction;
        int p1X, p1Y, p2X, p2Y;

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
            p1X = this.Height;
            p1Y = 0;
            p2X = 0;
            p2Y = this.Width;

            greenHero = new movement(p1X, p1Y, boxSize);
            redHero = new movement(p2X, p2Y, boxSize);
        }

        private void gameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Green rider button presses (Player 1)
            switch (e.KeyCode)
            {
                case Keys.W:
                    wKeyDown = true;
                    break;
                case Keys.A:
                    aKeyDown = true;
                    break;
                case Keys.S:
                    sKeyDown = true;
                    break;
                case Keys.D:
                    dKeyDown = true;
                    break;
            }

            //Red rider button presses (Player 2)
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        private void gameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //Green rider button releases (Player 1)
            switch (e.KeyCode)
            {
                case Keys.W:
                    wKeyDown = false;
                    break;
                case Keys.A:
                    aKeyDown = false;
                    break;
                case Keys.S:
                    sKeyDown = false;
                    break;
                case Keys.D:
                    dKeyDown = false;
                    break;
            }

            //Red rider button releases (Player 2)
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }

        private void gameLoop_Tick(object sender, EventArgs e)
        {
            //deciding the direction of Green rider (Player 1)
            if (wKeyDown)
            {
                greenHero.Move("up", greenTrail);
            }
            else if (aKeyDown)
            {
                greenHero.Move("left", greenTrail);
            }
            else if (sKeyDown)
            {
                greenHero.Move("down", greenTrail);
            }
            else if (dKeyDown)
            {
                greenHero.Move("right", greenTrail);
            }

            //deciding the direction of Red rider (Player 2)
            if (upArrowDown)
            {
                redHero.Move("up", redTrail);
            }
            else if (leftArrowDown)
            {
                redHero.Move("left", redTrail);
            }
            else if (downArrowDown)
            {
                redHero.Move("down", redTrail);
            }
            else if (rightArrowDown)
            {
                redHero.Move("right", redTrail);
            }

            Refresh();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
             
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Green hero (p1)
            e.Graphics.FillRectangle(greenBrush, greenHero.x, greenHero.y, greenHero.size, greenHero.size);

            //Red hero (p2)
            e.Graphics.FillRectangle(redBrush, redHero.x, redHero.y, redHero.size, redHero.size);

            //Green trail
            foreach (movement t in greenTrail)
            {

            }

            //Red trail
        }
    }
}
