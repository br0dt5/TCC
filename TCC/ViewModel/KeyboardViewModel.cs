using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class KeyboardViewModel : ViewModelBase
    {
        private short _octave;
        public short Octave { 
            get { return _octave; }
            set { _octave = value; }
        }
    }
}
