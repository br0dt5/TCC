
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class MasterAmplitudeViewModel : ViewModelBase
    {
        private string _masterAmplitudeDisplay = $"100%";
        public string MasterAmplitudeDisplay 
        { 
            get {  return _masterAmplitudeDisplay; } 
            set {  _masterAmplitudeDisplay = value; } 
        }

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
                MasterAmplitudeDisplay = $"{Math.Round(_masterAmplitude * 100, 2)}%";
                NotifyPropertyChanged("MasterAmplitude");
                NotifyPropertyChanged("MasterAmplitudeDisplay");
            }
        }

       

    }
}
