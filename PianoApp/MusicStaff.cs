using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PianoApp
{
    class MusicStaff : Panel
    {
        Button playButton;// = new Button();
        //ComboBox tempo = new ComboBox();
        int tempo;
        Button saveButton;// = new Button();
        Button loadButton;// = new Button();

        public void PlayOneNote() {
            //Play music note on mouse left click
        }

        public void PlayMelody() { 
            //Play all notes on music staff
        }

        public void AdjustTempo() {
            //Adjusts tempo (Grave/Largo/Lento/Adagio/Andante/Moderato/Allegro/Presto)
        }
    }
}
