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
            tempo = 0;
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
                Thread.Sleep(tempo);
            }
            t.Abort();
            //PauseMelody();
            //playButton.Text = "Play";
        }

        public void PauseMelody() {
            t.Abort();
            currentNotePlaying.StopPlaying();

        }

        public bool IsThreadAlive() {
            return t.IsAlive;
        }

        public void AdjustTempo(int tempoSize, int tempoIndex) {
            //Adjusts tempo (Grave/Largo/Lento/Adagio/Andante/Moderato/Allegro/Presto)
            int bpm = 0;
            switch(tempoIndex){
                case 0:
                    bpm = 30;
                    break;
                case 1:
                    bpm = 50;
                    break;
                case 2:
                    bpm = 60;
                    break;
                case 3:
                    bpm = 70;
                    break;
                case 4:
                    bpm = 90;
                    break;
                case 5:
                    bpm = 110;
                    break;
                case 6:
                    bpm = 120;
                    break;
                case 7:
                    bpm = 200;
                    break;
            }

            tempo = 60000 / bpm;
        }

    }
}
