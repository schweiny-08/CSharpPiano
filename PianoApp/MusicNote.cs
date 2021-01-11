using System.Drawing;

namespace PianoApp
{
    internal class MusicNote
    {
        private int notePitch;
        private int duration;
        private string bNoteShape;

        public Point Location { get; internal set; }

        public MusicNote(int notePitch, int duration, string bNoteShape)
        {
            this.notePitch = notePitch;
            this.duration = duration;
            this.bNoteShape = bNoteShape;
        }
    }
}