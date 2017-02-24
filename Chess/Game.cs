using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Chess
{
    class Game
    {
        Figures Figs = new Figures();
        public void Draw(Graphics g)
        {
            foreach(Figures.Figure f in Figs.F)
            {
                f.Draw(g);
            }
        }
    }
}
