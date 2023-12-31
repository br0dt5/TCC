﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class LfoViewModel : ViewModelBase
    {

        public string SelectedLfoType { get; set; }

        private double _amount = 0;
        public double Amount
        {
            get { return _amount; }
            set {
                _amount = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Amount");
            }
        }

        private double _frequency = 0;
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

        public void SelectLfoType(int lfoIndex)
        {
            switch (lfoIndex)
            {
                case 0:
                    SelectedLfoType = "Senoidal";
                    break;
                case 1:
                    SelectedLfoType = "Quadrada";
                    break;
                case 2:
                    SelectedLfoType = "Triangular";
                    break;

            }
            NotifyPropertyChanged("SelectedLfoType");
        }
        
    }
}
