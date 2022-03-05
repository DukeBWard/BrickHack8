using ModSynth.Common.Enums;
using System;

namespace ModSynth.Common.Models
{
    public struct Tuning
    {
        public Tuning(TuningType type, Note note, float frequency)
        {
            TuningType = type;
            BasisNote = note;
            BasisFrequency = frequency;
        }

        public TuningType TuningType { get; set; }

        public Note BasisNote { get; set; }

        public float BasisFrequency { get; set; }

        public float TuneNote(Note note)
        {
            switch (TuningType)
            {
                case TuningType.EqualTempered:
                    int n = note - BasisNote;
                    float coefficient = MathF.Pow(2, (float)n / 12);
                    return BasisFrequency * coefficient;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
