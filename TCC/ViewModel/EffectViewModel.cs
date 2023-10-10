using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class EffectViewModel : ViewModelBase
    {
        private double _chorus = 1;
        public double Chorus
        {
            get
            {
                return _chorus;
            }
            set
            {
                _chorus = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Chorus");
            }
        }

        private double _reverb = 1;
        public double Reverb
        {
            get
            {
                return _reverb;
            }
            set
            {
                _reverb = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Reverb");
            }
        }
        
    }
}
