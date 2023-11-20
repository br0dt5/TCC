using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Dsp;
using Synthesizer.ViewModel;

namespace Synthesizer.core
{
    public class CustomReverbEffect : ISampleProvider
    {
        private ISampleProvider source;
        private float[] delayBuffer;
        private int delayOffset;
        private float reverbLevel = 0.5f;

        public EffectViewModel EffectViewModel { get; set; }

        public CustomReverbEffect(ISampleProvider source, EffectViewModel viewModel)
        {
            this.source = source;
            this.EffectViewModel = viewModel;
            UpdateReverbLevel();
            int delayBytes = (int)(source.WaveFormat.SampleRate * reverbLevel / 1000.0);
            delayBuffer = new float[delayBytes];
        }



        public WaveFormat WaveFormat => source.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                float reverbSample = buffer[offset + n];

                if(delayBuffer.Length> 0)
                {
                    float delayedSample = delayBuffer[delayOffset];
                    delayBuffer[delayOffset] = reverbSample + delayedSample * 0.5f * reverbLevel;// Adjust mix level
                    reverbSample += delayedSample * 1.0f;// Adjust mix level

                    buffer[offset + n] = reverbSample;

                    delayOffset++;
                    if (delayOffset >= delayBuffer.Length)
                    {
                        delayOffset = 0;
                    }
                }
            }

            return samplesRead;
        }

        private void UpdateReverbLevel()
        {
            reverbLevel = (float)EffectViewModel.Reverb;
            int delayBytes = (int)(source.WaveFormat.SampleRate * (reverbLevel * 2) / 1000.0);
            delayBuffer = new float[delayBytes];
        }
    }


    public class CustomChorusEffect : ISampleProvider
    {
        private ISampleProvider source;
        private float phase;
        private float ModulationDepth = 20.0f;
        private float ModulationRate = 0.3f;

        public EffectViewModel EffectViewModel { get; set; }

        public CustomChorusEffect(ISampleProvider source, EffectViewModel viewModel)
        {
            this.source = source;
            this.EffectViewModel = viewModel;
            UpdateChorusLevel();
        }

        public WaveFormat WaveFormat => source.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = source.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                float chorusSample = buffer[offset + n];

                float modulation = (float)Math.Sin(phase) * ModulationDepth * 0.3f;// Adjust mix level
                int delayedSampleIndex = (int)(n + modulation);

                if (delayedSampleIndex >= 0 && delayedSampleIndex < samplesRead)
                {
                    float delayedSample = buffer[offset + delayedSampleIndex];
                    chorusSample += delayedSample * 0.2f; // Adjust mix level
                }

                buffer[offset + n] = chorusSample;

                phase += ModulationRate * 0.3f;// Adjust mix level
                if (phase >= 2 * Math.PI)
                {
                    phase -= 2 * (float)Math.PI;
                }
            }

            return samplesRead;
        }

        public void UpdateChorusLevel()
        {
            ModulationDepth = 0.01f * (float)EffectViewModel.Chorus;
        }
    }

}
