using LiveCharts.Wpf;
using LiveCharts;
using NAudio.Dsp;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Synthesizer.Controls;
using Synthesizer.core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using LiveCharts.Defaults;

namespace Synthesizer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public OscillatorViewModel CurrentOscillator1 { get; }
        public OscillatorViewModel CurrentOscillator2 { get; }
        public LfoViewModel CurrentLfo { get; }
        public EffectViewModel CurrentEffect { get; }
        public FilterViewModel CurrentFilter { get; }
        public EnvelopeAdsrViewModel EnvelopeAdsr { get; }
        public MasterAmplitudeViewModel CurrentMasterAmplitude { get; }        
        
        private short _octave = 2;
        public short Octave
        {
            get
            {
                return _octave;
            }
            set
            {
                if(value != _octave)
                {
                    _octave = value;                    
                }
            }
        }
        public ObservableCollection<OctaveViewModel> OctaveCollection { get; set; }

        private ICommand ChangeOctaveCommand { get; set; }

        private SignalGenerator signalProvider1;
        private SignalGenerator signalProvider2;
        private WaveOut waveOut;
        private EnvelopeAdsrProvider adsrSampleProvider;
        private FiltersProvider filterProvider;
        private bool playingWaveSound = false;        
        
        private float currentNoteIndex;

        private float[] NotesFrequency;

        public MainViewModel() 
        { 
            CurrentOscillator1 = new OscillatorViewModel();
            CurrentOscillator2 = new OscillatorViewModel();
            CurrentLfo = new LfoViewModel();
            CurrentEffect = new EffectViewModel();
            CurrentFilter = new FilterViewModel();
            EnvelopeAdsr = new EnvelopeAdsrViewModel();                                    

            CurrentMasterAmplitude = new MasterAmplitudeViewModel();            

            OctaveCollection = new ObservableCollection<OctaveViewModel>
            {
                new OctaveViewModel { Octave = 2 },
                new OctaveViewModel { Octave = 4 },
                new OctaveViewModel { Octave = 6 },
            };          

            GenerateKeyboardNotes();
        }       

        public void PlayWaveProvider(float NoteIndex)
        {
            currentNoteIndex = NoteIndex;
            float NoteFrequency = NotesFrequency[(short)NoteIndex];
            if (playingWaveSound == false)
            {
                signalProvider1 = new SignalGenerator()
                {
                    Frequency = NoteFrequency,
                    Gain = CurrentOscillator1.Amplitude,
                    Type = CurrentOscillator1.SelectedWaveShape
                }; 
                
                signalProvider2 = new SignalGenerator()
                {
                    Frequency = NoteFrequency,
                    Gain = CurrentOscillator2.Amplitude,
                    Type = CurrentOscillator2.SelectedWaveShape
                };

                var mixingSignalProviders = new MixingSampleProvider(new[] { signalProvider1, signalProvider2});

                filterProvider = CurrentFilter.FilterProviderService(mixingSignalProviders);

                adsrSampleProvider = EnvelopeAdsr.EnvelopeAsdrService(filterProvider);

                CustomReverbEffect reverbEffect = new CustomReverbEffect(adsrSampleProvider, CurrentEffect);
                CustomChorusEffect chorusEffect = new CustomChorusEffect(reverbEffect, CurrentEffect);
                LfoProvider lfoProvider = new LfoProvider(chorusEffect, CurrentLfo);
                

                waveOut = new WaveOut();
                waveOut.Volume = (float)CurrentMasterAmplitude.MasterAmplitude;
                waveOut.Init(adsrSampleProvider);

                waveOut.Init(lfoProvider);

                waveOut.Play();
                playingWaveSound = true;
            }
        }

        public void StopWaveProvider()
        {
            adsrSampleProvider.Stop();
            playingWaveSound = false;
        }


        public void GenerateKeyboardNotes()
        {
            NotesFrequency = KeyboardViewModel.GenerateNotesFrequency(Octave);
        }


    }
}
