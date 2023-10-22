using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Synthesizer.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Synthesizer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public OscillatorViewModel CurrentOscillator1 { get; }
        public OscillatorViewModel CurrentOscillator2 { get; }
        public LfoViewModel CurrentLfo { get; }
        public EffectViewModel CurrentEffect { get; }
        public FilterViewModel CurrentFilter { get; }
        public EnvelopeAdsrViewModel CurrentEnvelopeAdsr { get; }
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

        private SignalGenerator signalProvider;
        private WaveOut waveOut;
        private AdsrSampleProvider adsrSampleProvider;
        private bool playingWaveSound = false;

        private float firstMusicalNoteFrequency = 32.70f;

        public float[] musicalNotesFrequencyInAnOctave;

        public MainViewModel() 
        { 
            CurrentOscillator1 = new OscillatorViewModel();
            CurrentOscillator2 = new OscillatorViewModel();
            CurrentLfo = new LfoViewModel();
            CurrentEffect = new EffectViewModel();
            CurrentFilter = new FilterViewModel();
            CurrentEnvelopeAdsr = new EnvelopeAdsrViewModel();
            CurrentMasterAmplitude = new MasterAmplitudeViewModel();            

            OctaveCollection = new ObservableCollection<OctaveViewModel>
            {
                new OctaveViewModel { Octave = 2 },
                new OctaveViewModel { Octave = 4 },             
            };                        

            GenerateKeyboardNotes();
        }

       

        public void PlayWaveProvider(float NoteIndex)
        {
            float NoteFrequency = musicalNotesFrequencyInAnOctave[(short)NoteIndex];
            if (playingWaveSound == false)
            {
                signalProvider = new SignalGenerator()
                {
                    Frequency = NoteFrequency,
                    Gain = CurrentOscillator1.Amplitude,
                    Type = CurrentOscillator1.SelectedWaveShape
                };

                adsrSampleProvider = new AdsrSampleProvider(signalProvider.ToMono())
                {
                    AttackSeconds = 0.02f,
                    ReleaseSeconds = 0.02f
                };

                waveOut = new WaveOut();
                waveOut.Init(adsrSampleProvider);
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
            short notesNumberInAnTwoOctaves = 24;
            const float ratioBetweenMusicalNotes = 1.0595f;
            musicalNotesFrequencyInAnOctave = new float[notesNumberInAnTwoOctaves];
            musicalNotesFrequencyInAnOctave[0] = firstMusicalNoteFrequency;

            for (short notesIndex = 0; notesIndex < notesNumberInAnTwoOctaves; notesIndex++)
            {
                short positionInScale = CapturePositionNoteInScale(notesIndex);
                musicalNotesFrequencyInAnOctave[notesIndex] = (float)(firstMusicalNoteFrequency * Math.Pow(ratioBetweenMusicalNotes, (positionInScale - 1)));
            }
        }


        public short CapturePositionNoteInScale(short positionInOctave)
        {
            // Put Octave Again
            positionInOctave++;
            short semitonsInOneOctave = 24;
            short positionInScale = (short)((semitonsInOneOctave * Octave) - (semitonsInOneOctave - positionInOctave));
            return positionInScale;
        }

    }
}
