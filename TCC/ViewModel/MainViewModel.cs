using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.ViewModel
{
    public class MainViewModel
    {
        public OscillatorViewModel CurrentOscillator1 { get; }
        public OscillatorViewModel CurrentOscillator2 { get; }
        public LfoViewModel CurrentLfo { get; }
        public EffectViewModel CurrentEffect { get; }
        public FilterViewModel CurrentFilter { get; }
        public EnvelopeAdsrViewModel CurrentEnvelopeAdsr { get; }
        public MasterAmplitudeViewModel CurrentMasterAmplitude { get; }
        public MainViewModel() { 
            CurrentOscillator1 = new OscillatorViewModel();
            CurrentOscillator2 = new OscillatorViewModel();
            CurrentLfo = new LfoViewModel();
            CurrentEffect = new EffectViewModel();
            CurrentFilter = new FilterViewModel();
            CurrentEnvelopeAdsr = new EnvelopeAdsrViewModel();
            CurrentMasterAmplitude = new MasterAmplitudeViewModel();
        }
        
    }
}
