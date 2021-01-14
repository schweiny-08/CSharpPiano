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
        public Point Location { get; internal set; }

        private MusicNoteShape mns;
        private ResourceManager rm = Properties.Resources.ResourceManager;

        private int pitch;
        private String noteShape;
        private bool isDragging = false;
        private int noteDuration;
        //private Bitmap noteShape;
        //private Accid _accid;
        public MusicNote(int p,  int duration, String nShape, int x) : base()
        {
            pitch = p;
            noteDuration = duration;
            noteShape = nShape;
           
            this.Location = new Point(100, 50);
            Size = new Size(30, 35);
            Bitmap bmp = (Bitmap)rm.GetObject(noteShape);
            bmp.MakeTransparent(Color.White);
            Image = bmp;

            BackColor = Color.Red;
            if (p == 1)
                BackColor = Color.Blue;
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

            //yPos += (25-p);

            return 0;
        }
    }
}