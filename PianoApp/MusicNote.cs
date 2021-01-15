using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoApp
{
    enum Accid
    {
        Flat,
        Sharp,
        Sole
    };

    enum MusicNoteShape {
        SemiBreve,
        DotMinim,
        Minim,
        Crotchet,
        Quaver,
        SemiQuaver
    };

    class MusicNote : PictureBox
    {
        //public Point Location { get; internal set; }

        private MusicNoteShape mns;
        private ResourceManager rm = Properties.Resources.ResourceManager;

        private int pitch, startingY = 69;
        private String noteShape;
        private bool isDragging = false;
        private int noteDuration;

        //private Accid _accid;

        public MusicNote(int p,  int duration, String nShape, int x, int paddingCompensation) : base()
        {
            pitch = p;
            noteDuration = duration;
            noteShape = nShape;

            Location = new Point(x, this.NoteYPos(p));//-20 + paddingCompensation);
            
            Bitmap bmp = (Bitmap)rm.GetObject(noteShape);
            bmp = new Bitmap(bmp, new Size(30, 30));
            bmp.MakeTransparent(Color.White); 
            Image = bmp;

            Size = new Size(Image.Width, Image.Height);

            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void OnClick()
        {
            //Play sound file for noteDuration milliseconds
        }

        public void OnRightPressEditDuration()
        {
            //Edits duration of music note
        }

        public void OnLeftPressDrag()
        {
            //Edits pitch of note (vertically on staff)
        }

        public int NoteYPos(int p) {
            int yPos = 0;
            
            yPos = startingY - ((p-1) * 3);

            return yPos;
        }
    }
}