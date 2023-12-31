﻿using NAudio.Wave;
using Synthesizer.core;
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

        private string SelectedFilterType { get; set; }

        private FiltersProvider FilterProvider { get; set; }

        private double _resonance = 1;
        public double Resonance
        {
            get
            {
                return _resonance;
            }
            set
            {
                _resonance = ((double)(long)(value * 100)) / 100.0;
                NotifyPropertyChanged("Resonance");
            }
        }

        private double _cutOff = 1;
        private string _cutOffDisplay = "1 hz";
        public string CutOffDisplay { 
            get 
            { 
                return _cutOffDisplay; 
            } 
        }
        public double CutOff
        {
            get
            {
                return _cutOff;
            }
            set
            {
                _cutOff = ((double)(long)(value * 100)) / 100.0;
                _cutOffDisplay = _cutOff.ToString() + " hz";
                NotifyPropertyChanged("CutOff");
                NotifyPropertyChanged("CutOffDisplay");
            }
        }

        public FiltersProvider FilterProviderService(ISampleProvider source)
        {
            FilterProvider = new FiltersProvider(source, (float)this.CutOff, (float)Resonance, SelectedFilterType);
            return FilterProvider;
        }

        public void SelectFilterType(int filterIndex)
        {
            switch (filterIndex)
            {
                case 0:
                    SelectedFilterType = "LowPassFilter";
                    break;
                case 1:
                    SelectedFilterType = "HighPassFilter";
                    break;
            }
        }
        
    }
}
