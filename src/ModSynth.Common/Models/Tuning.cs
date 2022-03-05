using ModSynth.Common.Enums;

namespace ModSynth.Common.Models
{
    public struct Tuning
    {
        public Tuning(TuningType type, Note note, float frequncy)
        {
            TuningType = type;
            BasisNote = note;
            BasisFrequency = frequncy;
        }

        public TuningType TuningType { get; set; }

        public Note BasisNote { get; set; }

        public float BasisFrequency { get; set; }
    }
}
