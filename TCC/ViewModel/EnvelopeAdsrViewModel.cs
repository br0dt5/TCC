using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class EnvelopeAdsrViewModel: ViewModelBase
    {
        private double _attack = 1;
        public double Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Attack");
            }
        }

        private double _decay = 1;
        public double Decay
        {
            get
            {
                return _decay;
            }
            set
            {
                _decay = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Decay");
            }
        }

        private double _sustain = 1;
        public double Sustain
        {
            get
            {
                return _sustain;
            }
            set
            {
                _sustain = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Sustain");
            }
        }

        private double _release = 1;
        public double Release
        {
            get
            {
                return _release;
            }
            set
            {
                _release = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Release");
            }
        }
        
    }
}
