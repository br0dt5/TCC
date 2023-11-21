using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using NAudio.Dsp;
using NAudio.Wave;
using Synthesizer.core;
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

        private ChartValues<ObservablePoint> chart = new ChartValues<ObservablePoint>
        {
            new ObservablePoint(0, 0), // Attack
            new ObservablePoint(1, 1), // AttacK and Decay
            new ObservablePoint(2, 0.4), // Decay and Sustain
            new ObservablePoint(4, 0.4), // Sustain and Release
            new ObservablePoint(5, 0) // Release
        };


        private SeriesCollection _seriesCollection;        

        public SeriesCollection SeriesCollection 
        { 
            get { return _seriesCollection; }
            set 
            {  
                _seriesCollection = value;
                NotifyPropertyChanged("SeriesCollection");
            } 
            
        }
        


        private string _attackDisplay = "0.5s";
        public string AttackDisplay 
        {
            get { return _attackDisplay; }
        }

        private string _decayDisplay = "0.5s";
        public string DecayDisplay
        {
            get { return _decayDisplay; }
        }

        private string _sustainDisplay = "50%";

        public string SustainDisplay
        {
            get { return _sustainDisplay; }
        }

        private string _releaseDisplay = "0.5s";
        public string ReleaseDisplay
        { 
            get { return _releaseDisplay; } 
        }


        private EnvelopeAdsrProvider EnvelopeAdsr { get; set; }

        private double _attack = 0.5;
        public double Attack
        {
            get
            {
                return _attack;
            }
            set
            {
                _attack = ((double)(long)(value * 100)) / 100.0;
                _attackDisplay = $"{_attack}s";
                NotifyPropertyChanged("Attack");
                NotifyPropertyChanged("AttackDisplay");
                                           
                updateSeriesCollection();

            }
        }

        private double _decay = 0.5;
        public double Decay
        {
            get
            {
                return _decay;
            }
            set
            {
                _decay = ((double)(long)(value * 100)) / 100.0;
                _decayDisplay = $"{_decay}s";
                NotifyPropertyChanged("Decay");
                NotifyPropertyChanged("DecayDisplay");
                updateSeriesCollection();
            }
        }

        private double _sustain = 0.5;
        public double Sustain
        {
            get
            {
                return _sustain;
            }
            set
            {
                _sustain = ((double)(long)(value * 100)) / 100.0;
                _sustainDisplay = $"{Math.Round(_sustain * 100, 2)}%";
                NotifyPropertyChanged("Sustain");
                NotifyPropertyChanged("SustainDisplay");

                updateSeriesCollection();
            }
        }

        private double _release = 0.5;
        public double Release
        {
            get
            {
                return _release;
            }
            set
            {
                _release = ((double)(long)(value * 100)) / 100.0;
                _releaseDisplay = $"{_release}s";
                NotifyPropertyChanged("Release");
                NotifyPropertyChanged("ReleaseDisplay");
                updateSeriesCollection();
            }
        }

        public EnvelopeAdsrViewModel()
        {
           updateSeriesCollection();
        }

        public void updateSeriesCollection()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservablePoint>
                    {
                        new ObservablePoint(0, 0), // Attack
                        new ObservablePoint(Attack, 1), // AttacK and Decay
                        new ObservablePoint(1+(Decay), Sustain), // Decay and Sustain
                        new ObservablePoint(4, Sustain), // Sustain and Release
                        new ObservablePoint(4+(Release), 0) // Release
                    },
                    PointGeometrySize = 10
                },
            };
        }

        public EnvelopeAdsrProvider EnvelopeAsdrService(ISampleProvider sampleProvider)
        {

            EnvelopeAdsr = new EnvelopeAdsrProvider(sampleProvider.ToMono())
            {
                AttackSeconds = (float)Attack,
                DecaySeconds = (float)Decay,
                Sustain = (float)Sustain,
                ReleaseSeconds = (float)Release,
            };

            return EnvelopeAdsr;
        }
        
    }
}
