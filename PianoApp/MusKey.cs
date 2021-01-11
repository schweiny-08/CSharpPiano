using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoApp
{
    public class MusKey : System.Windows.Forms.Button
    {
        private int musicNote;
        public int notePitch;

        public MusKey(int iNote, int x, int y) : base()
        {
            notePitch = iNote;
            this.Location = new Point(x, y);
            this.Size = new Size(20, 80);
            this.Visible = true;
        }
    }
}
