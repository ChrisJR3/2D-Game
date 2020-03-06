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

        public List<Point> playerTrail = new List<Point>();

        public movement(int _x, int _y, int _size, int _speed)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
        }

        public void Move(string direction)
        {
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

            playerTrail.Add(new Point(x+(size/4), y+(size/4)));
        }
    }
}