// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The program.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KeybaordAudio
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Lomont;

    using OpenTK.Audio;
    using OpenTK.Audio.OpenAL;

    /// <summary>
    /// The program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        static void Main(string[] args)
        {
            var audioBuffer = new byte[256];
            var fftData = new byte[256];
            var fft = new double[256];
            double fftavg = 0;
            float amplitude = 10.0f;

            var fftTransoformer = new LomontFFT();

            var writers = new List<IWriter>();
            writers.Add(new KeyboardWriter());
            writers.Add(new ConsoleWriter());

            var audioCapture = new AudioCapture(AudioCapture.DefaultDevice, 8000, ALFormat.Mono8, 256);
            audioCapture.Start();
            audioCapture.ReadSamples(audioBuffer, 256);
           
            while (true)
            {
                for (int j = 0; j < 92; j++)
                {
                    // reset mem
                    for (int i = 0; i < 256; i++)
                    {
                        audioBuffer[i] = 0;
                        fftData[i] = 0;
                        fft[i] = 0;
                    }

                    audioCapture.ReadSamples(audioBuffer, 256);

                    for (int i = 0; i < 256; i++)
                    {
                        fft[i] = (audioBuffer[i] - 128) * amplitude;
                    }

                    fftTransoformer.TableFFT(fft, true);
                    
                    for (int i = 0; i < 256; i += 2)
                    {
                        double fftmag = Math.Sqrt((fft[i] * fft[i]) + (fft[i + 1] * fft[i + 1]));
                        fftavg += fftmag;
                        fftData[i] = (byte)fftmag;
                        fftData[i + 1] = fftData[i];
                    }

                    fftavg /= 10;

                    writers.ForEach(x => x.Write(j, fftData));

                    //Thread.Sleep(15);
                    Thread.Sleep(20);
                }
            }
        }
    }
}

