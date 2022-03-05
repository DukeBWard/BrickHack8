using ModSynth.Common;
using ModSynth.Common.Models;
using ModSynth.Graph.Nodes.Interfaces;
using ModSynth.Graph.Ports;
using System;

namespace ModSynth.Graph.Nodes.PCM
{
    public class WaveGeneratorNode : INode
    {
        public WaveGeneratorNode()
        {
            NoteInPort = new InPort<Note>(this);
            TuningInPort = new InPort<Tuning>(this);
            WaveOutPort = new OutPort<AudioFrame>(this);
        }

        public InPort<Note> NoteInPort { get; }

        public InPort<Tuning> TuningInPort { get; }

        public OutPort<AudioFrame> WaveOutPort { get; }

        public void Execute(AudioFrame frame)
        {
            double sample = frame.Theta;
            for (int i = 0; i < frame.Samples; i++)
            {
                Note note = NoteInPort.Execute(frame);
                Tuning tuning = TuningInPort.Execute(frame);
                float freq = GetFrequency(note, tuning.BasisNote, tuning.BasisFrequency);

                double theta = freq * (MathF.PI * 2) * sample;
                double sinValue = Math.Sin(theta);
                frame.Payload[i] = (float)sinValue;

                sample += frame.SampleIncrement;
            }

            WaveOutPort.Value = frame;
        }

        private float GetFrequency(Note note, Note basisNote, float basisFreq)
        {
            int n = note - basisNote;
            float coefficient = MathF.Pow(2, (float)n / 12);
            return basisFreq * coefficient;
        }
    }
}
