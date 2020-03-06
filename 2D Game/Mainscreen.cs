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
    public partial class Mainscreen : UserControl
    {
        public Mainscreen() {InitializeComponent();}

        private void Mainscreen_Load(object sender, EventArgs e) { Cursor.Show(); }

        private void StartGameButton_1_Click(object sender, EventArgs e)
        {
            //Opens gamescreen and closes Mainscreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            gameScreen gs = new gameScreen();           
            f.Controls.Add(gs);
            gs.Focus();
        }

        private void QuitButton_Click(object sender, EventArgs e) {Application.Exit();}
    }
}
