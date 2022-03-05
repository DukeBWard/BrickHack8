using System;
using System.Runtime.InteropServices;

namespace ModSynth.UI.WinUI.Rendering
{
    /// <summary>
    /// This interface allows access to memory at the byte level which we need to populate audio data that is generated.
    /// </summary>
    [ComImport]
    [Guid("5B0D3235-4DBA-4D44-865E-8F1D0E4FD04D")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    unsafe interface IMemoryBufferByteAccess
    {
        void GetBuffer(out byte* buffer, out uint capacity);
    }
}
