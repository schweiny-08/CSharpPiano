using System.Drawing;
using System.Windows.Forms;

namespace PianoApp
{
    public class MusKey : Button
    {
        public int notePitch;

        public MusKey(int iNote, int x, int y) : base()
        {
            this.BackColor = Color.White;
            notePitch = iNote;
            this.Location = new Point(x, y);
            this.Size = new Size(20, 80);
            this.Visible = true;
            this.SetStyle(ControlStyles.Selectable, false);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderColor = Color.DimGray;
        }
    }
}
