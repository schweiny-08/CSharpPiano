using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PianoApp
{
    class MusicStaff : Panel
    {
        public Button playButton;// = new Button();
        //ComboBox tempo = new ComboBox();
        int tempo;
        Button saveButton;// = new Button();
        Button loadButton;// = new Button();

        private List<MusicNote> Notes = new List<MusicNote>();
        private SoundPlayer sp = new SoundPlayer();
        private MusicNote currentNotePlaying;

        private Thread t;

        /*public void PlayOneNote() {
            //Play music note on mouse left click
        }*/

        public MusicStaff() {
            t = new Thread(PlayThread);
        }

        public void PlayMelody(List<MusicNote> notes) {
            //Play all notes on music staff
            Notes = notes;

            if (!t.IsAlive) {
                t = new Thread(PlayThread);
            }
            
            t.Start();
            
        }

        private void PlayThread() {
            foreach (MusicNote mn in Notes)
            {
                mn.OnClickPlay();
                currentNotePlaying = mn;
                //System.Threading.Thread.Sleep(1000);
            }

            //PauseMelody();
            //playButton.Text = "Play";
        }

        public void PauseMelody() {
            t.Abort();
            currentNotePlaying.StopPlaying();
            
        }

        public void AdjustTempo() {
            //Adjusts tempo (Grave/Largo/Lento/Adagio/Andante/Moderato/Allegro/Presto)
        }
    }
}
