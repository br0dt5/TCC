using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using NAudio.Wave.SampleProviders;

namespace Synthesizer.ViewModel
{
    public class OscillatorViewModel : ViewModelBase
    {
        private double _amplitude = 0.1;
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

        private SignalGeneratorType _selectedWaveShape;

        public SignalGeneratorType SelectedWaveShape 
        { 
            get 
            { 
                return _selectedWaveShape;
            }
            set 
            { 
                if (_selectedWaveShape != value) 
                {
                    _selectedWaveShape = value;
                    NotifyPropertyChanged("SelectedWaveShape");
                }
            } 
        }

        public static SignalGeneratorType SelectWaveShape(int SelectedIndex)
        {
            SignalGeneratorType WaveShape;
            switch (SelectedIndex)
            {
                case 0:
                    //Senoidal
                    WaveShape = SignalGeneratorType.Sin;
                    break;
                case 1:
                    //Square
                    WaveShape = SignalGeneratorType.Square;
                    break;
                case 2:
                    //Triangle
                    WaveShape = SignalGeneratorType.Triangle;
                    break;
                case 3:
                    // SawTooth
                    WaveShape= SignalGeneratorType.SawTooth;
                    break;
                case 4:
                    // WhiteNoise
                    WaveShape= SignalGeneratorType.White;
                    break;
                case 5:
                    // Pink
                    WaveShape = SignalGeneratorType.Pink;
                    break;
                case 6:
                    // Sweep
                    WaveShape = SignalGeneratorType.Sweep;
                    break;
                default:
                    WaveShape = SignalGeneratorType.Sin;
                    break;
            }

            return WaveShape;
        }

        
}
}
