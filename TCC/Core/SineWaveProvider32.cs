using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Core
{
    public class SineWaveProvider32 : NAudio.Wave.WaveProvider32
    {
        int sample;

        public SineWaveProvider32()
        { 
        }

        public float Frequency { get; set; }
        public float Amplitude { get; set; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++) 
            {
                buffer[n + offset] = (float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                sample++;
                if(sample >= sampleRate)
                {
                    sample = 0;
                }
            }
            return sampleCount;
        }
      
    }
}
