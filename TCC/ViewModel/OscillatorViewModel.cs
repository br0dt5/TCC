using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Synthesizer.ViewModel
{
    public class OscillatorViewModel : ViewModelBase
    {
        private double _amplitude = 1;
        public double Amplitude
        {
            get
            {
                return _amplitude;
            }
            set
            {
                _amplitude = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Amplitude");
            }
        }

        private double _frequency = 1;
        public double Frequency
        {
            get
            {
                return _frequency;
            }
            set
            {
                _frequency = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Frequency");
            }
        }

        
    }
}
