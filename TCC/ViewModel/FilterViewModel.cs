using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class FilterViewModel: ViewModelBase
    {
        private double _ressonance = 1;
        public double Ressonance
        {
            get
            {
                return _ressonance;
            }
            set
            {
                _ressonance = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Ressonance");
            }
        }

        private double _cutOff = 1;
        public double CutOff
        {
            get
            {
                return _cutOff;
            }
            set
            {
                _cutOff = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("CutOff");
            }
        }
        
    }
}
