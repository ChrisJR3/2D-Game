using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Game
{
    class movement
    {

        public int x, y, size;

        public movement(int _x, int _y, int _size)
        {
            x = _x;
            y = _y;
            size = _size; 
        }

        public List<int> Move(string direction, List<int> playerTrail)
        {
            if (direction == "up")
            {
                x = x + gameScreen.playerSpeed;
            }
            else if (direction == "down")
            {
                x = x - gameScreen.playerSpeed;
            }
            else if (direction == "right")
            {
                y = y + gameScreen.playerSpeed;
            }
            else if (direction == "left")
            {
                y = y - gameScreen.playerSpeed;
            }

            return playerTrail;
        }
    }
}
