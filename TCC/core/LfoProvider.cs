using NAudio.Wave;
using NAudio.Dsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synthesizer.ViewModel;

namespace Synthesizer.core
{
    public class LfoProvider : ISampleProvider
    {
        private readonly WaveFormat waveFormat;
        private readonly string selectedLfoType;
        private readonly double amount;
        private readonly double frequency;
        private double phase;
        private const double TwoPi = 2 * Math.PI;
        private ISampleProvider source;

        public LfoProvider(ISampleProvider source, LfoViewModel viewModel)
        {
            this.source = source;
            this.waveFormat = source.WaveFormat;
            selectedLfoType = viewModel.SelectedLfoType;
            amount = viewModel.Amount;
            frequency = viewModel.Frequency;
        }

        public WaveFormat WaveFormat => waveFormat;

        public int Read(float[] buffer, int offset, int count)
        {

            int samplesRead = source.Read(buffer, offset, count);

            for (int i = 0; i < samplesRead; i++)
            {
                double lfoValue = 0;
                switch (selectedLfoType)
                {
                    case "Senoidal":
                        lfoValue = Math.Sin(phase) * amount;
                        break;
                    case "Quadrada":
                        lfoValue = Math.Sign(Math.Sin(phase)) * amount;
                        break;
                    case "Triangular":
                        lfoValue = 2 * amount * (2 * Math.Abs((phase / TwoPi) % 1) - 1);
                        break;
                }

                buffer[i + offset] *= (float)(1 + lfoValue);

                phase += TwoPi * frequency / waveFormat.SampleRate;
                if (phase > TwoPi)
                    phase -= TwoPi;
            }

            return samplesRead;
        }
    }
}