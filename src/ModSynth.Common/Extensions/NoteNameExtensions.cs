namespace ModSynth.Common.Enums
{
    public static class NoteNameExtensions
    {
        public static string NoteString(this NoteName noteName)
        {
            switch (noteName)
            {
                case NoteName.CSharp: return "C#";
                case NoteName.DSharp: return "D#";
                case NoteName.FSharp: return "F#";
                case NoteName.GSharp: return "G#";
                case NoteName.ASharp: return "A#";
                default: return noteName.ToString();
            }
        }
    }
}
