using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class LfoViewModel : ViewModelBase
    {
        private double _amount = 1;
        public double Amount
        {
            get { return _amount; }
            set {
                _amount = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Amount");
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
