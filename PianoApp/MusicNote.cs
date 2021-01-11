using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PianoApp
{
    enum Accid {Flat,
                Sharp,
                Sole};

    class MusicNote
    {
        private int pitch;
        private Bitmap noteShape;
        private byte noteDuration;
        private Accid _accid;
        public MusicNote(int p, Bitmap shape, byte duration, Accid a) {
            pitch = p;
            noteShape = shape;
            noteDuration = duration;
            _accid = a;
        }

        public void OnClick() {
            //Play sound file for noteDuration milliseconds
        }

        public void OnRightPressEditDuration() {
            //Edits duration of music note
        }

        public void OnLeftPressDrag() { 
            //Edits pitch of note (vertically on staff)
        }
    }
}
