using Synthesizer.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Synthesizer.ViewModel
{
    public class OctaveViewModel : ViewModelBase
    {

        
        private short _octave;
        public short Octave
        {
            get { return _octave; }
            set 
            {                
                _octave = value;
                NotifyPropertyChanged("Octave");
            }
        }

        

    }
}
