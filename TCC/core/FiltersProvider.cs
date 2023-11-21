using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.core
{
    public class FiltersProvider : ISampleProvider
    {
        private readonly ISampleProvider source;
        private readonly BiQuadFilter filter;
        

        public WaveFormat WaveFormat => source.WaveFormat;

        public FiltersProvider(ISampleProvider source, float cutoffFrequency, float resonance, string filterType)
        {
            this.source = source;
            if(filterType == "LowPassFilter")
            {
                filter = BiQuadFilter.LowPassFilter(WaveFormat.SampleRate, cutoffFrequency, resonance);
                
            }
            else if(filterType == "HighPassFilter")
            {
                filter = BiQuadFilter.HighPassFilter(WaveFormat.SampleRate, cutoffFrequency, resonance);
                
            }
            
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int bytesRead = source.Read(buffer, offset, count);

            for (int n = 0; n < bytesRead; n++)
            {
                buffer[offset + n] = filter.Transform(buffer[offset + n]);
            }

            return bytesRead;
        }
    }
}
