using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class MasterAmplitudeViewModel : ViewModelBase
    {
        private double _masterAmplitude = 1;
        public double MasterAmplitude
        {
            get
            {
                return _masterAmplitude;
            }
            set
            {
                _masterAmplitude = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("MasterAmplitude");
            }
        }

    }
}
