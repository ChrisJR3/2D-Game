using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _2D_Game
{
    class movement
    {
        //creating ints
        public int x, y, size, speed;

        //Creates the list for the trail
        public List<Point> playerTrail = new List<Point>();

        Rectangle greenSafteyRectangle;
        Rectangle redSafteyRectangle;

        public movement(int _x, int _y, int _size, int _speed)
        {
            //Renaming the ints to the same name for convenient use later on
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }

        public void Move(string direction)
        {
            //Decides which direction the player is going, then either adds or subtracts the speed, set above, to either the x or y value
            if (direction == "up")
            {
                y = y - gameScreen.playerSpeed;
            }

            else if (direction == "down")
            {
                y = y + gameScreen.playerSpeed;
            }

            else if (direction == "right")
            {
                x = x + gameScreen.playerSpeed;
            }

            else if (direction == "left")
            {
                x = x - gameScreen.playerSpeed;
            }

            //Adds rhe new point created to the player's trail list, allowing us to keep track of everywhere they've been, allowing us to make the trail
            playerTrail.Add(new Point(x+(size/4), y+(size/4)));
        }
        public void Collision(Rectangle greenHeroRec, Rectangle redHeroRec, string p1Direction, string p2Direction, int greenHeroX, int greenHeroY, int greenHeroSize, List <Point> greenHeroPlayerTrail, int redHeroX, int redHeroY, int redHeroSize, List <Point> redHeroPlayerTrail, Rectangle wall1, Rectangle wall2, Rectangle wall3, Rectangle wall4, string endGame)
        {
            //If the players hit head on 
            if (greenHeroRec.IntersectsWith(redHeroRec))
            {
                endGame = "Tie";
                return;
            }
            //If player runs into another player's or their own trail
            else
            {
                //Creating the saftey rectangles for Green Rider trail (p1) 
                if (p1Direction == "up")
                {
                    greenSafteyRectangle = new Rectangle(greenHeroX, greenHeroY + (greenHeroSize / 4), greenHeroSize, greenHeroSize);
                }
                else if (p1Direction == "down")
                {
                    greenSafteyRectangle = new Rectangle(greenHeroX, greenHeroY - (greenHeroSize / 4), greenHeroSize, greenHeroSize);
                }
                else if (p1Direction == "right")
                {
                    greenSafteyRectangle = new Rectangle(greenHeroX - (greenHeroSize / 4), greenHeroY, greenHeroSize, greenHeroSize);
                }
                else
                {
                    greenSafteyRectangle = new Rectangle(greenHeroX + (greenHeroSize / 4), greenHeroY, greenHeroSize, greenHeroSize);
                }

                // check for collisons with green trail
                foreach (Point t in greenHeroPlayerTrail)
                {
                    Rectangle greenTrail = new Rectangle(t.X, t.Y, greenHeroSize / 2, greenHeroSize / 2);

                    if (greenTrail.IntersectsWith(greenHeroRec) && !greenTrail.IntersectsWith(greenSafteyRectangle))
                    {
                        endGame = "Red Rider";
                        return;
                    }

                    if (greenTrail.IntersectsWith(redHeroRec))
                    {
                        endGame = "Green Rider";
                        return;
                    }
                }

                //Creating the saftey rectangles for Red Rider trail (p2)
                if (p2Direction == "up")
                {
                    redSafteyRectangle = new Rectangle(redHeroX, redHeroY + (redHeroSize / 4), redHeroSize, redHeroSize);
                }
                else if (p2Direction == "down")
                {
                    redSafteyRectangle = new Rectangle(redHeroX, redHeroY - (redHeroSize / 4), redHeroSize, redHeroSize);
                }
                else if (p2Direction == "right")
                {
                    redSafteyRectangle = new Rectangle(redHeroX - (redHeroSize / 4), redHeroY, redHeroSize, redHeroSize);
                }
                else
                {
                    redSafteyRectangle = new Rectangle(redHeroX + (redHeroSize / 4), redHeroY, redHeroSize, redHeroSize);
                }

                // check for collisons with red trail
                foreach (Point t in redHeroPlayerTrail)
                {
                    Rectangle redTrail = new Rectangle(t.X, t.Y, redHeroSize / 2, redHeroSize / 2);

                    //If red rider hits it's own trail
                    if (redTrail.IntersectsWith(redHeroRec) && !redTrail.IntersectsWith(redSafteyRectangle))
                    {
                        endGame = "Green Rider";
                        return;
                    }

                    //If green rider hits red rider's trail
                    if (redTrail.IntersectsWith(greenHeroRec))
                    {
                        endGame = "Red Rider";
                        return;
                    }
                }

            }

            //if either rider hits the walls
            if (greenHeroRec.IntersectsWith(wall1) || greenHeroRec.IntersectsWith(wall2) || greenHeroRec.IntersectsWith(wall3) || greenHeroRec.IntersectsWith(wall4)) { endGame = "Red Rider"; }
            if (redHeroRec.IntersectsWith(wall1) || redHeroRec.IntersectsWith(wall2) || redHeroRec.IntersectsWith(wall3) || redHeroRec.IntersectsWith(wall4)) { endGame = "Green Rider"; }

        }
    }
}
